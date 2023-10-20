using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Match
    {
        private Player Winner { get; set; } = new();
        private InnerGame[] OuterGame { get; set; } = Array.Empty<InnerGame>();

        private sbyte NextMove(byte cell, Player current)
        {
            try
            {
                if (current.Type == 'X')
                {
                    if (OuterGame[cell].Pos.HasWinnerOPattern())
                        return -1;
                    else
                        return (sbyte) cell;
                }

                if (current.Type == 'O')
                {
                    if (OuterGame[cell].Pos.HasWinnerXPattern())
                        return -1;
                    else
                        return (sbyte) cell;
                }
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("Player and Innergame cannot be null.");
            }

            throw new ArgumentException("Invalid cell");
        }


        private struct InnerGame
        {
            public Player WinnerCell { get; set; }
            public char[] Pos { get; set; }
        }
    }


    //
    internal class Player
    {
        private char _type;
        public char Type {
            get
            {
                return _type;
            }
            private set
            {
                _type = value;
                _type.ToUpper();
            }
        }
    }

    public static class Extensions
    {

        public static bool HasWinnerXPattern(this char[] g)
        {
            if (g.Length == 0 || g.Length > 9)
            {
                throw new ArgumentException($"the cell cannot be empty");
            }

            g.ToList().ForEach(x => x.ToUpper());

            return
                (g[0] == 'X' && g[1] == 'X' && g[2] == 'X') ||
                (g[3] == 'X' && g[4] == 'X' && g[5] == 'X') ||
                (g[6] == 'X' && g[7] == 'X' && g[8] == 'X') ||
                (g[0] == 'X' && g[3] == 'X' && g[6] == 'X') ||
                (g[1] == 'X' && g[4] == 'X' && g[7] == 'X') ||
                (g[2] == 'X' && g[5] == 'X' && g[8] == 'X') ||
                (g[0] == 'X' && g[4] == 'X' && g[8] == 'X') ||
                (g[6] == 'X' && g[4] == 'X' && g[2] == 'X');
        }

        public static bool HasWinnerOPattern(this char[] g)
        {
            if (g.Length == 0 || g.Length > 9)
            {
                throw new ArgumentException($"the cell cannot be empty, or longer than 9 positions");
            }

            return
                (g[0] == 'O' && g[1] == 'O' && g[2] == 'O') ||
                (g[3] == 'O' && g[4] == 'O' && g[5] == 'O') ||
                (g[6] == 'O' && g[7] == 'O' && g[8] == 'O') ||
                (g[0] == 'O' && g[3] == 'O' && g[6] == 'O') ||
                (g[1] == 'O' && g[4] == 'O' && g[7] == 'O') ||
                (g[2] == 'O' && g[5] == 'O' && g[8] == 'O') ||
                (g[0] == 'O' && g[4] == 'O' && g[8] == 'O') ||
                (g[6] == 'O' && g[4] == 'O' && g[2] == 'O');
        }

        public static bool HasAnyWinnerPattern(this char[] cell)
        {
            return
                cell.HasWinnerXPattern() || cell.HasWinnerOPattern();
        }

        internal static void ToUpper(this ref char c)
        {
            c =
                c == 'x' || c == 'X' ? 'X' :
                c == 'y' || c == 'Y' ? 'Y' :
                'I';
        }
    }
}
