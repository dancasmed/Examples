// Multiply.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	int a = 351;// std::numeric_limits<int>::max();
	int b = 61;// std::numeric_limits<int>::max();
	int res = 0;
	int t = a;


	if (a<b)
	{
		a = b;
		b = t;
	}
	cout << a << " * " << b << " = "<<a*b<<endl;

	while (b > 1)
	{
		if ((b & 1) == 1)
		{
			res += a;
		}
		b >>= 1;
		a <<= 1;
		cout << "a=" << a << " b=" << b << " res=" << res<< endl;
	}
	if (b & 1 == 1)
	{
		res += a;
	}

	cout<< "res="<<res << endl;
	cout << "Termine." << endl;
	getchar();
	return 0;
}

