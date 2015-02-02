// BubbleSort.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	char str[] = "3217980743289721374973987497901993478132102";

	int len = 0;
	char tmp;
	while (str[len] != 0) len++;

	while (len > 1){
		for (int i = 0; i < len - 1; i++)
		{
			if (str[i] > str[i + 1])
			{
				tmp = str[i];
				str[i] = str[i + 1];
				str[i + 1] = tmp;
			}
		}
		len--;
	}

	cout << str << endl;
	cout << "Termine." << endl;
	getchar();
	return 0;
}

