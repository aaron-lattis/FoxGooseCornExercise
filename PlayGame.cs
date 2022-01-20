using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxGooseCorn
{
    class PlayGame
    {

        public static bool play(FoxGooseCorn fox, FoxGooseCorn goose, FoxGooseCorn corn, FoxGooseCorn human)
        {

            bool continueGame = true;

            DisplayStatus(fox, goose, corn, human);

            Console.WriteLine();

            Console.Write("Would you like to bring something with you across the river? (f,g,c,a): ");

            string userInput = Console.ReadLine();

            Console.WriteLine();

            if (userInput == "f" && TwoItemsOnTheSameSide(fox, human))
            {
                fox.Move();
                human.Move();
            }
            else if (userInput == "g" && TwoItemsOnTheSameSide(goose, human))
            {
                goose.Move();
                human.Move();
            }
            else if (userInput == "c" && TwoItemsOnTheSameSide(corn, human))
            {
                corn.Move();
                human.Move();
            }
            else if (userInput == "a")
            {
                human.Move();
            }
            else
            {
                Console.WriteLine("Enter a letter representing an item to move that is currently on the same side as the human");
                Console.WriteLine();
            }


            if (TwoItemsLeftAlone(fox, goose, human))
            {
                DisplayStatus(fox, goose, corn, human);

                Console.WriteLine();

                Console.WriteLine("You have left the fox and the goose alone. The fox will eat the goose!");

                continueGame = false;
            }

            if (TwoItemsLeftAlone(goose, corn, human))
            {
                DisplayStatus(fox, goose, corn, human);

                Console.WriteLine();

                Console.WriteLine("You have left the goose and the corn alone. The goose will eat the corn!");

                continueGame = false;
            }

            if (fox.IsOnDestinationShore && goose.IsOnDestinationShore && corn.IsOnDestinationShore && human.IsOnDestinationShore)
            {
                DisplayStatus(fox, goose, corn, human);

                Console.WriteLine();

                Console.WriteLine("You have successfully crossed the river with all of your items intact!");

                continueGame = false;
            }

            return continueGame;
        }


        public static bool EndGame()
        {
            while(true)
            {
                Console.WriteLine();
                Console.Write("Would you like to play again? (y/n): ");

                string userInput = Console.ReadLine();

                Console.WriteLine();

                if (userInput == "y")
                    return true;

                else if (userInput == "n")
                    return false;
            }
        }


        private static bool TwoItemsLeftAlone(FoxGooseCorn item1, FoxGooseCorn item2, FoxGooseCorn human)
        {
            if (item1.IsOnStartingShore == true && item2.IsOnStartingShore == true && human.IsOnStartingShore == false)
                return true;

            if (item1.IsOnStartingShore == false && item2.IsOnStartingShore == false && human.IsOnStartingShore == true)
                return true;

            return false;
        }


        private static void DisplayStatus(FoxGooseCorn fox, FoxGooseCorn goose, FoxGooseCorn corn, FoxGooseCorn human)
        {
            if (fox.IsOnStartingShore)
                Console.WriteLine(fox.Name);
            else
                Console.WriteLine($"                              {fox.Name}");

            if (goose.IsOnStartingShore)
                Console.WriteLine(goose.Name);
            else
                Console.WriteLine($"                              {goose.Name}");

            if (corn.IsOnStartingShore)
                Console.WriteLine(corn.Name);
            else
                Console.WriteLine($"                              {corn.Name}");

            if (human.IsOnStartingShore)
                Console.WriteLine(human.Name);
            else
                Console.WriteLine($"                              {human.Name}");
        }

        private static bool TwoItemsOnTheSameSide(FoxGooseCorn item1, FoxGooseCorn item2)
        {
            if (item1.IsOnDestinationShore && item2.IsOnDestinationShore)
                return true;

            if (item1.IsOnStartingShore && item2.IsOnStartingShore)
                return true;

            return false;
        }
    }
}
