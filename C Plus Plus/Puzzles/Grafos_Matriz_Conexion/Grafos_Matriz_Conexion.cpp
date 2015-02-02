// Grafos_Matriz_Conexion.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

class Grafo
{
private:
	int **matrix;
	int num_nodes;
public:
	Grafo(int nodes)
	{
		num_nodes = nodes;
		matrix = new int*[num_nodes];
		for (int i = 0; i < num_nodes; i++)
		{
			matrix[i] = new int[num_nodes];
			for (int j = 0; j < num_nodes; j++)
			{
				matrix[i][j] = 0;
			}
		}

	}
	void Connect_Nodes(int a, int b)
	{
		a--;
		b--;
		matrix[a][b] = 1;
		matrix[b][a] = 1;
	}

	void Print_Matrix()
	{
		for (int i = 0; i < num_nodes; i++)
		{
			for (int j = 0; j < num_nodes; j++)
			{
				cout << matrix[i][j];
			}
			cout << endl;
		}
		cout << endl;
	}

	void multiply()
	{
		int **m;
		m = new int*[num_nodes];
		for (int i = 0; i < num_nodes; i++)
		{
			m[i] = new int[num_nodes];
			for (int j = 0; j < num_nodes; j++)
			{
				int v = 0;
				for (int k = 0; k < num_nodes; k++)
				{
					v += matrix[i][k] * matrix[k][j];
				}
				m[i][j] = v;
			}
		}

		for (int i = 0; i < num_nodes; i++)
		{
			for (int j = 0; j < num_nodes; j++)
			{
				cout << m[i][j];
			}
			cout << endl;
		}
		cout << endl;

	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	Grafo g = Grafo(6);
	g.Connect_Nodes(1, 2);
	g.Connect_Nodes(1, 5);
	g.Connect_Nodes(2, 3);
	g.Connect_Nodes(2, 5);
	g.Connect_Nodes(3, 4);
	g.Connect_Nodes(5, 4);
	g.Connect_Nodes(4, 6);
	g.Print_Matrix();
	cout << endl;
	g.multiply();
	cout << "Termine." << endl;
	getchar();
	return 0;
}

