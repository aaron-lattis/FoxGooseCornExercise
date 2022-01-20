using System;

namespace FoxGooseCorn
{
    class Program
    {
        static void Main(string[] args)
        {
            Fox fox;
            Goose goose;
            Corn corn;
            Human human;

            bool playAgain = true;

            while (playAgain)
            {
                fox = new Fox();
                goose = new Goose();
                corn = new Corn();
                human = new Human();
                
                while (PlayGame.play(fox, goose, corn, human)) ;

                playAgain = PlayGame.EndGame();
            }
        }
    }
}
