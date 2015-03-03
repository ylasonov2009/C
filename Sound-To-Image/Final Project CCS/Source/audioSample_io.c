
/*  \file     audioSample_io.c
 *
 *  \brief    sample application for basic input and output of audio signals
 *
 *
 *  Created by: Yordan Lasonov, 2012
 *
 */

/* ========================================================================== */
/*                            Included Files                                  */
/* ========================================================================== */

#include "stdio.h"
#include "std.h"
#include "sio.h"
#include "iom.h"
#include "mem.h"
#include "log.h"
#include "math.h"
#include "string.h"

#include "audioSample_io.h"
#include "audioSamplecfg.h"
#include "bass_filt.h"
#include "mid_filt.h"
#include "treble_filt.h"
/* ========================================================================== */
/*                                Definitions                                 */
/* ========================================================================== */

#define BUFLEN                  1024 	// number of samples per channel (left and right)
#define BUFALIGN                128  	// alignment of buffer for L2 cache 
#define NUM_BUFS                2   	// Num Bufs to be issued and reclaimed 
#define BUFSIZE                 (BUFLEN * sizeof(short) * 2) // * 2, for 2 channels
#define BUF_NUMS				64
#define SD_BUF_SIZE				(BUF_NUMS * BUFLEN * NUM_BUFS)
#define PI						22/7

// note: pin and pout are 2048 shorts (4096 bytes of data)
// note: all sdram buffers are BUF_NUMS times 2048 samples, or twice that amount of bytes.



//input/output buffers
short inBuf [NUM_BUFS][BUFLEN * 2];
short outBuf[NUM_BUFS][BUFLEN * 2];
// buffer in SDRAM
#pragma DATA_SECTION(rec_buffer, "mySDRAM");
short rec_buffer[SD_BUF_SIZE];

#pragma DATA_SECTION(bass_filt_buffer, "mySDRAM");
short bass_filt_buffer[SD_BUF_SIZE];
#pragma DATA_SECTION(mid_filt_buffer, "mySDRAM");
short mid_filt_buffer[SD_BUF_SIZE];
#pragma DATA_SECTION(treble_filt_buffer, "mySDRAM");
short treble_filt_buffer[SD_BUF_SIZE];

#pragma DATA_SECTION(red_buffer, "mySDRAM");
unsigned char red_buffer[SD_BUF_SIZE]; //bass
#pragma DATA_SECTION(green_buffer, "mySDRAM");
unsigned char green_buffer[SD_BUF_SIZE]; //mid
#pragma DATA_SECTION(blue_buffer, "mySDRAM");
unsigned char blue_buffer[SD_BUF_SIZE]; //treble
#pragma DATA_SECTION(alpha_buffer, "mySDRAM");
unsigned char alpha_buffer[SD_BUF_SIZE]; //compounding average

#pragma DATA_SECTION(filt_buffer, "mySDRAM");
unsigned char filt_buffer[SD_BUF_SIZE];

int transmitFlag = 0;

/* ========================================================================== */
/*                                Functions                                   */
/* ========================================================================== */

// Main startup function, after completion, the program moves to the Audio_Task()
// The main is only used for configuration of the board and peripherals.  The
// while loop in the Audio_Task() is where processing of audio data is done.
Void main(Void)
{
    // call the function to configure evm setup of audio
    configureAudio();
    return;
}


