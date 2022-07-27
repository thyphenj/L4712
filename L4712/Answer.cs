using System;
namespace L4712
{
    public class Answer
    {
        public int Value { get; set; }
        public string ValStr { get; set; }

        public Answer(int raw)
        {
            Value = raw;
            ValStr = Value.ToString();
        }

        public int Length() { return ValStr.Length; }
        public bool LengthIs2() { return Value > 0 && this.Length() == 2; }
        public bool LengthIs3() { return Value > 0 && this.Length() == 3; }
        public bool LengthIs4() { return Value > 0 && this.Length() == 4; }

        public bool ZeroAt(int pos)
        {
            if (this.Length() > pos)
                return ValStr[pos] == '0';
            else
                return false;
        }
        public override string ToString()
        {
            return ValStr;
        }
    }
}

