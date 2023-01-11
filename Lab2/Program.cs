using System;
using System.Threading;

namespace Lab2
{
    public class Program
    {
        public static void Main(String[] args)
        {
            GameAccount Player1 = new GameAccount("Pavel", 100);
            VipAccount Player2 = new VipAccount("Illya", 100);
            PowerAccount Player3 = new PowerAccount("Danya", 100);

            TestGame testGame1 = new TestGame();
            RankedGame rankGame2 = new RankedGame();
            OnlyWin  onlyWinGame3 = new OnlyWin();
            
            testGame1.PlayGame(Player1, Player2);
            testGame1.PlayGame(Player1, Player3);
            testGame1.PlayGame(Player2, Player3);
            
            rankGame2.PlayGame(Player1, Player2);
            rankGame2.PlayGame(Player1, Player3);
            rankGame2.PlayGame(Player2, Player3);
            
            onlyWinGame3.PlayGame(Player1, Player2);
            onlyWinGame3.PlayGame(Player1, Player3);
            onlyWinGame3.PlayGame(Player2, Player3);
            
            Player1.ShowPlayerInfo();
            Player1.ShowHistory();
            Player2.ShowPlayerInfo();
            Player2.ShowHistory();
            Player3.ShowPlayerInfo();
            Player3.ShowHistory();
        }
    }
}