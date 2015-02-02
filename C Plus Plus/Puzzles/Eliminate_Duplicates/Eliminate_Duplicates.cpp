// Eliminate_Duplicates.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	char str[] = "010203040103030203040402040204010203010301002303040204030203023232341";

	char *a;
	char *b;
	char *c;
	a = str;

	while (*(a + 1) != 0)
	{
		b = a + 1;
		while (*b != 0)
		{
			if (*a == *b)
			{
				c = b;
				do
				{
					*c = *(c + 1);
					c++;
				} while (*c != 0);
				b--;
			}
			b++;
		}
		a++;
	}


	//int len = 0;
	//char tmp;
	//while (str[len] != 0) len++;
	//
	//for (int i = 0; i < len - 1; i++)
	//{
	//	for (int j = i + 1; j < len; j++)
	//	{
	//		if (str[i] == str[j])
	//		{
	//			for (int k = j; k < len; k++)
	//				str[k] = str[k + 1];
	//			len--;
	//			j--;
	//		}
	//	}
	//}	

	cout << str << endl;

	cout << "Termine." << endl;
	getchar();
	return 0;
}

