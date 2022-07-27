using System;
namespace L4712
{
	public class Clue
	{
        public string Raw { get; set; }

		public Dirn Dir { get; set; }
        private int ClueNo { get; set; }
        private string Tokens { get; set; }
		private int Length { get; set; }

        public Clue(string str, Dirn dir)
		{
			Raw = str;
			Dir = dir;
			var splitted = str.Split(',');
            ClueNo = int.Parse(splitted[0]);
			Tokens = splitted[1].Substring(0, splitted[1].Length-3).Replace(" ","");
			Length = int.Parse(splitted[1].Substring(splitted[1].Length - 2, 1));
		}

        public override string ToString()
        {
            return $"{ClueNo,2}{(Dir==Dirn.Across?'a':'d')} {Tokens} ({Length})";
        }
    }
}

