Console.WriteLine("Hello!\r\nInput the first number:\r");
string firstInput  = Console.ReadLine();
int firstNumber = int.Parse(firstInput);
Console.WriteLine("Input the second number:");
string secondInput = Console.ReadLine();
int secondNumber = int.Parse(secondInput);
Console.WriteLine("What do you want to do with those numbers?\n[A]dd\n[S]ubtract\n[M]ultiply");
string userChoise = Console.ReadLine();
if(userChoise.ToLower() == "a")
{
    Console.WriteLine(firstNumber + " + " +  secondNumber + " = " + Add(firstNumber, secondNumber));
}else if (userChoise.ToLower() == "s")
{
    Console.WriteLine(firstNumber + " - " + secondNumber + " = " + Sub(firstNumber, secondNumber));
}
else if (userChoise == "m")
{
    Console.WriteLine(firstNumber + " * " + secondNumber + " = " + Mul(firstNumber, secondNumber));
}
else
{
    Console.WriteLine("Invalid input");
}
Console.WriteLine("Press any key to close");
Console.ReadKey();

int Add(int n1, int n2)
{
    return n1 + n2;
}
int Sub(int n1, int n2)
{
    return n1 - n2;
}
int Mul(int n1, int n2)
{
    return n1 * n2;
}
