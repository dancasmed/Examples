// Rotate_Matrix.cpp : Defines the entry point for the console application.
//Rotates a matrix 90 degrees

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	char **mat;
	int size = 3;
	mat = new char*[size];
	for (int i = 0; i < size; i++)
	{
		mat[i] = new char[size * 4];
		for (int j = 0; j < size; j++)
		{
			mat[i][j * 4] = j + 48 + (i * size);
			mat[i][(j * 4) + 1] = j + 48 + (i * size);
			mat[i][(j * 4) + 2] = j + 48 + (i * size);
			mat[i][(j * 4) + 3] = j + 48 + (i * size);
			mat[i][(j * 4) + 4] = 0;
		}
	}
	
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size * 4; j++)
		{
			if (j == 0)
				cout << "(";
			else if (j % 4 == 0)
				cout << ")(";
			cout << mat[i][j];
		}
		cout << ")" << endl;
	}
	cout << endl << "Rotated 90 degrees."<<endl<<endl;
	for (int i = size-1; i >= 0; i--)
	{
		for (int j = (size * 4)-1; j >=0; j--)
		{
			if (j == (size * 4) - 1)
				cout << "(";
			else if ((j+1) % 4 == 0)
				cout << ")(";
			cout << mat[i][j];
		}
		cout << ")" << endl;
	}

	cout << "Termine." << endl;
	getchar();
	return 0;
}

