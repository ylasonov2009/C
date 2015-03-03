/** \file     audioSample_io.h
 *
 *  \brief    header file for audioSample_io.h
 *
 *
 *  Created by: Yordan Lasonov, 2012
 *
 */

/* ========================================================================== */
/*                                 Includes                                   */
/* ========================================================================== */

#include "ti/pspiom/platforms/evm6747/audio/Audio.h"
#include "ti/pspiom/mcasp/Mcasp.h"
#include "ti/sdo/edma3/drv/edma3_drv.h"


/* ========================================================================== */
/*                          Imported Variables                                */
/* ========================================================================== */

extern Int edma3init();
extern EDMA3_DRV_Handle hEdma;
extern LOG_Obj trace;


//-----------------------My Functions------------------------------------------
void Record(short *);
void Forward(short *);
void Back(short *);
void Distortion(short *, short *);
void Echoing(short *, short *);
void Passthrough(short *, short *);
void Flanger(short *, short *);
void Chorusing (short *, short *);
void SimpleEcho (short *pIn, short *);
void Vibrato (short *, short *);


/* ========================================================================== */
/*                         Variables / Prototypes                             */
/* ========================================================================== */

// inStream and outStream are stream handles
static SIO_Handle inStream, outStream;

// Function prototypes
static Void createStreams();
static Void primeStreams();


/* ========================================================================== */
/*                            McaSP, Codec Setup                              */
/* ========================================================================== */

Mcasp_HwSetupData mcaspRcvSetup = {
        /* .rmask    = */ 0xFFFFFFFF, /* All the data bits are to be used     */
        /* .rfmt     = */ 0x000080F0, /*
                                       * 0 bit delay from framsync
                                       * MSB first
                                       * No extra bit padding
                                       * Padding bit (ignore)
                                       * slot Size is 32
                                       * Reads from DMA port
                                       * NO rotation
                                       */
        /* .afsrctl  = */ 0x00000000, /* burst mode,
                                       * Frame sync is one bit
                                       * Rising edge is start of frame
                                       * externally generated frame sync
                                       */
        /* .rtdm     = */ 0x00000001, /* slot 1 is active (DSP)               */
        /* .rintctl  = */ 0x00000003, /* sync error and overrun error         */
        /* .rstat    = */ 0x000001FF, /* reset any existing status bits       */
        /* .revtctl  = */ 0x00000000, /* DMA request is enabled or disabled   */
        {
             /* .aclkrctl  = */ 0x00000000,
             /* .ahclkrctl = */ 0x00000000,
             /* .rclkchk   = */ 0x00000000
        }
} ;

Mcasp_HwSetupData mcaspXmtSetup = {
        /* .xmask    = */ 0xFFFFFFFF, /* All the data bits are to be used     */
        /* .xfmt     = */ 0x000080F0, /*
                                       * 0 bit delay from framsync
                                       * MSB first
                                       * No extra bit padding
                                       * Padding bit (ignore)
                                       * slot Size is 32
                                       * Reads from DMA port
                                       * NO rotation
                                       */
        /* .afsxctl  = */ 0x00000000, /* burst mode,
                                       * Frame sync is one bit
                                       * Rising edge is start of frame
                                       * externally generated frame sync
                                       */
        /* .xtdm     = */ 0x00000001, /* slot 1 is active (DSP)               */
        /* .xintctl  = */ 0x00000007, /* sync error,overrun error,clK error   */
        /* .xstat    = */ 0x000001FF, /* reset any existing status bits       */
        /* .xevtctl  = */ 0x00000000, /* DMA request is enabled or disabled   */
        {
             /* .aclkxctl  = */ 0x00000000,
             /* .ahclkxctl = */ 0x00000000,
             /* .xclkchk   = */ 0x00000000
        },

};


/* McBsp channel parameters                                  */
Mcasp_ChanParams  mcasp_chanparam[Audio_NUM_CHANS]=
{
    {
        0x0001,                    /* number of serialisers      */
        {Mcasp_SerializerNum_0, }, /* serialiser index           */
        &mcaspRcvSetup,
        TRUE,
        Mcasp_OpMode_TDM,          /* Mode (TDM/DIT)             */
        Mcasp_WordLength_32,
        NULL,
        0,
        NULL,
        NULL,
        1,                        /* number of TDM channels      */
        Mcasp_BufferFormat_1SER_1SLOT,
        TRUE,
        TRUE
    },
    {
        0x0001,                   /* number of serialisers       */
        {Mcasp_SerializerNum_5,},
        &mcaspXmtSetup,
        TRUE,
        Mcasp_OpMode_TDM,
        Mcasp_WordLength_32,      /* word width                  */
        NULL,
        0,
        NULL,
        NULL,
        1,                        /* number of TDM channels      */
        Mcasp_BufferFormat_1SER_1SLOT,
        TRUE,
        TRUE
    }
};

Audio_ChannelConfig audioChanParamsIN =
{
   /*  channel 0 (RX)                                            */
    (Ptr)&mcasp_chanparam[0],
    {   /* codec [0]                                              */
        {
            44100,  /* sampling rate for codec */
			   30,  /* gain (%) for codec      */
             0x00,
             0x00
        }
    }
};

Audio_ChannelConfig audioChanParamsOUT =
{
    /*  channel 1 (TX)                                            */
    (Ptr)&mcasp_chanparam[1],
    {
        /* codec [1]                           */
        {
            44100,  /* sampling rate           */
			   70,  /* gain (%) for codec      */
             0x00,
             0x00
        }
    }
};
