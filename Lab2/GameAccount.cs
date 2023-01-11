using System;
using System.Collections.Generic;

namespace Lab2
{
    public class GameAccount
    {
        public GameAccount(string userName, int rating)
        {
            UserName = userName;
            CurrentRating = rating < 1 ? 1 : rating;//перевірка чи не є рейтинг менше 1
        }
            
        public string UserName;
        public int CurrentRating;
        
        
        public List<GameHistory> GamesHistory = new List<GameHistory>();
        
        public virtual void WinGame(GameAccount opponentName, int gameRating, int idOfGame, string gameType)
        {
            if (CurrentRating < gameRating || opponentName.GetRating() < gameRating)
            {
                Console.WriteLine("\nPlayer " + UserName + "(" + CurrentRating + ")" + " and player " + opponentName.GetUserName() + "(" + opponentName.GetRating() + ")" + " cannot play with rating " + gameRating);
                return;
            }
            
            CurrentRating += gameRating;
            opponentName.SetRating(opponentName.GetRating() - gameRating);
            GameHistory game = new GameHistory(this, opponentName,true, gameRating, idOfGame, gameType);
            GamesHistory.Add(game);
        }
            
        public virtual void LoseGame(GameAccount opponentName, int gameRating, int idOfGame, string gameType)
        {            
            if (gameRating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gameRating), "Rating should be positive");
            }
            if (CurrentRating - gameRating <=0)
            {
                throw new InvalidOperationException("A Rating is bigger that a rating of the player");
            }
            CurrentRating -= gameRating;
            opponentName.SetRating(opponentName.GetRating() + gameRating);
            GameHistory game = new GameHistory(this, opponentName,false, -gameRating, idOfGame, gameType);
            GamesHistory.Add(game);
        }
        
        public int GetRating() { return CurrentRating;}
        public void SetRating(int Value) { CurrentRating = Value < GlobalInfo.MinRating ? GlobalInfo.MinRating : Value ;}
        public string GetUserName() { return UserName;}



        public virtual void ShowPlayerInfo()
        {
            Console.WriteLine("\nPlayer: " + UserName + "\t\tRating: " + CurrentRating +"\n\n" );
        }       
        
        public void ShowHistory()
        {
            foreach (var game in GamesHistory)
            {
                Console.Write("Game ID: " + game.GameID + " Game type: " + game.GameType +"  Player 1: " + game.FirstPlayer.GetUserName() + "  Player 2: " + game.SecondPlayer.GetUserName() + "  Rating for the game: " + game.GameRating + "  Winner of the game was ");
                Console.WriteLine(game.didWinFirstPlayer ? game.FirstPlayer.GetUserName() : game.SecondPlayer.GetUserName());
            }
        }
    }
    
    public class VipAccount : GameAccount
    {
        public VipAccount(string userName, int rating) : base(userName, rating)
        {
            UserName = userName;
            CurrentRating = rating < 1 ? 1 : rating;
        }

        public override void WinGame(GameAccount opponentName, int gameRating, int idOfGame, string gameType)
        {
            if (CurrentRating < gameRating || opponentName.GetRating() < gameRating)
            {
                Console.WriteLine("\nPlayer " + UserName + "(" + CurrentRating + ")" + " and player " + opponentName.GetUserName() + "(" + opponentName.GetRating() + ")" + " cannot play with rating " + gameRating);
                return;
            }
            CurrentRating += Convert.ToInt32(gameRating * 2.5);
            opponentName.SetRating(opponentName.GetRating() - gameRating);
            GameHistory game = new GameHistory(this, opponentName,true, Convert.ToInt32(gameRating * 2.5), idOfGame, gameType);
            GamesHistory.Add(game);
        }

        public override void LoseGame(GameAccount opponentName, int gameRating, int idOfGame, string gameType)
        {
            if (gameRating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gameRating), "Rating should be positive");
            }
            if (CurrentRating - gameRating <=0)
            {
                throw new InvalidOperationException("A Rating is bigger that a rating of the player");
            }
            CurrentRating += Convert.ToInt32(-gameRating * 0.5);
            opponentName.SetRating(opponentName.GetRating() + gameRating);
            GameHistory game = new GameHistory(this, opponentName,false, Convert.ToInt32(-gameRating * 0.6), idOfGame, gameType);
            GamesHistory.Add(game);
        }
        
        public override void ShowPlayerInfo()
        {
            Console.WriteLine("\nPlayer: " + UserName + "\tRating: " + CurrentRating +"\tType of player: VIP!!\n" );
        }   
    }
    
    public class PowerAccount : GameAccount
    {
        public PowerAccount(string userName, int rating) : base(userName, rating)
        {
            UserName = userName;
            CurrentRating = rating < 1 ? 1 : rating;
        }

        public override void WinGame(GameAccount opponentName, int gameRating, int idOfGame, string gameType)
        {
            int streak = 0;
            if (CurrentRating < gameRating || opponentName.GetRating() < gameRating)
            {
                Console.WriteLine("\nPlayer " + UserName + "(" + CurrentRating + ")" + " and player " + opponentName.GetUserName() + "(" + opponentName.GetRating() + ")" + " cannot play with rating " + gameRating);
                return;
            }
            if (idOfGame >= 2){
                foreach (var games in GamesHistory)
                {
                    if (games.didWinFirstPlayer)
                    {
                        streak++;
                    }
                }
            }
            if (streak >= 3){
                CurrentRating += Convert.ToInt32(gameRating * 25);
                Console.WriteLine("Player "+ UserName +"STREAK!!");
            }
            opponentName.SetRating(opponentName.GetRating() - gameRating);
            GameHistory game = new GameHistory(this, opponentName,true, gameRating, idOfGame, gameType);
            GamesHistory.Add(game);
        }
        
        public override void ShowPlayerInfo()
        {
            Console.WriteLine("\nPlayer: " + UserName + "\tRating: " + CurrentRating +"\tType of player: Power Player!!\n" );
        }   
    }
}