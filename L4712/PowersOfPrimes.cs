using System;
namespace L4712
{
    public class Primes
    {
        public int[] Powers { get; set; }
        public int[] LowPowers { get; set; }

        public Primes()
        {
            int[] primes = 
                {   2,   3,   5,   7,  11,  13,  17,  19,  23,  29
                ,  31,  37,  41,  43,  47,  53,  59,  61,  67,  71
                ,  73,  79,  83,  89,  97, 101, 103, 107, 109, 113
                , 127, 131, 137, 139, 149, 151, 157, 163, 167, 173
                , 179, 181, 191, 193, 197, 199};
            SortedSet<int> thePowers = new SortedSet<int>();

            thePowers.Add(1);

            foreach (int p in primes)
            {
                int pow = p;
                while (pow < 200)
                {
                    thePowers.Add(pow);
                    pow *= p;
                }
            }
            Powers = thePowers.ToArray();
            LowPowers = thePowers.Where(a => a < 100).ToArray();
        }
    }
}

