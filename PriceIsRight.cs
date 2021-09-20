using System;

namespace PriceIsRight
{
    class PriceIsRight
    {
        int spin1;
        int spin2;
        int spin3;
        int total;
        int p1;
        int p2;
        int p3;
        String response;
        Random random = new Random();


        public PriceIsRight()
        {
            spin1 = 0;
            spin2 = 0;
            spin3 = 0;
            total = 0;
            p1 = 0;
            p2 = 0;
            p3 = 0;
            response = "";
        }

        public void Play()
        {
            // Play Game with 3 Players and determine winner after their two spins each
            for (int i = 0; i < 1; i++)
            {
                p1 = Spin();
                p2 = Spin();
                p3 = Spin();
                Console.WriteLine("Player One's Score: " + p1 + "\n" +
                                  "Player Two's Score: " + p2 + "\n" +
                                  "Player Three's Score: " + p3 + "\n");

                if (p1 > p2)
                {
                    if (p1 > p3)
                    {
                        Console.WriteLine("Congrats, Player 1 WINS!" + "\n");
                    } else
                    {
                        Console.WriteLine("Congrats, Player 3 WINS!" + "\n");
                    }
                } 
                else if (p2 > p3)
                    Console.WriteLine("Congrat, Player 2 WINS!" + "\n");
                else 
                    Console.WriteLine("Congrats, Player 3 WINS!" + "\n");
            }

            // Determine which players are rewarded with bonus spin
            if(p1 == 100)
            {
                Console.WriteLine("Player 1");
                ExtraSpin();
            }
            if (p2 == 100)
            {
                Console.WriteLine("Player 2");
                ExtraSpin();
            }
            
            if (p3 == 100)
            {
                Console.WriteLine("Player 3");
                ExtraSpin();
            }
        }


        // Bonus Spin method
        public void ExtraSpin()
        {
            spin3 = random.Next(5, 100 / 5 + 1) * 5;
            
            if (spin3 == 100)
            {
                Console.WriteLine("Extra Spin is: " + spin3 + "  Congrats, you WIN 25,000");
            } else if (spin3 == 5 || spin3 == 15)
            {
                Console.WriteLine("Extra Spin is: " + spin3 + "  Congrast, you WIN 15,000");
            }

            Console.WriteLine("Extra Spin is: " + spin3 + "  Sorry, the Price is Wrong. No extra bonus Cash!");
        }

        public int Spin()
        {
            // Spin for each Player and ask if they want a second spin or not
            spin1 = random.Next(5, 100 /5 + 1) * 5;
            Console.WriteLine("Your first spin was: " + spin1);

            Console.WriteLine("Do you want to spin again? Type Yes or No");
            response = Console.ReadLine();

            if (response == "Yes" || response == "yes" || response == "YES" || response == "y")
            {
                spin2 = random.Next(5, 100 / 5 + 1) * 5;
                Console.WriteLine("Your second spin was: " + spin2);
            } else if (response == "No" || response == "no" || response == "n" || response == "NO")
            {
                spin2 = 0;
            }

            total = spin1 + spin2;
            Console.WriteLine("Your total was: " + total + "\n");
            
            // reset a players score and eliminate them if they go over price
            if (total > 100)
            {
                total = 0;
                Console.WriteLine("Sorry, you went over. The Price is Wrong!" + "\n");
            }
            return total;
        
        }
        
        // reset method to start a new game
        public void Reset()
        {
            spin1 = 0;
            spin2 = 0;
            spin3 = 0;
            p1 = 0;
            p2 = 0;
            p3 = 0;
            response = "";
            total = 0;
        }

        public static void Main(string[] args)
        {
            PriceIsRight program = new PriceIsRight();
            program.Play();

            String answer;
            Console.WriteLine("Do you want to play again? Type Yes or No");
            answer = Console.ReadLine();
            if (answer == "no" || answer == "No" || answer == "NO" || answer == "n")
            {
                Environment.Exit(0);
            }

            do
            {
                program.Reset();
                program.Play();
                Console.WriteLine("Do you want to continue playing? Type Yes or No");
                answer = Console.ReadLine();
                if (answer == "no" || answer == "No" || answer == "NO" || answer == "n")
                {
                    Environment.Exit(0);
                }
            } while (answer != "no" || answer != "No" || answer != "NO" || answer != "n");

        }
    }
}
