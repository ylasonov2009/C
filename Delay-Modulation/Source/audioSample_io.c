
/*  \file     audioSample_io.c
 *
 *  \brief    sample application for basic input and output of audio signals
 *
 *
 *  Created by: Yordan Lasonov, August 2012
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

#include "audioSample_io.h"


/* ========================================================================== */
/*                                Definitions                                 */
/* ========================================================================== */


#define BUFLEN                  1024 	// number of samples per channel (left and right)
#define BUFALIGN                128  	// alignment of buffer for L2 cache 
#define NUM_BUFS                2   	// Num Bufs to be issued and reclaimed 
#define BUFSIZE                 (BUFLEN * sizeof(short) * 2) // * 2, for 2 channels

#define	SDRAM_NUM_BUF			10
#define	SDRAM_BUF_SIZE			BUFLEN * 2 * SDRAM_NUM_BUF
#define REC_BUF_LEN				BUFLEN * 2 * 645


/*--------------------------------SDRAM BUFFERS--------------------------------*/

#pragma DATA_SECTION(FlangBuf, "mySDRAM");
short FlangBuf[SDRAM_BUF_SIZE];

#pragma DATA_SECTION(EchoBuf, "mySDRAM");
short EchoBuf[SDRAM_BUF_SIZE];

#pragma DATA_SECTION(VibBuf, "mySDRAM");
short VibBuf[SDRAM_BUF_SIZE];

#pragma DATA_SECTION(ChorusBuf, "mySDRAM");
short ChorusBuf[SDRAM_BUF_SIZE];

#pragma DATA_SECTION(record_buffer, "mySDRAM");
short record_buffer[REC_BUF_LEN];

//input/output buffers
short inBuf[NUM_BUFS][BUFLEN * 2];
short outBuf[NUM_BUFS][BUFLEN * 2];

int rec_mode = 1;
int mode = 1;
static int record_counter = 0;


/* ========================================================================== */
/*                                Functions                                   */
/* ========================================================================== */

// Main startup function, after completion, the program moves to the Audio_Task()
// The main is only used for configuration of the board and peripherals.  The
// while loop in the Audio_Task() is where processing of audio data is done.
void main(Void)
{
    // call the function to configure evm setup of audio
    configureAudio();
    return;
}


