#include <std.h>
#include <stdio.h>
#include <string.h>
#include <gio.h>
#include <log.h>
#include <tsk.h>
#include <stdio.h>

#include <ti/pspiom/uart/Uart.h>
#include <ti/pspiom/psc/Psc.h>
#include <ti/sdo/edma3/drv/edma3_drv.h>
#include <ti/pspiom/platforms/evm6747/Uart_evmInit.h>

#define PSC_UART2_LPSC        13
#define SIZE_BUF			  (50 * 1024 * 2 * sizeof(short))
#define	NUMBER_OF_COUNTS_MS		300000


/*
 * External references
 */
extern LOG_Obj    trace;
extern EDMA3_DRV_Handle hEdma;	/* EDMA handle (Required in EDMA mode) */
extern EDMA3_DRV_Result edma3init();

extern Int8 rec_buffer[];
extern Int8 alpha_buffer[];
extern Int8 red_buffer[];
extern Int8 green_buffer[];
extern Int8 blue_buffer[];
extern Int8 filt_buffer[];


void timed_sleep(unsigned int );

/*
 * Global References
 */
/*
 * UART0 device params. To be filled in uart0_dev_init function which
 * is called before driver creation
 */
Uart_Params   uartParams;

extern int transmitFlag;

/* UART handle for input channel */
GIO_Handle hUart_IN;

/* UART handle for output channel */
GIO_Handle hUart_OUT;

/* Global function prototypes */
void uart0_dev_init(void);

void echo()
{
    GIO_Attrs gioAttrs = GIO_ATTRS;
    Int32 echoTskStatus= 0;
    Uart_ChanParams chanParams;
   // Ptr buf = NULL;
    int status   =  0;
    size_t len   =  0;
    int state = 0;
    /*
     * Initialize channel attributes.
     */
    gioAttrs.nPackets = 2;

    chanParams.hEdma = hEdma;

    /* Initialize pinmux and evm related configurations */
    configureUart();

    /* Initialize UART
    * Currently is been used to display messages
    */
    hUart_OUT = GIO_create("/UART0",IOM_OUTPUT,NULL,&chanParams,&gioAttrs);
    hUart_IN  = GIO_create("/UART0",IOM_INPUT,&echoTskStatus,&chanParams,
    	&gioAttrs);

    if((NULL == hUart_IN)||(NULL == hUart_OUT))
    {
        LOG_printf(&trace, "ERROR: Initialization of UART failed\n");
        return;
    }

    // if passed init, enter task while loop
	if ((NULL != hUart_IN) && (NULL != hUart_OUT))
	{
		while(1)
		{
			if(transmitFlag == 1)
			{
				int inx;
				len = 256u;

				for (inx = 0; inx <= 63 * 256; inx += 256)
				{
					status = GIO_submit(hUart_OUT,IOM_WRITE,&red_buffer[inx],&len,NULL);
					//timed_sleep(200);
					status = GIO_submit(hUart_OUT,IOM_WRITE,&green_buffer[inx],&len,NULL);
					//timed_sleep(200);
					status = GIO_submit(hUart_OUT,IOM_WRITE,&blue_buffer[inx],&len,NULL);
					//timed_sleep(200);
					status = GIO_submit(hUart_OUT,IOM_WRITE,&alpha_buffer[inx],&len,NULL);

					//timed_sleep(300);
					//timed_sleep(500); // maybe slow this down

					if (inx == 9*256)
					{
						printf("10 Sent\n");
					}
					if (inx == 19*256)
					{
						printf("20 Sent\n");
					}
					if (inx == 29*256)
					{
						printf("30 Sent\n");
					}
					if (inx == 39*256)
					{
						printf("40 Sent\n");
					}
					if (inx == 49*256)
					{
						printf("50 Sent\n");
					}
					if (inx == 59*256)
					{
						printf("60 Sent\n");
					}
					if (inx >= 63 * 256)
					{
						//transmitFlag = 0;
						printf("64 Sent\n");
						timed_sleep(1000);
						transmitFlag = 2;
					}
				}

			}
		}
	}
	return;
}


void timed_sleep(unsigned int ms)
{
   register unsigned int count = 0;
   unsigned int total;

   total  = ms * NUMBER_OF_COUNTS_MS;
   while (count < total)
   {
      count += 1;
   }
}



/*
 * UART0 init function called when creating the driver.
 */
void user_uart0_init()
{
    EDMA3_DRV_Result    edmaResult      = 0;

    if (NULL == hEdma)
    {
        edmaResult = edma3init();

        if (edmaResult != EDMA3_DRV_SOK)
        {
            /* Report EDMA Error */
            LOG_printf(&trace,"\r\nEDMA3 : edma3init() failed\r\n");
        }
        else
        {
            LOG_printf(&trace,"\r\nEDMA3 : edma3init() passed\r\n");
        }
    }

    Uart_init();
    uartParams = Uart_PARAMS;
    uartParams.hwiNumber = 9;
    uartParams.opMode = Uart_OpMode_DMAINTERRUPT;
    uartParams.baudRate = 115200;
    //uartParams.rxThreshold = 1024;

    /* enable the uart instance in the PSC module  */
    Psc_ModuleClkCtrl(Psc_DevId_1, PSC_UART2_LPSC, TRUE);
}



