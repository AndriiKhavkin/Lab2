using System;
namespace Lab2
{
    static public class GlobalInfo
    {
        public static int MinRating = 1;
        
        public static int GetRandom(int range)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int value = rnd.Next(range);
            return value;
        }
    }
}