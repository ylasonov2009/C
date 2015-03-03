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

/*
 * External references
 */
extern LOG_Obj    trace;
extern EDMA3_DRV_Handle hEdma;	/* EDMA handle (Required in EDMA mode) */
extern EDMA3_DRV_Result edma3init();

/*
 * Global References
 */

/*
 * UART0 device params. To be filled in uart0_dev_init function which
 * is called before driver creation
 */
Uart_Params   uartParams;



Int8  Uart_RxBuffer[2];

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
    Ptr buf = NULL;
    Int status   =  0;
    size_t len   =  0;

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
		buf = Uart_RxBuffer;
		while(1)
		{
			// len is number of bytes to receive
			len = 2u;
			status = GIO_submit(hUart_IN,IOM_READ,buf,&len,NULL);
			newKey(buf);
		}
	}
	return;
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

    /* enable the uart instance in the PSC module  */
    Psc_ModuleClkCtrl(Psc_DevId_1, PSC_UART2_LPSC, TRUE);
}



