//***************************************
//FFT Parallel
//Name: KEVIN ELLIS, CARLOS PLACENCIA, AND MATT TREBING
//Midwestern State University
//GPU Spring 2018
//(04/23/2018)
//****************************************
/* 
	This program computes the FFT in parallel using cuda
	Runs the program X amount of times and computes the time
	for each iteration. Then averages the time taken
	Each process with get a subtable from the table. Then calculate 
	even and odd for each coeffiencet X then P0 will gather these values
	and print them to the file
	
    TURING COMPILE: ssh gpu
					/opt/cuda-8.0/bin/nvcc gpuFFT.cu -o a
    TURING RUN: ./a

	TACC COMPILE:   module load cuda
                    nvcc -arch=compute_35 -code=sm_35 gpuFFT.cu -o a.out
	TACC RUN: sbatch gpuScript
*/
#include <stdio.h>
#include <cuComplex.h>  //Cuda Complex numbers!!!! Very useful here!
#include <math.h>	//for cos() and sin()
#include "timer.h" //to use timer

#define PI 3.14159265
#define bigN 16384 //Problem Size
#define numBlocks 4 //How many Block do I wanna use??     -> Adaptive is bigN / 1024
#define numThreadsPerBlockx 1024 //How many threads per block ?? -> If numBlocks * numThreads > bigN
								//Then you need to lower this number to bigN / numBlocks

#define howmanytimesavg 3 //How many times do I wanna run for the AVG?
#define howmanytoprint 8 //How many Xi's do I wanna print?

__global__
void KernalFFT(cuDoubleComplex * inNumbers, cuDoubleComplex * outResults)
{
	//get the threads ID
	int threadID = threadIdx.x + blockDim.x * blockIdx.x;
	
	//Create Accumulators for the sum of the EVEN and ODD parts
	//I.E starting as (0 + 0i)
	cuDoubleComplex sumOfEven = make_cuDoubleComplex(0, 0); 
	cuDoubleComplex sumOfOdd = make_cuDoubleComplex(0, 0);
	
	//LOOP that goes 0 to N/2 - 1: [look at FFT formula]
	for (int i = 0; i <= (bigN / 2) - 1; i++) {
		//==========================EVEN PART STARTS HERE================================
		cuDoubleComplex evenFromTable = inNumbers[2 * i];   // 2n gives all the even numbers

		double factorEven = (2*PI * (2*i) * threadID) / bigN; //Calculates the even factor for Cos() and Sin()
															 //*********Reduces computational time*********

		double realPartEven = cos(factorEven); //COS part of the equation for the REAL PART
		double imagPartEven = -1 * sin(factorEven); //SIN part of the equation for the IMAG PART

		cuDoubleComplex wholePartEven = make_cuDoubleComplex(realPartEven, imagPartEven);// CREATES: realPartEven + imagPartEven * I
		cuDoubleComplex resultEven = cuCmul(evenFromTable, wholePartEven);				//MULTIPLIES the actual numberfrom table with the number created from COS and SIN
																					   //EX)     (2.6 + 1i) * (1 - 0)    ----> resultEven	
		sumOfEven = cuCadd(resultEven, sumOfEven); //finally... accumulate all the EVEN numbers up for later
		//==============================================================================

		//==========================ODD PART STARTS HERE================================
		cuDoubleComplex oddromTable = inNumbers[2 * i + 1];   // 2n + 1 gives all the odd numbers

		double factorOdd = (2*PI * (2*i + 1) * threadID) / bigN; //Calculates the odd factor for Cos() and Sin()
															    //*********Reduces computational time*********

		double realPartOdd = cos(factorOdd); //COS part of the equation for the REAL PART
		double imagPartOdd = -1 * sin(factorOdd); //SIN part of the equation for the IMAG PART

		cuDoubleComplex wholePartOdd = make_cuDoubleComplex(realPartOdd, imagPartOdd);// CREATES: realPartEven + imagPartEven * I
		cuDoubleComplex resultOdd = cuCmul(oddromTable, wholePartOdd);				//MULTIPLIES the actual numberfrom table with the number created from COS and SIN
																					   //EX)     (2.6 + 1i) * (1 - 0)    ----> resultOdd	

		sumOfOdd = cuCadd(resultOdd, sumOfOdd); //finally... accumulate all the EVEN numbers up for later
		//==============================================================================

	}
	outResults[threadID] = cuCadd(sumOfEven, sumOfOdd);
} 


