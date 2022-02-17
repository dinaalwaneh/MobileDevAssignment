using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Assignment_1
{

    public class LargestDegit
    {
        public int GetLargestDegit()
        {
            int degit = 0, largestDegit = 0;
            Console.Write("Enter the number you want plz :");
            degit = Convert.ToInt32(Console.ReadLine());

            while (degit != -1)
            {
                if (degit > largestDegit)
                {
                    largestDegit = degit;
                }
                Console.Write("Enter the number you want plz (Ps: enter -1 to ending the process) :");
                degit = Convert.ToInt32(Console.ReadLine());
            }
            return largestDegit;
        }}

    public class ReverseDegit
    {
        public int GetReverseDegit(int digit)
        {
            int reversedDegit = 0 , remainder;
            while (digit != 0)
            {
                remainder = digit % 10;
                reversedDegit = reversedDegit * 10 + remainder;
                digit /= 10;
            }
            return reversedDegit;
        }
    }

    public class DigitAnalyzer
    {
        public int GetLargestDigit(int digit)
        {

            int largestDigit = 0, remainder;
            while (digit != 0)
            {
                remainder = digit % 10;
                if (largestDigit < remainder)
                {
                    largestDigit = remainder;
                }
                digit /= 10;
            }
            return largestDigit;
        }
    }

    public class TextAnalyzer
    {

        public string GetFirstDigit(string text)
        {
            string firstDegit = "";
            for (int index = 0; index < text.Length; index++)
            {
                if (text[index] >= '0' && text[index] <= '9')
                {
                    firstDegit += text[index];
                    if ((index + 1 != text.Length) && (text[index + 1] < '0' || text[index + 1] > '9'))
                    {

                        break;
                    }
                }
            }
            return firstDegit;
        }
    }

    public class Operation
    {
        public static void Main()
        {
            //List of operation : 
            Console.Write("\n\n");
            Console.Write("\t This is a list of your available operations :) \n");
            Console.Write("----------------------------------------------------------------\n");
            Console.Write("1. Find Largest Number Among given numbers by users : \n");
            Console.Write("2. reverse a given number : \n");
            Console.Write("3. find the largest digit of a number : \n");
            Console.Write("4. search for the first int number inside a given text by user : \n");
            Console.Write("----------------------------------------------------------------\n");
            Console.Write("\n\n");


            Console.Write("Enter your choice plz :");
            int choice = Convert.ToInt32(Console.ReadLine()); 
            
            while (choice != -1)
            {
                switch (choice)
                {
                    case 1:
                        int largestDegit_;
                        LargestDegit _largestDegit = new LargestDegit();
                        largestDegit_ = _largestDegit.GetLargestDegit();
                        Console.WriteLine("The largest number you entered = "+largestDegit_);
                        Console.Write("\n----------------------------------------------------------------\n\n");
                        break;
                    
                    case 2:
                        int degit_ , reverseNumber;
                        ReverseDegit reverseDegit = new ReverseDegit();
                        Console.Write("Enter the Degit you wants : ");
                        degit_ = Convert.ToInt32(Console.ReadLine());
                        reverseNumber = reverseDegit.GetReverseDegit(degit_);
                        Console.WriteLine("The reversed of degit you entered = " +reverseNumber);
                        Console.Write("\n----------------------------------------------------------------\n\n");
                        break;

                    case 3:
                        DigitAnalyzer digitAnalyzer = new DigitAnalyzer();
                        int largestDegit, degit;
                        Console.Write("Enter the Degit you wants : ");
                        degit = Convert.ToInt32(Console.ReadLine());
                        largestDegit = digitAnalyzer.GetLargestDigit(degit);
                        Console.WriteLine("The largest degit among number you entered = "+ largestDegit);
                        Console.Write("\n----------------------------------------------------------------\n\n");
                        break;

                    case 4:
                        TextAnalyzer textAnalyzer = new TextAnalyzer();
                        string text ="" , firstDegit;
                        Console.Write("Enter the text you wants : ");
                        text = Console.ReadLine();
                        firstDegit = textAnalyzer.GetFirstDigit(text);
                        Console.WriteLine("The first degit among the text you entered = " + firstDegit);
                        Console.Write("\n----------------------------------------------------------------\n\n");
                        break;

                    default:
                        Console.WriteLine("No match found");
                        Console.Write("\n----------------------------------------------------------------\n\n");
                        break;
                }

                Console.Write("Enter your choice plz (Ps: enter -1 to ending the process) :");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            
           
            Console.ReadKey();

        }}}