// This task handles receiving full input buffers and empty output buffers.  The
// input data can then be processed and placed into the output buffer.  The empty
// input buffer and full output buffers are then issued back to their streams
void Audio_Task()
{
	// setup the Audio_Task, this involves allocating the pointers to the
	// input and output, as well as edma initialization, and stream creation
	// and priming.
	short *pIn, *pOut;	// pointers to reclaimed buffers

	static int effect_count = 0;
	memset(&EchoBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);
	memset(&FlangBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);
	memset(&ChorusBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);
	memset(&VibBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);
	memset(&record_buffer[0], 0, REC_BUF_LEN * sizeof(short));

	edma3init();		// initialize the edma library
    createStreams(); 	// Call createStream function to create I/O streams
    primeStreams();		// Call prime function to do priming


    // This is the main loop of processing
    while(1)
    {	
		// reclaim full input buffer and empty output buffer from streams
		SIO_reclaim(inStream, (Ptr *)&pIn, NULL);
		SIO_reclaim(outStream, (Ptr *)&pOut, NULL);

		// pIn  is a pointer to the array that holds the input samples that were just captured
		// pOut is a pointer to the array that holds the next output samples
		//
		// all processing takes place here on the current buffer of input samples
		// the output values get places in pOut and are sent back out to the codec
		// for output on the speakers, etc

		//For the recording logic
		if(rec_mode != 0)
		{
			if(record_counter == 0)
			{
				switch(rec_mode)
				{
					case 1:
						printf("Recording\n");
						break;
					case 2:
						printf("Forward Playback\n");
						break;
				}
			}

			if(rec_mode == 3 && record_counter == REC_BUF_LEN)
				printf("Reverse Playback\n");

			switch(rec_mode)
			{
				case 1: //Record 15 seconds
					Record(pIn);
					memset(&pOut[0], 0, BUFSIZE);
					break;
				case 2: //Playback
					Forward(pOut);
					break;
				case 3: //Playback reversed
					Back(pOut);
					break;
			}
		}

		if(rec_mode == 0)
		{

			if(effect_count == 0)
			{
				switch(mode)
				{
					case 1:
						printf("Distortion\n");
						break;
					case 2:
						printf("Single Echo\n");
						break;
					case 3:
						printf("Double Echo\n");
						break;
					case 4:
						printf("Flanger\n");
						break;
					case 5:
						printf("Chorus\n");
						break;
					case 6:
						printf("Vibrato\n");
						break;
				}
			}

			//Audio Effect Mode
			switch(mode)
			{
				case 1:
					Distortion(pIn ,pOut);
					break;
				case 2:
					SimpleEcho(pIn, pOut);
					break;
				case 3:
					Echoing(pIn, pOut);
					break;
				case 4:
					Flanger(pIn, pOut);
					break;
				case 5:
					Chorusing(pIn, pOut);
					break;
				case 6:
					Vibrato(pIn, pOut);
					break;
				default:
					Passthrough(pIn, pOut);
					break;
			}

			effect_count += BUFLEN * 2;
			if(effect_count > REC_BUF_LEN)
			{
				//Reset all variables
				memset(&EchoBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);
				memset(&FlangBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);
				memset(&ChorusBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);
				memset(&VibBuf[0], 0, BUFSIZE * SDRAM_NUM_BUF);

				effect_count = 0;
				mode++;
				if(mode > 6)
				{
					mode = 1;
				}
			}
		}

		//issue used input buffer and full output buffer to streams
     	SIO_issue(outStream, pOut, BUFSIZE, NULL);
		SIO_issue(inStream,  pIn,  BUFSIZE, NULL);
    }
}

//Copies the input buffer to the output buffer
void Passthrough(short *pIn, short *pOut)
{
	int i;

	for(i = 0; i < BUFLEN; i++)
	{
		pOut[i*2]	= (short)(pIn[i*2]);
		pOut[i*2+1] = (short)(pIn[i*2+1]);
	}
}

//Distortion of the input samples by using the hyperbolic tangent function
void Distortion(short *pIn, short *pOut)
{
	int	i;
	float amp = 1500;

	for(i = 0; i < BUFLEN; i++)
	{
		pOut[i*2] =	(short)(amp * (tanh( 2 * pIn[i*2])));
		pOut[i*2+1] = (short)(amp * (tanh( 2 * pIn[i*2+1])));
	}
}

//A double echo of the input buffer based on a fixed dealy
void Echoing (short *pIn, short *pOut)
{
	static int echo_sample_counter = 0;
	int	i;
	short delay1 = BUFLEN * 2 * 2;
	short delay2 = BUFLEN * 2 * 6;

	for(i = 0; i < BUFLEN * 2; i++)
	{

		EchoBuf[echo_sample_counter] = pIn[i];

		int cur_index1 = echo_sample_counter - delay1;
		int cur_index2 = echo_sample_counter - delay2;
		//Clipping on the buffer
		if(cur_index1 < 0)
			cur_index1 += SDRAM_BUF_SIZE;

		if(cur_index2 < 0)
				cur_index2 += SDRAM_BUF_SIZE;

		//printf("curIndex: %d, sampeCount: %d, delay: %d\n", cur_index, echo_sample_counter, delay);
		pOut[i] = (short)(pIn[i] + (0.5 * EchoBuf[cur_index1]) +  (0.3 * EchoBuf[cur_index2]));
		//pOut[i*2+1]	= (short)(pIn[i*2+1] + 0.5 * TempBuf[cur_index + i*2+1]);

		echo_sample_counter++;
		if(echo_sample_counter >= SDRAM_BUF_SIZE)
		{
			echo_sample_counter = 0;
		}
	}
}

