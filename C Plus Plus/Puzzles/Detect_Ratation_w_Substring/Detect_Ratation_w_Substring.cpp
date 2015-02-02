// Detect_Ratation_w_Substring.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{

	char str1[] = "waterbottle";
	char str2[] = "erbottlewaty";

	char *a = str1;
	char *b = str2;
	bool flag = false;

	while (*a != *b) a++;

	while (*a == *b)
	{
		a++;
		b++;
	}
	if (*a == 0)
	{
		cout << "Substring? " << b<<endl;
	}

	cout << "Termine." << endl;
	getchar();
	return 0;
}

