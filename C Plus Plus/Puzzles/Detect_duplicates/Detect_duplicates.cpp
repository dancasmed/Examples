// Dos.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	//Busca duplicados
	char str[] = "123456788";
	bool duplicado = false;
	char *a, *b;
	a = str;
	while (*a != 0 && !duplicado)
	{
		b = a + 1;
		while (*b != 0)
		{
			if (*a == *b)
			{
				duplicado = true;
				break;
			}
			b++;
		}
		a++;
	}

	cout << "Duplicado: " << duplicado << endl;
	cout << "Termine." << endl;
	getchar();
	return 0;
}

