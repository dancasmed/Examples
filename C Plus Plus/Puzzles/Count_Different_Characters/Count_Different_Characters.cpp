// Count_Different_Characters.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	char str[] = "aurelio";

	char *a = str;
	int chrs[256];
	for (chrs[0] = 0; chrs[0] < 256; chrs[0]++)
		chrs[chrs[0]] = 0;

	while (*a != 0)
		chrs[(*a >= 'A' && *a <= 'Z' ? 'a' - 'A' + *(a++) : *(a++))]++;

	for (chrs[0] = 0; chrs[0] < 256; chrs[0]++)
	{
		if (chrs[chrs[0]] != 0)
			cout << "'" << (char)chrs[0] << "' " << chrs[chrs[0]] << endl;
	}
	cout << "Termine." << endl;
	getchar();
	return 0;
}

