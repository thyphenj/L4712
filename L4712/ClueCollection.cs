using System;
namespace L4712
{
    public class ClueCollection
    {
        public List<Clue> Clues { get; set; }

        public ClueCollection()
        {
            string[] across =
                { "2, Po + WE + r (4)"
                , "5, S + E + rIe/S (3)"
                , "8, S + Um/S (2)"
                , "10, T + a - U (2)"
                , "11, P + r + I + m + e (3)"
                , "12, F + o - r - TY (3)"
                , "13, S + P + H + e + r + e (3)"
                , "16, P + O + W - E + r (2)"
                , "17, S + U + m (2)"
                , "18, S + IG/M + A (2)"
                , "20, S + I + G + m + A (2)"
                , "22, SEr - I + e + S (3)"
                , "23, M + E + NUS (3)"
                , "25, SUm (3)"
                , "26, S + UM = O (2)"
                , "28, P + R - I + M - e (2)"
                , "30, T + H + e = TIM + E + S (3)"
                , "31, MINTY (4)"
                };
            string[] down =
                { "1, S + U + mS (2)"
                , "2, mOr + e (3)"
                , "3, S + U + M (2)"
                , "4, S - IG/M + a (2)"
                , "5, SE/r + I + ES (3)"
                , "6, PR/I +Me (3)"
                , "7, F - E + W - e + R (2)"
                , "9, RAT/I + o (3)"
                , "12, R + A - T - I + o (3)"
                , "13, S + I + N + ES (3)"
                , "14, -TE + RM (3)"
                , "15, ma + T + H (3)"
                , "19, C + O + S + IN + E (3)"
                , "21, -T + rIG (3)"
                , "22, S - E +RI -eS (3)"
                , "24, N(A + r) - C (3)"
                , "25, YY + Y = I - S (2)"
                , "26, SYS = S(I-S) (2)"
                , "27, M + E = T - I + C (2)"
                , "29, N + U + m + S (2)"
                };
            Clues = new List<Clue>();

            foreach (string str in across)
            {
                Clues.Add(new Clue(str, Dirn.Across));
            }
            foreach (string str in down)
            {
                Clues.Add(new Clue(str, Dirn.Down));
            }
        }

        public string Charlist()
        {
            HashSet<char> lst = new HashSet<char>();
            foreach ( var clue in Clues)
            {
                foreach ( var ch in clue.Raw)
                {
                    if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                        lst.Add(ch);
                }
            }
            string retval = "";
            foreach (var ch in lst)
                retval = $"{retval}{ch}";
            return retval;
        }
    }
}

