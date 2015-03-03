
/*  \file     audioSample_io.c
 *
 *  \brief    sample application for basic input and output of audio signals
 *
 *
 *  Created by: Jacob Zurasky, August 2011
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
#include "audioSamplecfg.h"

/* ========================================================================== */
/*                                Definitions                                 */
/* ========================================================================== */

#define BUFLEN                  1024 	// number of samples per channel (left and right)
#define BUFALIGN                128  	// alignment of buffer for L2 cache 
#define NUM_BUFS                2   	// Num Bufs to be issued and reclaimed 

#define BUFSIZE                 (BUFLEN * sizeof(short) * 2) // * 2, for 2 channels
#define PI 3.14
#define A 						0.75 // delay gain A = 0.75
#define D                       44100 // delay time D = 100 ms

#define DELAY_BUF_SIZE           BUFLEN * 2 * 10

//input/output buffers

#define SD_BUF_SIZE 			(431*(BUFLEN*2))

#pragma DATA_SECTION(sdram_buffer, "mySDRAM");

short sdram_buffer [431*(BUFLEN*2)];

#define DELAY_BUFFER_SIZE 44100

#pragma DATA_SECTION(delay_buffer, "mySDRAM");
short delay_buffer [DELAY_BUFFER_SIZE]; //size of our delay buffer







//input/output buffers
short inBuf [NUM_BUFS][BUFLEN * 2];
short outBuf[NUM_BUFS][BUFLEN * 2];

float mastervolume = 1;
float osc1volume = 0;
float osc2volume = 0;
float osc3volume = 0;
float audiovolume = 0;
float mastervol = 0;
float echovolume = 0;
float distortionvolume = 0;



int octavesqu = 1;

float freqosc = 0;



//Delay
float delaysize = 0;

char command, value1;
int  newKeyIn;
char curKey;
/* ========================================================================== */
/*                                Functions                                   */
/* ========================================================================== */

// Main startup function, after completion, the program moves to the Audio_Task()
// The main is only used for configuration of the board and peripherals.  TheWQ
// while loop in the Audio_Task() is where processing of audio data is done.
Void main(Void)
{
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
//Octave///////////




// On/OFF ///////////////////////////
	int audioonoff = 1;
	int sinewaveonoff = 1;
	int squarewaveonoff = 1;
	int trianglewaveonoff = 1;
	int flangeronoff = 1;
	int Distortiononoff = 0;
	int chorusonoff = 0;
	int echoonoff = 0;

// Detume





	int ampdev = 1;

	short amplitude = 10000;




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

		SetToZero(pOut);

	if(audioonoff == 1)
	{

		Passthrough(pIn, pOut);

	}
	if(sinewaveonoff == 1)

	{

	Sinewave(pOut, amplitude, freqosc);

	}

	if(squarewaveonoff == 1)

	{

	Squarewave(pOut, amplitude, freqosc);

	}

	if(trianglewaveonoff == 1)

	{

	TriangleWave(pOut, amplitude, freqosc);

	}

	Echo(pOut);
	MainVolume(pOut);


		if(newKeyIn == 1)
		{
			newKeyIn = 0;



			if (curKey == 'Q')
				freqosc = 261.626;
			if (curKey == 'W')
				freqosc = 277.183;
			if (curKey == 'E')
				freqosc = 293.665;
			if (curKey == 'R')
				freqosc = 311.127;
			if (curKey == 'T')
				freqosc = 329.628;
			if (curKey == 'Y')
				freqosc = 349.228;
			if (curKey == 'U')
				freqosc = 369.994;
			if (curKey == 'I')
				freqosc = 391.995;
			if (curKey == 'O')
				freqosc = 415.305;
			if (curKey == 'P')
				freqosc = 440.000;
			if (curKey == 'K')
				freqosc = 466.164;
			if (curKey == 'L')
				freqosc = 493.883;

			if (curKey == 10)
				freqosc = 0;



			if(command == 1)
				osc1volume = value1/10.0;
			if(command == 2)
				osc2volume = value1/10.0;
			if(command == 3)
				osc3volume = value1/10.0;
			if(command == 4)
				mastervol = value1/10.0;
			if(command == 5)
				audiovolume = value1/10.0;

		//Echo
			if(command == 6)
				echovolume = value1/10.0;
			if(command == 9)
				delaysize = value1/10.0;





			if(command == 100)
				octavesqu = 1;
			if(command == 101)
				octavesqu = 2;
			if(command == 102)
				octavesqu = 4;







		}

		//issue used input buffer and full output buffer to streams
     	SIO_issue(outStream, pOut, BUFSIZE, NULL);
		SIO_issue(inStream,  pIn,  BUFSIZE, NULL);
    }
}
void Passthrough(short *pIn, short *pOut)
{
    int i;

    for(i = 0; i < BUFLEN *2; i++)
    	{
    		pOut[i] += pIn[i] * audiovolume;
    	}
}

void SetToZero(short *pOut)

{

int i;

for(i = 0; i < BUFLEN *2; i++)

{

pOut[i]= 0;

}

}


void Sinewave(short *pOut, short amplitude, float frequency)

{
	int i;
	int period;
	static int n;

	period = 44100 / frequency;

	for (i = 0; i < BUFLEN; i++)
	{
		pOut[i*2] += (amplitude*sinf(2*PI*(frequency/44100) * n) * osc1volume);
		pOut[i*2+1] += (amplitude * sinf(2*PI*(frequency/44100) * n) * osc1volume);

		n++;
		if (n > period)
		{
			n=0;
		}
	}

}


void Squarewave (short *pOut, short amplitude, float frequency)

{

int i;

int period;



static int n=0;


period= (44100/(frequency * octavesqu));

for (i=0; i<BUFLEN; i++)

{

if (n<period/2)

{

pOut[i*2] += (amplitude * osc2volume);

pOut[i*2+1] += (amplitude * osc2volume);

}

else

{

pOut[i*2] -= (amplitude * osc2volume);

pOut[i*2+1] -= (amplitude * osc2volume);

}

n++;

if (n > period)

{

n = 0;

}

}

}

void TriangleWave (short *pOut, short amplitude, float frequency)

{

int i;

int period;

static int n=0;

float slope;

period= 44100/frequency;

slope=(2*amplitude)/(period/2);

for (i=0; i<BUFLEN; i++)

{

if(n<period/2)

{

pOut[i*2] += (((slope*n)-amplitude) * osc3volume);

pOut[i*2+1] += (((slope*n)-amplitude) * osc3volume);

}

else

{

pOut[i*2] += (((-slope*n)+(3*amplitude)) *  osc3volume);

pOut[i*2+1] += (((-slope*n)+(3*amplitude)) *  osc3volume);

}

n++;

if (n > period)

{

n = 0;

}}}


void Distortion(short *pOut)

{




}




void Echo (short *pOut)
{
	int i;
	static int counter = 0;


	for(i = 0; i < BUFLEN *2; i++)
	{
		pOut[i] += (A*delay_buffer[counter] * echovolume);
		delay_buffer[counter++] = pOut[i];

		if (counter == D)
		{
			counter = (41000.0*delaysize);
		}
	}
}

void MainVolume(short *pOut)
{
    int i;

    for(i = 0; i < BUFLEN *2; i++)
    	{
    		pOut[i] *= mastervol;
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

void newKey(Int8 *buf)
{

	curKey = buf[0];

	command = buf[0];
	value1 = buf[1];
	//value2 = buf[1];
	//value3 = buf[1];
	newKeyIn = 1;
}
