using System;

namespace Lab2
{
    public class GameHistory
    {
        public int GameID { get; }
        public GameAccount FirstPlayer { get; }
        public GameAccount SecondPlayer { get; }
        public bool didWinFirstPlayer { get; }
        public int GameRating { get; }
        public string GameType { get; }
        
        public GameHistory(GameAccount firstPlayer, GameAccount secondPlayer, bool bFirstPlayerWin, int RatingGame, int id, string gameType)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            didWinFirstPlayer = bFirstPlayerWin;
            GameRating = RatingGame;
            GameID = id;
            GameType = gameType;
        }

    }
    
}