// Replace_Spaces.cpp : Defines the entry point for the console application.
//Replace spaces by %20

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	char str[] = "Hola mundo !";

	int spaces = 0;
	int len = 0;
	char *a, *b, *res;

	a = str;
	while (*a != 0)
	{
		if (*a == ' ')
		{
			spaces++;
		}
		len++;
		a++;
	}
	res = new char[len + (spaces * 3)];
	a = str;
	b = res;
	while (*a != 0)
	{
		if (*a == ' ')
		{
			*(b++) = '%';
			*(b++) = '2';
			*b = '0';
		}
		else
		{
			*b = *a;
		}
		a++;
		b++;
	}
	*b = 0;
	cout << "res: " << res << endl;
	cout << "Termine." << endl;
	getchar();
	return 0;
}

