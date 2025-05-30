using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULearn_X_O
{
    internal class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
        public static GameResult GetGameResult(Mark[,] field)
        {
            if (CheckWin(field, Mark.Circle) && CheckWin(field, Mark.Cross))
            {
                return GameResult.Draw;
            }
            if (CheckWin(field, Mark.Circle))
            {
                return GameResult.CircleWin;
            }
            else if (CheckWin(field, Mark.Cross))
            {
                return GameResult.CrossWin;
            }
            else
            {
                return GameResult.Draw;
            }
        }
        public static bool CheckWin(Mark[,] field, Mark whoCheck)
        {
            bool win;
            for (int x = 0; x < field.GetLength(0); x++)
            {
                win = true;
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x, y] != whoCheck)
                    {
                        win = false;
                        var a = 4;
                        break;
                    }
                    
                }
                if (win)
                {
                    return win;
                }
            }
            for (int x = 0; x < field.GetLength(0); x++)
            {
                win = true;
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[y, x] != whoCheck)
                    {
                        win = false;
                        break;
                    }

                }
                if (win)
                {
                    return win;
                }
            }

            return ((field[0,0] == whoCheck && field[1, 1] == whoCheck && field[2, 2] == whoCheck) || (field[0, 2] == whoCheck && field[1, 1] == whoCheck && field[2, 0] == whoCheck));
        }
    }
}
