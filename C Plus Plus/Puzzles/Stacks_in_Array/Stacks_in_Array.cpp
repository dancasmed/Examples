// Stacks_in_Array.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

class Stack_Manager
{
private:
	int total_size = 100;
	int total_stacks = 3;
	int stack_size = total_size / total_stacks;
	int **stack_details;

	int *buffer;
public:
	Stack_Manager(int stacks)
	{
		buffer = new int[total_size];
		
		total_stacks = stacks;
		stack_size = total_size / total_stacks;

		stack_details = new int*[total_stacks];

		int tmp = 0;
		for (int i = 0; i < total_stacks; i++)
		{
			stack_details[i] = new int[3]; //0 start 1 end 2 size
			stack_details[i][0] = tmp;
			stack_details[i][2] = 0;
			tmp += stack_size;
			if (i != total_stacks - 1)
			{
				stack_details[i][1] = tmp - 1;
			}
			else
			{
				stack_details[i][1] = total_size - 1;
			}
		}
	}
	int Push(int stack, int value)
	{
		int res = 0;
		if (stack > total_stacks)
		{
			res = 1;
		}
		else
		{
			if (stack_details[stack - 1][0] + stack_details[stack - 1][2] <= stack_details[stack - 1][1])
			{
				buffer[stack_details[stack - 1][0] + stack_details[stack - 1][2]] = value;
				stack_details[stack - 1][2]++;
			}
			else
				res = 1;
		}
		return res;
	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	Stack_Manager s = Stack_Manager(10);
	for(int i=0; i<34; i++)
		s.Push(3, i);
	

	cout << "Termine." << endl;
	getchar();
	return 0;
}

