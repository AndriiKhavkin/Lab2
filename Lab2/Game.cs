using System;
using System.Threading;

namespace Lab2
{
    public abstract class Game
    {
        public abstract string GameType { get; }
        
        protected abstract int GetRating( );
        
        protected static int Id = 0;
        public virtual void PlayGame( GameAccount UserName,  GameAccount opponentName)
        {
            int rating = this.GetRating();
            int value1 = GlobalInfo.GetRandom(5) + 1;
            Thread.Sleep(100);
            int value2 = GlobalInfo.GetRandom(5) + 1;
            
            Console.WriteLine("Game: Player1 threw away:" + value1 + " Player 2 threw away:" + value2);
            if (value1 > value2)
            {
                Console.WriteLine("Player 1 win this game");
                UserName.WinGame(opponentName, rating, Id, this.GameType);
                opponentName.LoseGame(UserName, rating, Id, this.GameType);
            }
            else if (value1 == value2)
            {
                Console.WriteLine("Draw - rating did not change");
            }else{
                Console.WriteLine("Player 2 win this game");
                opponentName.WinGame(UserName, rating, Id, this.GameType);
                UserName.LoseGame(opponentName, rating, Id, this.GameType);
            }
            Id++;
        }
    }

    public class TestGame : Game
    {
        public override string GameType => "Test";

        protected override int GetRating() { return 0; }
        
    }
    public class RankedGame : Game
    {
        public override string GameType => "Regular";

        protected override int GetRating() { return 20; }
    }

   

    public class OnlyWin : RankedGame
    {
        public override string GameType => "Safe";
        protected override int GetRating() { return 20; }
        public override void PlayGame(GameAccount UserName, GameAccount opponentName)
        {
            int rating = this.GetRating();
            int value1 = GlobalInfo.GetRandom(5) + 1;
            Thread.Sleep(100);
            int value2 = GlobalInfo.GetRandom(5) + 1;
            Console.WriteLine("Game: Player1 threw away:" + value1 + " Player 2 threw away:" + value2);
            if (value1 > value2)
            {
                Console.WriteLine("Player 1 win this game");
                UserName.WinGame(opponentName, rating, Id, this.GameType);
                opponentName.LoseGame(UserName, 0, Id, this.GameType);
            }
            else if (value1 == value2)
            {
                Console.WriteLine("Draw - rating did not change");
            }else{
                Console.WriteLine("Player 2 win this game");
                opponentName.WinGame(UserName, rating, Id, this.GameType);
                UserName.LoseGame(opponentName, 0, Id, this.GameType);
            }
            Id++;
        }
    }
}