//A single echo of the input buffer based on fixed dealy
void SimpleEcho (short *pIn, short *pOut)
{
	int	i;
	short delay = BUFLEN * 2 *3;
	static int echo_simple_sample_counter = 0;

	for(i = 0; i < BUFLEN * 2; i++)
	{
		//Copy the current input sample into the delay buffer
		EchoBuf[echo_simple_sample_counter] = pIn[i];

		//Calculate the read postion in the delay buffer
		int cur_index = echo_simple_sample_counter - delay;
		
		//Clipping read position on the buffer
		if(cur_index < 0)
			cur_index += SDRAM_BUF_SIZE;
		
		//Add the current dealyed sample to the current input sample
		pOut[i] = (short)(pIn[i] + (0.5 * EchoBuf[cur_index]));

		//Incremnt the read position and clip on the dealy buffer size
		echo_simple_sample_counter++;
		if(echo_simple_sample_counter >= SDRAM_BUF_SIZE)
		{
			echo_simple_sample_counter = 0;
		}
	}
}

//Creates the flanger effect by attenuating the pitch of input samples by reading the delay
//buffer at diffent rates
void Flanger(short *pIn, short *pOut)
{
	static int flang_n = 0;
	static int flang_sample_counter = 0;

	int	i;
	float PI = 3.14f;
	float FSAMPLE = 44100.0f;
	float flanger_freq = 0.4f;
	float D = 2205.0f; // Sample Delay

	float f_cycle =	(flanger_freq/FSAMPLE);

	for(i = 0; i < BUFLEN*2; i++)
	{
		//Create variable delay LFO (based of cosine) (cicular buffer)
		short delay = (short)((D/2.0) * (1.0 - cosf(2.0 * PI * (float)flang_n *  f_cycle)));

		//Copy current input sample into FlangBuf
		FlangBuf[flang_sample_counter] = pIn[i];

		//Calculate the index to read from
		int cur_index = flang_sample_counter - (delay*2);

		//Clipping on the buffer
		if(cur_index < 0)
			cur_index += SDRAM_BUF_SIZE;

		//Output the current input plus the sample from the FlangBuf
		pOut[i] = (short) ((pIn[i]) +( 0.5 * FlangBuf[cur_index]));

		//Increment the counter for the LFO
		flang_n++;
		//Clip the on the period of the LFO
		if(flang_n > (1/f_cycle))
			flang_n = 0;

		flang_sample_counter++;
		if(flang_sample_counter >= SDRAM_BUF_SIZE)
		{
			flang_sample_counter = 0;
		}
	}
}

//Provides a two attenuating pitches of the input samples to create the effect of two extra 
//Instruments playing
void Chorusing (short *pIn, short *pOut)
{
	static int chorus_sample_counter = 0;
	static int chorus_n1 = 0;
	static int chorus_n2 = 0;
	int i;
	float PI = 3.14f;
	float FSAMPLE = 44100.0f;
	float chorus_freq1 = 0.7f;
	float chorus_freq2 = 0.9f;
	float D1 = 661.0f;
	float D2 = 1323.0f;
	float f_cycle1 = (chorus_freq1/FSAMPLE);
	float f_cycle2 = (chorus_freq2/FSAMPLE);

	for(i = 0; i < BUFLEN * 2; i++)
	{
		//Calculate delays based off LFO
		short delay1 = (short)(short)((D1/2.0) * (1.0 - cosf(2.0 * PI * chorus_n1 *  f_cycle1)));
		short delay2 = (short)(short)((D2/2.0) * (1.0 - cosf(2.0 * PI * chorus_n2 *  f_cycle2)));

		//Calculate the current read index
		short cur_index1 = chorus_sample_counter - (delay1*2);
		short cur_index2 = chorus_sample_counter - (delay2*2);

		ChorusBuf[chorus_sample_counter] = pIn[i];

		//Clipping on the buffer
		if(cur_index1 < 0)
			cur_index1 += SDRAM_BUF_SIZE;

		if(cur_index2 < 0)
			cur_index2 += SDRAM_BUF_SIZE;

		//Construnc the new output based off dealyed and current samples
		pOut[i] = (short) (pIn[i] + (0.5 * ChorusBuf[cur_index1]) + ( 0.3 * ChorusBuf[cur_index2]));

		//Incerment all counters
		chorus_n1++;
		if(chorus_n1 > (1/f_cycle1))
			chorus_n1=0;

		chorus_n2++;
		if(chorus_n2 > (1/f_cycle2))
			chorus_n2=0;


		chorus_sample_counter ++;
		if(chorus_sample_counter > SDRAM_BUF_SIZE)
		{
			chorus_sample_counter = 0;
		}
	}
}

