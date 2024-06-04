using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dice_roll_game;
public class Dice
{
    public int Number { get; }
    public Dice()
    {
        Number = new Random().Next(1,7);
    }
}
