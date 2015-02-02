// Print_Permutations_in_Order.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

char* Sort(char *str, int start, int end)
{
	int len = end - start + 1;
	while (len > 1)
	{
		for (int i = 0+start; i < len+start - 1; i++)
		{
			if (str[i]>str[i + 1])
			{
				int tmp = str[i];
				str[i] = str[i + 1];
				str[i + 1] = tmp;
			}
		}
		len--;
	}
	return str;
}

int _tmain(int argc, _TCHAR* argv[])
{
	char str[] = "daniel castro";
	int len = 0;
	int per = 1;
	char tmp = 0;	
	while (str[len] != 0) len++;
	for (int i = 2; i <= len; i++)
		per *= i;
	cout << "Original string: "<<str << endl;	
	Sort(str,0,len-1);	
	cout <<"1\t:"<< str << endl;
	
	int i = 2;
	while (true)
	{
		int k = len-2;
		while (k >= 0 && str[k]>=str[k+1]) k--;
		if (k < 0)
			break;

			int l = k + 1;
			for (int j = k + 1; j < len; j++)
			{
				if (str[l]>str[j] && str[j] > str[k])
					l = j;
			}
			tmp = str[k];
			str[k] = str[l];
			str[l] = tmp;
			Sort(str, k + 1, len - 1);
			cout << str << endl;
		
		i++;
	}
	getchar();
	return 0;
}

