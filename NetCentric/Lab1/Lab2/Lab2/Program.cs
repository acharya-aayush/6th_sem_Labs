using System;

/*
Lab 2 - Net Centric Programming Questions:

Q1: Write a program to find the factorial of a given number using the concept of delegate.

Q2: Write a program to demonstrate the custom event. Scenario is to iterate through the 10000 times, 
    Whenever it reaches the iteration divisible by 5, it should display the progress in percentage 
    the number of iterations completed.

Q3: Create a Class Quadratic having a, b, c, x1, and x2 as instance variables. Create a function name 
    Input (no parameter and no return type) to take the user input for a, b, and c. Then create another 
    function named double[] Calculate() to calculate two roots and assign to variables x1 and x2 and 
    return these two roots to the main method. Create another class Imain having main() function to 
    create an object of Quadratic class and invoke the function.

Q4: Create a class Student having instance variable age and name and class also contains a function 
    name void input() for user input age and name. Then create another class Imain and create an array 
    of size 5 of Student then store the Student in array and print those records of array whose age 
    is greater than or equal to 24.

Q5: Create a class Time with three integer member variables hr,min,sec. The class also contains the 
    method Time Sum(Time t1,Time t2) method that will return the sum of t1 and t2. Create a class 
    TimeDemo with main method that will create an object of Time and to invoke the Sum function and 
    print the added time. Output: t1→5:40:40 t2→4:40:50 Total Sum t3→10:21:30

Q6: Write a program to read a file from input.txt then copy the content of input.txt to output.txt.

Q7: Write a program to read a file from Input.txt then display those words which end with the 
    character 'g'. Example: Programming, Gurung, programming

Q8: Create an interface called ICalculator which has methods int add(int x,int y) and int diff(int x,int y) 
    to perform addition and subtraction of numbers passed as arguments. Then define a class that implements 
    interface ICalculator.

Q9: Create an interface Shape which method get() and display(). Create two classes Rectangle and Square 
    which implements this interface. Defines the member variable of these classes as per requirement in 
    class itself. Create some instances of Rectangle and Square classes and demonstrate interface 
    implementation by classes.

Q10: Create an abstract class called Vehicle with an abstract method startEngine() and a non-abstract 
     method stopEngine(). Derive a concrete class Airplane from Vehicle, having instance variables such 
     as model, manufacturer, and maxCapacity. The Airplane class should implement the abstract startEngine() 
     method with appropriate logic for starting an aircraft engine. Additionally, provide concrete 
     implementations for methods like takeOff() and land().

Q11: Create a class Employee which contains the properties like ID, Name, Address and Salary. Create 
     another class Imain then print all the employees whose salary is greater than 40000 using the 
     concept of Linq Query.

Q12: Create an array of Integer of size n then enter the element in array and find the sum of odd 
     numbers of array elements using the concept of Lambda Expression.
*/

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"Lab 2 Menu:
1-Factorial 2-Event 3-Quadratic 4-Student 5-Time 6-File
7-Words 8-Calc 9-Shape 10-Vehicle 11-Employee 12-Lambda 0-Exit
Choice: ");
                
                if (int.TryParse(Console.ReadLine(), out int c))
                {
                    Console.Clear();
                    switch (c)
                    {
                        case 0: return;
                        case 1: q1.Run(); break;
                        case 2: q2.Run(); break;
                        case 3: q3.Run(); break;
                        case 4: q4.Run(); break;
                        case 5: q5.Run(); break;
                        case 6: q6.Run(); break;
                        case 7: q7.Run(); break;
                        case 8: q8.Run(); break;
                        case 9: q9.Run(); break;
                        case 10: q10.Run(); break;
                        case 11: q11.Run(); break;
                        case 12: q12.Run(); break;
                        default: Console.WriteLine("Invalid!"); Console.ReadKey(); continue;
                    }
                    if (c > 0) Console.ReadKey();
                }
            }
        }
    }
}
