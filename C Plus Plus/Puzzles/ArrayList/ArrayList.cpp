// ArrayList.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

class ArrayList
{
private:
	char *a, *b;
	int size;
	int count;

public:
	int x;

	ArrayList()
	{
		size = 0;
		count = 0;
		x = 0;
	}

	void add(char ch)
	{
		if (size == 0)
		{
			a = new char[1];
			a[0] = ch;
			size = 1;
			count = 1;
			
		}
		else
		{
			if (count == size)
			{
				b = new char[size * 2];
				for (int i = 0; i < size; i++)
				{
					b[i] = a[i];
					
				}
				size = size << 1;
				delete(a);
				a = b;
				x++;
			}
			a[count] = ch;
			count++;
		}

	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	ArrayList al = ArrayList();
	float f = 0;
	for (int i = 0; i < 100; i++){
		al.add('0' + 1);
		f = (100.0f/(i+1))*al.x;
		//if (i%1000==0)
		cout << i+1 << " : " << al.x <<" : "<<f<< endl;
	}
	
	cout << "Termine." << endl;
	getchar();
	return 0;
}

