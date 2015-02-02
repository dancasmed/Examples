// Anagrams.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;
int _tmain(int argc, _TCHAR* argv[])
{
	bool anagram = false;
	char str1[] = "uno";
	char str2[] = "uon";
	char *a, *b, tmp = 0;
	a = str1;
	b = str2;
	while (*a != 0 || *b != 0)
	{
		tmp^= *a^*b;
		a++;
		b++;
	}

	if (*a == 0 && *b == 0 && tmp == 0)
		anagram = true;
	cout << "Anagram: " << anagram << endl;
	cout << "Termine." << endl;
	getchar();
	return 0;
}

