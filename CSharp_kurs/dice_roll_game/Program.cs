using dice_roll_game;

Dice _dice = new Dice();
//Console.WriteLine(_dice.Number);
Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");

for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Enter your guest: ");
    string userInput = Console.ReadLine();
    int userNumber = int.Parse(userInput);
    if (userNumber == _dice.Number)
    {
        Console.WriteLine("You win");
        return;
    }
    else
    {
        Console.WriteLine("Wrong number");
    }
}
Console.WriteLine("You lose");

