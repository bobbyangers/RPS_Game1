using System;

namespace RPS_Game1.Game
{
    public interface IInputProvider
    {
        string GetLine();
    }

    public class DefaultInputProvider : IInputProvider
    {
        public string GetLine()
        {
            Console.WriteLine("Please Enter your next choice : R,P or S; then press [Enter]");
            var m = Console.ReadLine();

            return m;
        }
    }
}