int main()
{	
	double avgtime = 0;
	int h;
	FILE *outfile;
	outfile = fopen("ParallelVersionOutput.txt", "w"); //oepn from current directory

	for(h = 0;h < howmanytimesavg; h++ )
	{
		double start,finish; //For time
											
		cuDoubleComplex * tableValues = (cuDoubleComplex*) malloc(bigN * sizeof(cuDoubleComplex)); //allocate memeory to store table of signals
    	cuDoubleComplex * returnedFFT = (cuDoubleComplex*) malloc(bigN * sizeof(cuDoubleComplex)); //allocate memeory to store what kernal does
    	cuDoubleComplex * tableValuesd;  //device pointer
    	cuDoubleComplex * returnedFFTd; //device pointer

		//LOAD FIRST 8 VALUES OF TABLE UP
		tableValues[0] = make_cuDoubleComplex(3.6, 2.6); // 3.6 + 2.6i
		tableValues[1] = make_cuDoubleComplex(2.9, 6.3); // 2.9 + 6.3i
		tableValues[2] = make_cuDoubleComplex(5.6, 4.0); // ...
		tableValues[3] = make_cuDoubleComplex(4.8, 9.1); // ...
		tableValues[4] = make_cuDoubleComplex(3.3, 0.4); // ... 
		tableValues[5] = make_cuDoubleComplex(5.9, 4.8); // ...
		tableValues[6] = make_cuDoubleComplex(5.0, 2.6); // ...
		tableValues[7] = make_cuDoubleComplex(4.3, 4.1); // 4.3 + 4.1i

		//EVERYTHING AFTER ROW 8 IS 0
		if(bigN > 8)
		{
			for(int i = 8; i < bigN; i++)
			{
				tableValues[i] = make_cuDoubleComplex(0, 0); 
			}
		}

		//allocate memory on the GPU for table of values & what the FFT will return'
		double memorySize = bigN * sizeof(cuDoubleComplex);
		cudaMalloc((void **)&tableValuesd, memorySize);
		cudaMalloc((void **)&returnedFFTd, memorySize);

		//copy the table from Host to GPU, so that the GPU can perfom FFT
		cudaMemcpy(tableValuesd, tableValues, memorySize, cudaMemcpyHostToDevice);

		GET_TIME(start); //start the timer
		// HOW MANY TIMES DO I NEED TO CALL KERNAL????????????
		for(int r = 0; r < bigN / (numBlocks * numThreadsPerBlockx); r++){
			dim3 dimGrid( numBlocks ,1); //Set up Grid for this run
			dim3 dimBlock(numThreadsPerBlockx,1); //Set up Blocks for this run
			KernalFFT<<<dimGrid, dimBlock>>>(tableValuesd, returnedFFTd); //call kernal....passing it the table & where to store FFT results
			cudaDeviceSynchronize();
		}
		GET_TIME(finish); //stop timer

		//GET THE RESULT FROM THE KERNAL
		cudaMemcpy(returnedFFT, returnedFFTd, memorySize, cudaMemcpyDeviceToHost);

		//FREE MEMORY ON THE GPU...
		cudaFree(tableValuesd); 
		cudaFree(returnedFFTd);

		//Print the first 8 K's
		fprintf(outfile," \n\nTOTAL PROCESSED SAMPLES : %d\n",bigN);
		for(int i = 0; i < howmanytoprint; i++){
			fprintf(outfile,"================================\n");
			fprintf(outfile,"Xreal[%d]: %.4f Ximag[%d]: %.4fi\n",i, cuCreal(returnedFFT[i]), i, cuCimag((returnedFFT[i])));
			fprintf(outfile,"================================\n");

		}
	//end iteration loop	
		double timeElapsed = finish-start; //Time for that iteration
		avgtime = avgtime + timeElapsed; //AVG the time 
		fprintf(outfile,"Time Elaspsed on Iteration %d: %f Seconds\n", (h+1),timeElapsed);
		cudaFree(tableValues);
		cudaFree(returnedFFT);	
	}
	avgtime = avgtime / howmanytimesavg;
	fprintf(outfile,"\nAverage Time Elaspsed: %f Seconds", avgtime);
	fclose(outfile); //close file
	return 0;
}