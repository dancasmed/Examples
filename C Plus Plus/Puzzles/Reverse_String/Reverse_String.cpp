// Reverse_String.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;
int _tmain(int argc, _TCHAR* argv[])
{
	char str[] = "1234";
	int len = 0;
	char *a, *b, tmp;

	a = str;
	b = str;
	while (*b != 0) b++;
	b--;
	while (a < b)
	{
		tmp = *a;
		*a = *b;
		*b = tmp;
		a++;
		b--;
	}

	cout << str << endl;
	cout << "Termine." << endl;
	getchar();
	return 0;
}