//quickly echos the sample input back with a faster changing pitch
void Vibrato(short *pIn, short *pOut)
{
	static int vib_sample_counter = 0;
	static int vib_n = 0;
	int i;
	float PI = 3.14;
	float FSAMPLE =	44100.0;
	float vib_freq =  1.0f;
	int	D = 10;

	float f_cycle = (vib_freq/FSAMPLE);

	for(i = 0; i < BUFLEN * 2; i++)
	{
		//Calculate the dealy based off the LFO
		short delay = (short)((D/2) * (sinf(2 * PI * (float)vib_n *  f_cycle)));

		//Store the current input sample into the delay buffer
		VibBuf[vib_sample_counter] = pIn[i];

		//Calculate the read position for the delayed sample
		int cur_index = vib_sample_counter - (delay*2);
		//Clipping on the buffer
		if(cur_index < 0)
			cur_index += SDRAM_BUF_SIZE;

		//Output the delayed sample
		pOut[i] = (short) (1.0 * VibBuf[cur_index]);
		
		vib_n++;
		if(vib_n > 1/f_cycle)
			vib_n=0;

		vib_sample_counter++;
		if(vib_sample_counter >= SDRAM_BUF_SIZE)
		{
			vib_sample_counter = 0;
		}
	}
}

//Copy the contents of the input buffer to the recording buffer
void Record(short *in)
{
	memcpy(&record_buffer[record_counter], &in[0], BUFSIZE);

	record_counter += BUFLEN *2;

	if(record_counter >= REC_BUF_LEN)
	{
		record_counter = 0;
		//Play forwards
		rec_mode = 2;
	}
}

//Plays the samples recored in the recording buffer back to the output buffer
void Forward(short *out)
{

	memcpy(&out[0], &record_buffer[record_counter], BUFSIZE);

	record_counter += BUFLEN *2;

	if(record_counter >= REC_BUF_LEN)
	{
		record_counter = REC_BUF_LEN;
		//Play backward
		rec_mode = 3;
	}
}

//Plays the samples recored in the recording buffer in revers order to the output buffer
void Back(short *out)
{
	int i;

	for(i=0;i < BUFLEN * 2; i++)
	{
		out[i] = record_buffer[record_counter-i];
	}

	record_counter -= BUFLEN *2;

	if(record_counter <= 0)
	{
		record_counter = 0;
		//Play forwards
		rec_mode = 0;
	}
}

// This function creates two streams, one for input from the audio codec
// and one for output to the audio codec
static void createStreams()
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

static void primeStreams()
{
	// prime the input stream with the buffers allocated earlier
	SIO_issue(inStream, &inBuf[0][0], BUFSIZE, NULL);
	SIO_issue(inStream, &inBuf[1][0], BUFSIZE, NULL);

	// prime the output stream with the buffers allocated earlier
	SIO_issue(outStream, &outBuf[0][0], BUFSIZE, NULL);
	SIO_issue(outStream, &outBuf[1][0], BUFSIZE, NULL);
}
