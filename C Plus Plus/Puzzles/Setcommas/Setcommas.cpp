// Setcommas.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "string.h"

char* setCommas(char* input)
{
	int index_start = (strlen(input) % 3); //Calculates where must be the first comma
	int commas = strlen(input) / 3;//Calculates the number of commas requires
	char* res = new char[strlen(input) + commas +1];//Creates a resulto with space for the commas
	res[strlen(input) + commas] = '\0';//Put the end of the result string
	int res_index = 0;
	for (int i = 0; i < strlen(input); i++, res_index++)
	{
		if ((i == index_start) || (i - index_start >0 && (i - index_start) % 3 == 0))
		{
			res[res_index] = ',';
			res_index++;
		}		
		res[res_index] = input[i];
		
	}
	return res;
}

int _tmain(int argc, _TCHAR* argv[])
{
	char* test = "1000000";
	setCommas(test);
	return 0;
}

