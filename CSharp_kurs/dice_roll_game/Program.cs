using dice_roll_game;

Dice _dice = new Dice();
//Console.WriteLine(_dice.Number);
Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");

Game game = new Game(_dice);
game.Play();



