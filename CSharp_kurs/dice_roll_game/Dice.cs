using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dice_roll_game;
public class Dice
{
    public int Number { get; }
    private readonly int SidesCount = 6;
    public Dice()
    {
        Number = new Random().Next(1,SidesCount + 1);
    }
}
