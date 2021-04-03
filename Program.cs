using System;
using System.Collections.Generic;


namespace CLI_Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstThrow;
            int secondThrow;
            int thirdThrow;
            int finalScore;


            while(true)
            {
                // Initialise the game menu
                Console.WriteLine("- D - A - R - T - S -");
                Console.WriteLine("Checkout on doubles only!\n");
                Player player = new Player(ReadString("Enter your name:"), Skill.Beginner);
                Console.WriteLine();
                player.playerSkill = SkillSelector();
                Console.Clear();

                while (true)
                {
                    int currentScore = 141;
                    int rounds = 0;

                    while(currentScore>0)
                    {
                        Console.WriteLine("- D - A - R - T - S -\n");
                        Console.WriteLine("Player: " + player.name);
                        Console.WriteLine("Skill: " + player.playerSkill);
                        Console.WriteLine("Your remaining score is: " + currentScore + " \n");

                        firstThrow = ThrowGenerator(BoardTarget(), player.playerSkill, ReadValue("What number are you aiming at?", 1, 20), currentScore);
                        currentScore -= firstThrow;
                        if (currentScore == 0)
                        {
                            //The player has won the game
                            Console.WriteLine("You threw " + firstThrow);
                            Console.WriteLine();
                            rounds++;
                            break;
                        }
                        Console.WriteLine("You threw " + firstThrow + " \n");

                        secondThrow = ThrowGenerator(BoardTarget(), player.playerSkill, ReadValue("What number are you aiming at?", 1, 20), currentScore);
                        currentScore -= secondThrow;
                        if (currentScore == 0)
                        {
                            Console.WriteLine("You threw " + secondThrow);
                            Console.WriteLine();
                            rounds++;
                            break;
                        }
                        Console.WriteLine("You threw " + secondThrow + " \n");

                        thirdThrow = ThrowGenerator(BoardTarget(), player.playerSkill, ReadValue("What number are you aiming at?:", 1, 20), currentScore);
                        currentScore -= thirdThrow;
                        if (currentScore == 0)
                        {
                            Console.WriteLine("You threw " + thirdThrow);
                            Console.WriteLine();
                            rounds++;
                            break;
                        }
                        Console.WriteLine("You threw " + thirdThrow + " \n");

                        finalScore = firstThrow + secondThrow + thirdThrow;
                        RoundScore(finalScore);

                        Console.WriteLine("");
                        Console.WriteLine("PRESS ENTER TO GO TO NEXT ROUND");
                        Console.ReadLine();
                        Console.Clear();
                        rounds++;
                    }
                    Console.Clear();
                    Console.WriteLine("Congratulations!\nIt took you " + rounds + " rounds to win. \n");

                    var replay = ReadString("Would you like to play again? Y/N");
                    if (replay.ToLower() == "y")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (replay.ToLower() == "n")
                    {
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        static int ReadValue(string prompt, int low, int high)
        {
            int result = 0;
            do
            {
                Console.WriteLine(prompt);
                string resultString = Console.ReadLine();
                result = Convert.ToInt32(resultString);
            }
            while ((result < low) || (result > high));
            return result;
        }

        static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            string name = Console.ReadLine();
            return name;
        }

        public static Skill SkillSelector()
        {
            int i = ReadValue("Choose your skill:\n1. Beginner\n2. Novice\n3. Professional\n4. Expert", 1, 4);
            i--;
            string iString = i.ToString();
            Skill level = (Skill)Enum.Parse(typeof(Skill), iString);
            return level;
        }

        public static BoardArea BoardTarget()
        {
            int i = ReadValue("Where are you aiming?\n1. Single\n2. Double\n3. Triple\n4. Outer Bull (25)\n5. Inner Bull (50)\n", 1, 5);
            i--;
            string iString = i.ToString();
            BoardArea target = (BoardArea)Enum.Parse(typeof(BoardArea), iString);
            return target;
        }

        public static int ThrowGenerator(BoardArea boardtarget, Skill playerSkill, int target, int currentScore)
        {
            var random = new Random();
            int skill = Convert.ToInt32(playerSkill);
            int boardarea = Convert.ToInt32(boardtarget);
            int boardmultiplier;
            int finalshot = 0;
            int misschance = random.Next(0, 3);

            switch (skill)
            {
                case 0:
                    if (misschance == 0)
                        return 0;
                    else if (misschance == 1)
                    {
                        boardarea = random.Next(0, 6);
                        break;
                    }
                    finalshot = (random.Next(0, 20))*(random.Next(0, 4));
                    boardarea = 5;
                    break;
                case 1:
                    if (skill >= random.Next(0, 4))
                        break;
                    boardarea = random.Next(0, 6);
                    break;
                case 2:
                    if (skill >= random.Next(0, 4))
                        break;
                    boardarea = random.Next(0, 6);
                    break;
                case 3:
                    if (skill >= random.Next(0, 4))
                        break;
                    boardarea = random.Next(0, 6);
                    break;
            }

            switch (boardarea)
            {
                case 0:
                    boardmultiplier = 1;
                    finalshot = target * boardmultiplier;
                    break;
                case 1:
                    boardmultiplier = 2;
                    finalshot = target * boardmultiplier;
                    break;
                case 2:
                    boardmultiplier = 3;
                    finalshot = target * boardmultiplier;
                    break;
                case 3:
                    finalshot = 25;
                    break;
                case 4:
                    finalshot = 50;
                    break;
                case 5:
                    break;
            }

            currentScore -= finalshot; //check to see if the shot reduces the remaining score to zero

            if (currentScore > 0)
            {
                return finalshot;
            }

            else if (currentScore == 0)
            {
                if (boardarea == 1)
                {
                    return finalshot;
                }
                else
                {
                    finalshot = 0;
                    return finalshot;
                }
            }

            else
            {
                finalshot = 0;
                return finalshot;
            }
        }

        static int RoundScore(int finalScore)
        {
            if (finalScore == 180)
            {
                Console.WriteLine();
                Console.WriteLine("ONE HUNDRED AND EIGHTY! \n");
                return 1;
            }
            else if (finalScore == 0)
            {
                return 1;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Your round score is: " + finalScore);
                return 1;
            }
        }
    }
}
