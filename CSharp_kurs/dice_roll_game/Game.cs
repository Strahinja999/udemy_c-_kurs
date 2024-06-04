using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dice_roll_game;
public class Game
{
    private readonly Dice _dice1;
    public Game(Dice dice1)
    {
        _dice1 = dice1;
    }

    public void Play()
    {
        //TREBA DA SE IZBEGNE TAKOZVANI MAGIC NUMBER PROBLEM
        const int NumOfTries = 3;
        for (int i = 0; i < NumOfTries; i++)
        {
            Console.WriteLine("Enter your guest: ");
            string userInput = Console.ReadLine();
            int userNumber = int.Parse(userInput);
            if (userNumber == _dice1.Number)
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
    }
}
