// Zero_Matrix.cpp : Defines the entry point for the console application.
// put in zero row and column where a 0 is found in the source matrix

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int n = 9;
	int m = 13;
	int **mat;
	int **res;

	mat = new int*[n];
	res = new int*[n];

	for (int i = 0; i < n; i++)
	{
		mat[i] = new int[m];
		res[i] = new int[m];

		for (int j = 0; j < m; j++)
		{
			if ((i == 2 || i == 5) && (j == 6 || j == 1))
			{
				mat[i][j] = 0;
			}
			else
			{
				mat[i][j] = 1;
			}
			res[i][j] = mat[i][j];
			cout << mat[i][j];
		}
		cout << endl;
	}
	cout << endl << "Result:" << endl;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (mat[i][j] == 0)
			{
				for (int k = 0; k < m; k++)
				{
					res[i][k] = 0;
				}
				for (int k = 0; k < n; k++)
				{
					res[k][j] = 0;
				}
			}			
		}		
	}

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			cout << res[i][j];
		}
		cout << endl;
	}



	cout << "Termine.";
	getchar();
	return 0;
}