// This task handles receiving full input buffers and empty output buffers.  The
// input data can then be processed and placed into the output buffer.  The empty
// input buffer and full output buffers are then issued back to their streams
Void Audio_Task()
{
	// setup the Audio_Task, this involves allocating the pointers to the
	// input and output, as well as edma initialization, and stream creation
	// and priming.
	short *pIn, *pOut;	// pointers to reclaimed buffers
	short mode = 2;
	short state = 0;
	int sample_count = 0;
	int i;
	edma3init();		// initialize the edma library
    createStreams(); 	// Call createStream function to create I/O streams
    primeStreams();		// Call prime function to do priming

    TSK_setpri(&UechoTask, 1);


    // This is the main loop of processing
    while(1)
    {	

		// reclaim full input buffer and empty output buffer from streams
		SIO_reclaim(inStream, (Ptr *)&pIn, NULL);
		SIO_reclaim(outStream, (Ptr *)&pOut, NULL);

		switch (mode)
		{
		case 1:
			Passthrough( pIn, pOut );
			break;

		case 2:
	    	if (transmitFlag == 0)
	    	{
				if(state == 0)
				{
					if (sample_count == 0)
						printf("Recording Audio. Please wait...\n");

					memset(pOut, 0, BUFSIZE);
					memcpy(&rec_buffer[sample_count * BUFLEN * NUM_BUFS], pIn, BUFSIZE);
					sample_count++;

					if (sample_count == BUF_NUMS)
					{
						printf("Done recording\n");
						sample_count = 0;
						state = 1;
					}
				}

				if(state == 1)
				{
					printf("Performing Bass Filtering. Please wait...\n");
					FIR_Filter ( rec_buffer, bass_filt_buffer, bass_filt, BFILTER_SIZE );
					printf("Performing Mid Filtering. Please wait...\n");
					FIR_Filter ( rec_buffer, mid_filt_buffer, mid_filt, MFILTER_SIZE );
					printf("Performing Treble Filtering. Please wait...\n");
					FIR_Filter ( rec_buffer, treble_filt_buffer, treble_filt, TFILTER_SIZE );
					state = 2;
				}

				if(state == 2)
				{
					printf("Performing Numerical Conversion. Please wait...\n");
					int k;
					for(k = 0; k < SD_BUF_SIZE; k++)
					{

						//absolute value of filter output divided by 128
						red_buffer[k] = bass_filt_buffer[k] / 128;
						green_buffer[k] = mid_filt_buffer[k] / 128;
						blue_buffer[k] = treble_filt_buffer[k] / 128;
						alpha_buffer[k] = ((( red_buffer[k] + green_buffer[k] + blue_buffer[k] ) / 3) + (alpha_buffer[k-1])) / 2;

						// absolute value of filter output divided by 256
						/*red_buffer[k] = rec_buffer[k] / 256;
						green_buffer[k] = rec_buffer[k] / 256;
						blue_buffer[k] = rec_buffer[k] / 256;
						alpha_buffer[k] = rec_buffer[k] / 256;*/

						// add 32768 to each sample to make positive
						//red_buffer[k] = bass_filt_buffer[k] / 128;
						//green_buffer[k] = mid_filt_buffer[k] / 128;
						//blue_buffer[k] = treble_filt_buffer[k] / 128;
					}
					state = 3;
				}

				if(state == 3)
				{
					printf("Transmitting Data, via Serial connection to PC. Please wait...\n");
					transmitFlag = 1;
					state = 0;
				}

	    	}
			break;
		case 3:
			if (transmitFlag == 0)
			{
					printf("Generating Sine wave. Please wait...\n");
					Sine ();
					printf("Complete.\n");
					printf("Transmitting Data, via Serial connection to PC. Please wait...\n");
					transmitFlag = 1;
			}
			break;
		case 4:
			if  (transmitFlag == 0)
			{
				printf("Generating numbers. Please wait...\n");
				int counter = 0;
				for (i = 0; i < SD_BUF_SIZE; i++ )
				{
					filt_buffer[i] = counter++;
					if ( counter == 256 )
						counter = 0;
				}


				printf("Complete.\n");
				transmitFlag = 1;
			}
			break;

		default:
			Passthrough( pIn, pOut );
		}


		//issue used input buffer and full output buffer to streams
     	SIO_issue(outStream, pOut, BUFSIZE, NULL);
		SIO_issue(inStream,  pIn,  BUFSIZE, NULL);

    }
}



void FIR_Filter ( short *sdBuf, short *fsdBuf, const float *coeff, int filt_size )
{
	int i, k;
	double sum = 0;

	for (i=0; i < (SD_BUF_SIZE / NUM_BUFS); i++)
	{
		sum = 0;

		for ( k=0; k < filt_size; k++  )
		{
			sum += coeff[k] * sdBuf[2*(i-k)];
		}

		// can be without absolute value, add 32768
		fsdBuf[i*2] = abs(sum);
		fsdBuf[i*2 + 1] = abs(sum);
	}
}

void Passthrough( short *pIn, short *pOut )
{
	short i;
	for (i=0; i < BUFSIZE ; i++)
	{
		pOut[i]=pIn[i];
	}
}


void Sine ()
{
	int i;
	unsigned short value;
	static short ctr = 0;

	for (i=0; i <= 16384; i++)
	{
		value = (32767*sin((2*PI*1000.0*ctr++)/44100)) + 32768;
		red_buffer[i] = (value / 256);
		green_buffer[i] = (value / 256);
		blue_buffer[i] = (value / 256);
		alpha_buffer [i*2] = (((red_buffer[i*2] + green_buffer[i*2] + blue_buffer[i*2])/3) + (alpha_buffer [i*2 -1]))/2;

		if (ctr>=44100/1000.0)
		{
			ctr=0;
		}
	}
}


// This function creates two streams, one for input from the audio codec
// and one for output to the audio codec

static Void createStreams()
{
	// create a stream attribute object
    SIO_Attrs sioAttrs;

	// load default attributes and modify
    sioAttrs	   = SIO_ATTRS;
    sioAttrs.nbufs = NUM_BUFS;
    sioAttrs.align = BUFALIGN;
    sioAttrs.model = SIO_ISSUERECLAIM;

	// set mcasp parameters
    mcasp_chanparam[0].edmaHandle = hEdma;
    mcasp_chanparam[1].edmaHandle = hEdma;

    // open the I/O streams
    outStream = SIO_create("/dioAudioOUT", SIO_OUTPUT, BUFSIZE, &sioAttrs);
    inStream  = SIO_create("/dioAudioIN",  SIO_INPUT,  BUFSIZE, &sioAttrs);
}


// This function 'primes' the streams with the buffers to be used

static Void primeStreams()
{
	// prime the input stream with the buffers allocated earlier
	SIO_issue(inStream, &inBuf[0][0], BUFSIZE, NULL);
	SIO_issue(inStream, &inBuf[1][0], BUFSIZE, NULL);

	// prime the output stream with the buffers allocated earlier
	SIO_issue(outStream, &outBuf[0][0], BUFSIZE, NULL);
	SIO_issue(outStream, &outBuf[1][0], BUFSIZE, NULL);
}
