using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Evaluator
{
    class Program
    {
        static int EXAMS = 1;
        static int STUDENTS = 1;

        static string[,] Students_Answers;
        static string[] Exams_Correct_Answers;
        static int[,] Students_Correct_Answers;

        static void Main(string[] args)
        {

            Students_Answers = new string[EXAMS, STUDENTS];
            Exams_Correct_Answers = new string[EXAMS];
            Students_Correct_Answers = new int[STUDENTS, EXAMS];

            Console.WriteLine("Enter the CORRECT answers per exam. Example: AABBDAC");
            for (int i = 0; i < EXAMS; i++)
            {
                Console.WriteLine("Exam " + (i + 1).ToString());
                Exams_Correct_Answers[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the Exam answers per student. Example: AABCCAD");
            for (int i = 0; i < EXAMS; i++)
            {
                for (int j = 0; j < STUDENTS; j++)
                {
                    Console.WriteLine("Examen " + (i + 1).ToString() + " Student " + (j + 1).ToString());
                    Students_Answers[i, j] = Console.ReadLine();

                    //Evaluate the answers
                    int correct_answers = 0;
                    for (int k = 0; k < Exams_Correct_Answers[i].Length && k < Students_Answers[i, j].Length; k++)
                    {
                        if (Exams_Correct_Answers[i][k] == Students_Answers[i, j][k])
                        {
                            correct_answers++;
                        }
                    }
                    Students_Correct_Answers[j, i] = correct_answers;
                }
            }

            Console.WriteLine("Printing exams results per student");
            for (int i = 0; i < STUDENTS; i++)
            {
                Console.WriteLine("Student " + (i + 1).ToString());
                for (int j = 0; j < EXAMS; j++)
                {
                    Console.WriteLine("Exam: " + (j + 1).ToString() + " " + Students_Correct_Answers[i, j] + " of " + Exams_Correct_Answers[j].Length.ToString());
                }
            }
            Console.WriteLine("Finish.");
            Console.ReadKey();
        }
    }
}
