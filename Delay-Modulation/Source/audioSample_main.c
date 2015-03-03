
/** \file   audioSample_main.c
 *
 *  \brief  sample application for basic input and output of audio signals
 *
 *
 *  Created by: Yordan Lasonov, 2012
 *
 */

/* ========================================================================== */
/*                            INCLUDE FILES                                   */
/* ========================================================================== */

#include "stdio.h"
#include "std.h"
#include "log.h"
#include "ti/pspiom/psc/Psc.h"
#include "ti/pspiom/mcasp/Mcasp.h"
#include "ti/pspiom/platforms/codec/Aic31.h"
#include "ti/pspiom/platforms/evm6747/audio/Audio.h"
#include "ti/pspiom/platforms/evm6747/Audio_evmInit.h"

extern LOG_Obj trace;

/* ========================================================================== */
/*                           MACRO DEFINTIONS                                 */
/* ========================================================================== */




/* mcasp1 module LPSC number      */
#define PSC_MCASP1_LPSC  8

/*
 * Mcasp device params. To be filled in userMcaspInit function which
 * is called before driver creation
 */
Mcasp_Params audioMcaspParams;

/*
 * Aic31 device params. To be filled in userAic31Init function which
 * is called before driver creation
 */
Aic31_Params audioAic31Params;

/*
 * Audio device params. To be filled in userAudioInit function which
 * is called before driver creation
 */

Audio_Params audioParams;

/* ========================================================================== */
/*                           FUNCTION DEFINITIONS                             */
/* ========================================================================== */

/*
 * Aic31 init function called when creating the driver.
 */
void audioUserAic31Init()
{
    Aic31_init();
    audioAic31Params = Aic31_PARAMS;
    audioAic31Params.acCtrlBusName = "/i2c0";
}

/*
 * Mcasp init function called when creating the driver.
 */
void audioUserMcaspInit()
{
    /* power on the Mcasp 1 instance in the PSC  */
    Psc_ModuleClkCtrl(Psc_DevId_1, PSC_MCASP1_LPSC, TRUE);

    Mcasp_init();
    audioMcaspParams = Mcasp_PARAMS;
    audioMcaspParams.hwiNumber = 8;

}

/*
 * Audio init function called when creating the driver.
 */
void audioUserAudioInit()
{
    Audio_init();
    audioParams = Audio_PARAMS;
    audioParams.adDevType = Audio_DeviceType_McASP;
    audioParams.adDevName = "/mcasp1";
    audioParams.acNumCodecs = 1;
    audioParams.acDevName[0] = "/aic310";
}

/* ========================================================================== */
/*                                END OF FILE                                 */
/* ========================================================================== */
