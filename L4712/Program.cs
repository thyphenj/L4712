namespace L4712
{
    class Program
    {
        static void Main()
        {
            //var clues = new ClueCollection();
            //var chars = clues.Charlist();
            var prim = new Primes();
            var powers = prim.Powers;
            var powersLength = powers.Length;
            int smallLength = powers.Where(a => a < 100).Count();

            var partialResults = new List<Dictionary<char, int>>();

            var usedIndices = new List<int>();

#if false
            int cnt = 0;
            for (int _S = 0; _S < smallLength; _S++)
            {
                usedIndices.Add(_S);

                for (int _U = 0; _U < smallLength; _U++)
                {
                    if (usedIndices.Contains(_U)) continue;
                    usedIndices.Add(_U);

                    for (int _m = 0; _m < smallLength; _m++)
                    {
                        if (usedIndices.Contains(_m)) continue;
                        usedIndices.Add(_m);

                        for (int _M = 0; _M < smallLength; _M++)
                        {
                            if (usedIndices.Contains(_M)) continue;
                            usedIndices.Add(_M);

            #region Stage1

                            var justOnce = 0;
                            while (justOnce++ == 0)
                            {
                                var S = powers[_S];
                                var U = powers[_U];
                                var m = powers[_m];
                                var M = powers[_M];
                                var O = S + U * M;

                                var a08 = new Answer(S + U * m / S);
                                var a17 = new Answer(S + U + m);
                                var a25 = new Answer(S * U * m);
                                var a26 = new Answer(O);
                                var d01 = new Answer(S + U + m * S);
                                var d03 = new Answer(S + U + M);

                                if (!(a08.LengthIs2() && (U * m) % S == 0)) continue;
                                if (!(a17.LengthIs2())) continue;
                                if (!(a25.LengthIs3())) continue;
                                if (!(a26.LengthIs2() && a26.Value % 10 != 0 && powers.Contains(O))) continue;
                                if (!(d01.LengthIs2() && d01.Value % 10 != 0)) continue;
                                if (!(d03.LengthIs2() && d03.Value % 10 != 0)) continue;

                                if (!(d01.LengthIs2() && a08.LengthIs2() && d01.ValStr[1] == a08.ValStr[0])) continue;   // these two intersect
                                if (!(m * O < 1000)) continue;              // d02 must be 3 digits long

                                var partial = new Dictionary<char, int>();
                                partial.Add('S', _S);
                                partial.Add('U', _U);
                                partial.Add('m', _m);
                                partial.Add('M', _M);
                                partial.Add('O', Array.IndexOf(powers, O));
                                partialResults.Add(partial);

                                cnt++;
                            }
            #endregion

                            usedIndices.Remove(_M);
                        }
                        usedIndices.Remove(_m);
                    }
                    usedIndices.Remove(_U);
                }
                usedIndices.Remove(_S);
            }

            //-- At this point we have 14 possible combinations for SUMmO

            foreach (var reslt in partialResults)
            {
                var S = powers[reslt['S']];
                var U = powers[reslt['U']];
                var m = powers[reslt['m']];
                var M = powers[reslt['M']];
                var O = powers[reslt['O']];
                usedIndices.Add(reslt['S']);
                usedIndices.Add(reslt['U']);
                usedIndices.Add(reslt['m']);
                usedIndices.Add(reslt['M']);
                usedIndices.Add(reslt['O']);

                for (int _Y = 0; powers[_Y] < 10; _Y++)
                {
                    if (usedIndices.Contains(_Y)) continue;
                    usedIndices.Add(_Y);

            #region Stage_2

                    var justOnce = 0;
                    while (justOnce++ == 0)
                    {
                        var Y = powers[_Y];

                        var d25 = new Answer(Y * Y + Y);
                        if (!(d25.LengthIs2() && d25.Value % 10 != 0)) continue;

                        var I = d25.Value + S;
                        if (usedIndices.Contains(I)) continue;

                        var d26a = new Answer(S * Y * S);
                        var d26b = new Answer(S * (I - S));
                        if (!(d26a.LengthIs2() && d26a.Value == d26b.Value && d26a.Value % 10 != 0)) continue;

                        Console.Write($"S={S,2}");
                        Console.Write($", m={m,2}");
                        Console.Write($", I={I,2}");
                        Console.Write($", Y={Y,2}");
                        Console.Write(" -- ");
                        Console.Write($"U={U,2}");
                        Console.Write($", M={M,2}");
                        Console.Write($", O={O,2}");
                        Console.WriteLine();
                    }
            #endregion

                    usedIndices.Remove(_Y);
                }

                usedIndices.Remove(reslt['S']);
                usedIndices.Remove(reslt['U']);
                usedIndices.Remove(reslt['m']);
                usedIndices.Remove(reslt['M']);
                usedIndices.Remove(reslt['O']);
            }

#endif

            // -- At this point we have results for S=4, m=8, I=16, Y=3
            // -- and this forces U=5, M=9, O=49
            int Y_ = 3;
            int S_ = 4;
            int U_ = 5;
            int m_ = 8;
            int M_ = 9;
            int I_ = 16;
            int O_ = 49;

            usedIndices.Add(Array.IndexOf(powers, S_));
            usedIndices.Add(Array.IndexOf(powers, m_));
            usedIndices.Add(Array.IndexOf(powers, I_));
            usedIndices.Add(Array.IndexOf(powers, Y_));

            usedIndices.Add(Array.IndexOf(powers, U_));
            usedIndices.Add(Array.IndexOf(powers, O_));
            usedIndices.Add(Array.IndexOf(powers, M_));

#if false

            for (int _G = 0; _G < smallLength; _G++)
            {
                if (usedIndices.Contains(_G)) continue;
                usedIndices.Add(_G);

                for (int _A = 0; _A < smallLength; _A++)
                {
                    if (usedIndices.Contains(_A)) continue;
                    usedIndices.Add(_A);

                    var justOnce = 0;
                    while (justOnce++ == 0)
                    {
                        int G = powers[_G];
                        if (G % M_ != 0) continue;

                        int A = powers[_A];

                        var a18 = new Answer(S_ + I_ * G / M_ + A);
                        if (!a18.LengthIs2()) continue;

                        var a19 = new Answer(S_ + I_ + G + m_ + A);
                        if (!a19.LengthIs2()) continue;

                        Console.WriteLine($"G={G} A={A,2}   A18={a18}");
                    }
                    usedIndices.Remove(_A);
                }
                usedIndices.Remove(_G);
            }


#endif

            // -- So G=27!!
            int G_ = 27;
            usedIndices.Add(Array.IndexOf(powers, G_));



#if false

            for (int _E = 0; _E < powersLength; _E++)
            {
                if (usedIndices.Contains(_E)) continue;
                usedIndices.Add(_E);

                for (int _r = 0; _r < powerLength; _r++)
                {
                    if (usedIndices.Contains(_r)) continue;
                    usedIndices.Add(_r);

                    for (int _e = 0; _e < powersLength; _e++)
                    {
                        if (usedIndices.Contains(_e)) continue;
                        usedIndices.Add(_e);

                        for (int _R = 0; _R < powersLength; _R++)
                        {
                            if (usedIndices.Contains(_R)) continue;
                            usedIndices.Add(_R);

                            for (int _P = 0; _P < powersLength; _P++)
                            {
                                if (usedIndices.Contains(_P)) continue;
                                usedIndices.Add(_P);

                                var justOnce = 0;
                                while (justOnce++ == 0)
                                {
                                    int E = powers[_E];
                                    int e = powers[_e];
                                    int r = powers[_r];
                                    int R = powers[_R];
                                    int P = powers[_P];

                                    var d27 = new Answer(M_ + E);
                                    if (!d27.LengthIs2()) continue;
                                    if (d27.ValStr[0] != '9') continue;

                                    if ((r * I_ * e) % S_ != 0) continue;
                                    var a05 = new Answer(S_ + E + r * I_ * e / S_);
                                    if (!a05.LengthIs3()) continue;
                                    if (a05.ZeroAt(1) || a05.ZeroAt(2)) continue;

                                    var a22 = new Answer(S_ * E * r - I_ + e + S_);
                                    if (!a22.LengthIs3()) continue;

                                    if ((S_ * E) % r != 0) continue;
                                    var d05 = new Answer(S_ * E / r + I_ + E * S_);
                                    if (!d05.LengthIs3()) continue;
                                    if (d05.ZeroAt(1)) continue;
                                    if (d05.ValStr[0] != a05.ValStr[0]) continue;

                                    var d22 = new Answer(S_ - E + R * I_ - e * S_);
                                    if (!d22.LengthIs3()) continue;
                                    if (!d22.ZeroAt(1)) continue;
                                    if (d22.ValStr[0] != a22.ValStr[0]) continue;

                                    var a11 = new Answer(P + r + I_ + m_ + e);
                                    if (!a11.LengthIs3()) continue;
                                    if (d05.ValStr[1] != a11.ValStr[0]) continue;

                                    var a28 = new Answer(P + R - I_ + M_ - e);
                                    if (!a28.LengthIs2()) continue;
                                    if (a28.ZeroAt(1)) continue;

                                    var d06 = new Answer(P * R / I_ + M_ * e);
                                    if (!d06.LengthIs3()) continue;
                                    if (d06.ValStr[0] != a05.ValStr[1]) continue;

                                    Console.WriteLine($"E={E}, e={e}, r={r}, R={R}, P={P}");
                                }
                                usedIndices.Remove(_P);
                            }
                            usedIndices.Remove(_R);
                        }
                        usedIndices.Remove(_e);
                    }
                    usedIndices.Remove(_r);
                }
                usedIndices.Remove(_E);
            }

#endif
            // -- now we know that E=83, r=2 and R=64
            int E_ = 83;
            int r_ = 2;
            int R_ = 64;
            usedIndices.Add(Array.IndexOf(powers, E_));
            usedIndices.Add(Array.IndexOf(powers, r_));
            usedIndices.Add(Array.IndexOf(powers, R_));

#if false

            for (int _P = 0; _P < powersLength; _P++)
            {
                if (usedIndices.Contains(_P)) continue;
                usedIndices.Add(_P);

                for (int _W = 0; _W < powersLength; _W++)
                {
                    if (usedIndices.Contains(_W)) continue;
                    usedIndices.Add(_W);

                    for (int _e = 0; _e < powersLength; _e++)
                    {
                        if (usedIndices.Contains(_e)) continue;
                        usedIndices.Add(_e);

                        for (int _o = 0; _o < powersLength; _o++)
                        {
                            if (usedIndices.Contains(_o)) continue;
                            usedIndices.Add(_o);

                            for (int _N = 0; _N < powersLength; _N++)
                            {
                                if (usedIndices.Contains(_N)) continue;
                                usedIndices.Add(_N);

                                var justOnce = 0;
                                while (justOnce++ == 0)
                                {
                                    int W = powers[_W];
                                    int P = powers[_P];
                                    int e = powers[_e];
                                    int o = powers[_o];
                                    int N = powers[_N];

                                    if (N != 1 && N != 19) continue;

                                    var a02 = new Answer(P * o + W * E_ + r_);
                                    if (!a02.LengthIs4()) continue;
                                    if (a02.ValStr[2] != '1') continue;
                                    if (a02.ValStr[3] == '0') continue;

                                    if ((r_ * I_ * e) % S_ != 0) continue;
                                    var a05 = new Answer(S_ + E_ + r_ * I_ * e / S_);
                                    if (!a05.LengthIs3()) continue;
                                    if (a05.ValStr[0] != '5') continue;

                                    var a11 = new Answer(P + r_ + I_ + m_ + e);
                                    if (!a11.LengthIs3()) continue;
                                    if (a11.ValStr[0] != '1') continue;

                                    var a16 = new Answer(P + O_ + W - E_ + r_);
                                    if (!a16.LengthIs2()) continue;

                                    var a22 = new Answer(S_ * E_ * r_ - I_ + e + S_);
                                    if (!a22.LengthIs3()) continue;

                                    var a23 = new Answer(M_ + E_ + N * U_ * S_);
                                    if (!a23.LengthIs3()) continue;
                                    if (a23.ValStr[1] == '0') continue;

                                    var a28 = new Answer(P + R_ - I_ + M_ - e);
                                    if (!a28.LengthIs2()) continue;
                                    if (a28.ValStr[1] == '0') continue;

                                    var d02 = new Answer(m_ * O_ * r_ + e);
                                    if (!d02.LengthIs3()) continue;
                                    if (d02.ValStr[1] != '4') continue;
                                    if (d02.ValStr[0] != a02.ValStr[0]) continue;

                                    //var d04 = new Answer(S_ - I_ * G_ / M_ + a);

                                    if ((P * R_) % I_ != 0) continue;
                                    var d06 = new Answer(P * R_ / I_ + M_ * e);
                                    if (!d06.LengthIs3()) continue;

                                    var d13 = new Answer(S_ + I_ + N + E_ * S_);
                                    if (!d13.LengthIs3()) continue;

                                    var d22 = new Answer(S_ - E_ + R_ * I_ - e * S_);
                                    if (!d22.LengthIs3()) continue;
                                    if (d22.ValStr[1] != '0') continue;

                                    var d29 = new Answer(N + U_ + m_ + S_);
                                    if (!d29.LengthIs2()) continue;
                                    if (d29.ValStr[0] != a28.ValStr[1]) continue;

                                    Console.Write($"a02={a02} a05={a05} a16={a16} a22={a22} a23={a23} a28={a28} d02={d02} d13={d13} d22={d22} d29={d29}     ");
                                    Console.WriteLine($"P={P} W={W} e={e} o={o} N={N}");
                                }

                                usedIndices.Remove(_N);
                            }
                            usedIndices.Remove(_o);
                        }
                        usedIndices.Remove(_e);
                    }
                    usedIndices.Remove(_W);
                }
                usedIndices.Remove(_P);
            }


#endif

#if false

            for (int _T = 0; _T < powersLength; _T++)
            {
                if (usedIndices.Contains(_T)) continue;
                usedIndices.Add(_T);


                for (int _H = 0; _H < powersLength; _H++)
                {
                    if (usedIndices.Contains(_H)) continue;
                    usedIndices.Add(_H);

                    var justOnce = 0;
                    while (justOnce++ == 0)
                    {
                        int T = powers[_T];
                        int H = powers[_H];

                        var a30b = new Answer(T * I_ * M_ + E_ + S_);
                        if (!a30b.LengthIs3()) continue;
                        int e = a30b.Value - T - H;
                        if (e >= 200 || usedIndices.Contains(Array.IndexOf(powers, e))) continue;

                        if ((r_ * I_ * e) % S_ != 0) continue;
                        var a05 = new Answer(S_ + E_ + r_ * I_ * e / S_);
                        if (!a05.LengthIs3()) continue;
                        if (a05.ValStr[0] != '5') continue;

                        Console.WriteLine($"a05={a05} a30={a30b} T={T} H={H} e={e}");
                    }

                    usedIndices.Remove(_H);
                }

                usedIndices.Remove(_T);
            }

#endif
            // -- Now we know T=1
            int T_ = 1;
            usedIndices.Add(Array.IndexOf(powers, T_));

            // -- from a27 we can now get C=
            int C_ = M_ + E_ - T_ + I_;
            usedIndices.Add(Array.IndexOf(powers, C_));

            //-- from a31 we can get N=19
            int N_ = 19;
            usedIndices.Add(Array.IndexOf(powers, N_));

            // -- from d14 and d19 we know a18 = 95, so A=43
            int A_ = 95 - (S_ + I_ * G_ / M_);
            usedIndices.Add(Array.IndexOf(powers, A_));

#if false
            // -- we know that e is in the 57, 61 or 63
            foreach (int e in new int[] { 57, 61, 63 })
            {
                if ((r_ * I_ * e) % S_ != 0) continue;
                var a05 = new Answer(S_ + E_ + r_ * I_ * e / S_);
                if (!a05.LengthIs3()) continue;
                if (a05.ZeroAt(1) || a05.ZeroAt(2)) continue;

                var a22 = new Answer(S_ * E_ * r_ - I_ + e + S_);
                if (!a22.LengthIs3()) continue;

                var d22 = new Answer(S_ - E_ + R_ * I_ - e * S_);
                if (!d22.LengthIs3()) continue;
                if (!d22.ZeroAt(1)) continue;
                if (d22.ValStr[0] != a22.ValStr[0]) continue;

                Console.WriteLine($"e={e}");
            }

#endif
            //-- and now we know e=61 and thus H=
            int e_ = 61;
            int H_ = T_ * I_ * M_ + E_ + S_ - (T_ + e_);
            usedIndices.Add(Array.IndexOf(powers, e_));
            usedIndices.Add(Array.IndexOf(powers, H_));

            // -- we know from d24 and d29 that a28 = 43, therefore P=
            int P_ = 43 - (R_ - I_ + M_ - e_);
            usedIndices.Add(Array.IndexOf(powers, P_));


#if false
            for ( int _a = 0; _a < powersLength; _a++)
            {
                if (usedIndices.Contains(_a)) continue;
                int a = powers[_a];

                var a10 = new Answer(T_ + a - U_);
                if (!a10.LengthIs2()) continue;
                if (a10.ValStr[0] != '8') continue;

                Console.WriteLine($"a={a} a10={a10}");
            }
#endif

            // -- now we know a=89
            int a_ = 89;
            usedIndices.Add(Array.IndexOf(powers, a_));

#if false
            for (int _W = 0; _W < powersLength; _W++)
            {
                if (usedIndices.Contains(_W)) continue;
                usedIndices.Add(_W);
                int W = powers[_W];

                for (int _o = 0; _o < powersLength; _o++)
                {
                    if (usedIndices.Contains(_o)) continue;
                    usedIndices.Add(_o);
                    int o = powers[_o];

                    for ( int _F = 0; _F < powersLength; _F++)
                    {
                        if (usedIndices.Contains(_F)) continue;
                        usedIndices.Add(_F);
                        int F = powers[_F];

                        int justOnce = 0;
                        while (justOnce++ == 0)
                        {
                            var d07 = new Answer(F - E_ + W - e_ + R_);
                            if (d07.Value != 54) continue;

                            var a02 = new Answer(P_ * o + W * E_ + r_);
                            if (!a02.LengthIs4()) continue;
                            if (a02.ValStr[0] != '8') continue;
                            if (a02.Value % 100 != 14) continue;

                            var a12 = new Answer(F + o - r_ - T_*Y_);
                            if (!a12.LengthIs3()) continue;
                            if (a12.ValStr[1] != '5') continue;

                            var a16 = new Answer(P_ + O_ + W - E_ + r_);
                            if (!a16.LengthIs2()) continue;

                            var d09 = new Answer(R_ * A_ * T_ / I_ + o);
                            if (!d09.LengthIs3()) continue;
                            if (d09.ValStr[2] != '1') continue;

                            var d12 = new Answer(R_ + A_ - T_ - I_ + o);
                            if (!d12.LengthIs3()) continue;
                            if (d12.ValStr[1] != a16.ValStr[0]) continue;

                            Console.WriteLine($"o={o}, W={W} F={F}     a02={a02}, a12={a12}, a16={a16}, d09={d09}, d12={d12}");
                        }
                        usedIndices.Remove(_F);
                    }
                    usedIndices.Remove(_o);
                }
                usedIndices.Remove(_W);
            }

#endif

            // -- so we now have o=79, W=53 and F=81
            int o_ = 79;
            int W_ = 53;
            int F_ = 81;
            usedIndices.Add(Array.IndexOf(powers, o_));
            usedIndices.Add(Array.IndexOf(powers, W_));
            usedIndices.Add(Array.IndexOf(powers, F_));

            //---------------------------------throw stuff out !
            Console.WriteLine();

            //Console.WriteLine($"T={T_,3}, r={r_,3}, Y={Y_,3}");
            //Console.WriteLine($"S={S_,3}, U={U_,3}, m={m_,3}, M={M_,3}, I={I_,3}, N={N_,3}, G={G_,3}");
            //Console.WriteLine($"A={A_,3}");
            //Console.WriteLine($"P={P_,3}, O={O_,3}, W={W_,3}, e={e_,3}, R={R_,3}");
            //Console.WriteLine($"o={o_,3}, F={F_,3}");
            //Console.WriteLine($"E={E_,3}, a={a_,3}, C={C_,3}, H={H_,3}");
            //Console.WriteLine($"");
            //Console.WriteLine();

            //Console.WriteLine($"a02 = {P_ * o_ + W_ * E_ + r_}");
            //Console.WriteLine($"a05 = {S_ + E_ + r_ * I_ * e_ / S_}");
            //Console.WriteLine($"a08 = {S_ + U_ * m_ / S_}");
            //Console.WriteLine($"a10 = {T_ + a_ - U_}");
            //Console.WriteLine($"a11 = {P_ + r_ + I_ + m_ + e_}");
            //Console.WriteLine($"a12 = {F_ + o_ - r_ - T_ * Y_ }");
            //Console.WriteLine($"a13 = {S_ + P_ + H_ + e_ + r_ + e_}");
            //Console.WriteLine($"a16 = {P_ + O_ + W_ - E_ + r_}");
            //Console.WriteLine($"a17 = {S_ + U_ + m_}");
            //Console.WriteLine($"a18 = {S_ + I_ * G_ / M_ + A_}");
            //Console.WriteLine($"a20 = {S_ + I_ + G_ + m_ + A_}");
            //Console.WriteLine($"a22 = {S_ * E_ * r_ - I_ + e_ + S_}");
            //Console.WriteLine($"a23 = {M_ + E_ + N_ * U_ * S_}");
            //Console.WriteLine($"a25 = {S_ * U_ * m_}");
            //Console.WriteLine($"a26 = {S_ + U_ * M_} = {O_}");
            //Console.WriteLine($"a28 = {P_ + R_ - I_ + M_ - e_}");
            //Console.WriteLine($"a30 = {T_ + H_ + e_} = {T_ * I_ * M_ + E_ + S_}");
            //Console.WriteLine($"a31 = {M_ * I_ * N_ * T_ * Y_}");
            //Console.WriteLine();

            //Console.WriteLine($"d01 = {S_ + U_ + m_ * S_}");
            //Console.WriteLine($"d02 = {m_ * O_ * r_ + e_}");
            //Console.WriteLine($"d03 = {S_ + U_ + M_}");
            //Console.WriteLine($"d04 = {S_ - I_ * G_ / M_ + a_}");
            //Console.WriteLine($"d05 = {S_ * E_ / r_ + I_ + E_ * S_}");
            //Console.WriteLine($"d06 = {P_ * R_ / I_ + M_ * e_}");
            //Console.WriteLine($"d07 = {F_ - E_ + W_ - e_ + R_}");
            //Console.WriteLine($"d09 = {R_ * A_ * T_ / I_ + o_}");
            //Console.WriteLine($"d12 = {R_ + A_ - T_ - I_ + o_}");
            //Console.WriteLine($"d13 = {S_ + I_ + N_ + E_ * S_}");
            //Console.WriteLine($"d14 = {-T_ * E_ + R_ * M_}");
            //Console.WriteLine($"d15 = {m_ * a_ + T_ + H_}");
            //Console.WriteLine($"d19 = {C_ + O_ + S_ + I_ * N_ + E_}");
            //Console.WriteLine($"d21 = {-T_ + r_ * I_ * G_}");
            //Console.WriteLine($"d22 = {S_ - E_ + R_ * I_ - e_ * S_}");
            //Console.WriteLine($"d24 = {N_ * (A_ + r_) - C_}");
            //Console.WriteLine($"d25 = {Y_ * Y_ + Y_} = {I_ - S_}");
            //Console.WriteLine($"d26 = {S_ * Y_ * S_} = {S_ * (I_ - S_)}");
            //Console.WriteLine($"d27 = {M_ + E_} = {T_ - I_ + C_}");
            //Console.WriteLine($"d29 = {N_ + U_ + m_ + S_}");
            //Console.WriteLine();

            var ans = new List<int>();

            ans.Add(P_ * o_ + W_ * E_ + r_);
            ans.Add(S_ + E_ + r_ * I_ * e_ / S_);
            ans.Add(S_ + U_ * m_ / S_);
            ans.Add(T_ + a_ - U_);
            ans.Add(P_ + r_ + I_ + m_ + e_);
            ans.Add(F_ + o_ - r_ - T_ * Y_);
            ans.Add(S_ + P_ + H_ + e_ + r_ + e_);
            ans.Add(P_ + O_ + W_ - E_ + r_);
            ans.Add(S_ + U_ + m_);
            ans.Add(S_ + I_ * G_ / M_ + A_);
            ans.Add(S_ + I_ + G_ + m_ + A_);
            ans.Add(S_ * E_ * r_ - I_ + e_ + S_);
            ans.Add(M_ + E_ + N_ * U_ * S_);
            ans.Add(S_ * U_ * m_);
            ans.Add(S_ + U_ * M_);
            ans.Add(P_ + R_ - I_ + M_ - e_);
            ans.Add(T_ + H_ + e_);
            ans.Add(M_ * I_ * N_ * T_ * Y_);

            ans.Add(S_ + U_ + m_ * S_);
            ans.Add(m_ * O_ * r_ + e_);
            ans.Add(S_ + U_ + M_);
            ans.Add(S_ - I_ * G_ / M_ + a_);
            ans.Add(S_ * E_ / r_ + I_ + E_ * S_);
            ans.Add(P_ * R_ / I_ + M_ * e_);
            ans.Add(F_ - E_ + W_ - e_ + R_);
            ans.Add(R_ * A_ * T_ / I_ + o_);
            ans.Add(R_ + A_ - T_ - I_ + o_);
            ans.Add(S_ + I_ + N_ + E_ * S_);
            ans.Add(-T_ * E_ + R_ * M_);
            ans.Add(m_ * a_ + T_ + H_);
            ans.Add(C_ + O_ + S_ + I_ * N_ + E_);
            ans.Add(-T_ + r_ * I_ * G_);
            ans.Add(S_ - E_ + R_ * I_ - e_ * S_);
            ans.Add(N_ * (A_ + r_) - C_);
            ans.Add(Y_ * Y_ + Y_);
            ans.Add(S_ * Y_ * S_);
            ans.Add(M_ + E_);
            ans.Add(N_ + U_ + m_ + S_);

            ans.Sort();

            //-----------------------------------------------------------
            Console.WriteLine("Fourth power");

            int num = 493;
            ans.Remove(num);
            Console.WriteLine($" 1  -   {num,5}");

            bool keepGoing = true;
            for (int ind = 2; ind < 13 && keepGoing; ind++)
            {
                string log = "";
                num = SumOfPower4(num);
                if (num < 1000 && ans.Contains(num))
                {
                    ans.Remove(num);
                    log = $"{ind,2}  -  {num,6}";
                }
                else if (num < 10000 && ans.Contains(num % 100) && ans.Contains(num / 100))
                {
                    ans.Remove(num % 100);
                    ans.Remove(num / 100);
                    log = $"{ind,2}  -   {num / 100,2} {num % 100,2}";
                }
                else if (num < 10000 && ans.Contains(num))
                {
                    ans.Remove(num);
                    log = $"{ind,2}  -  {num,6}";
                }
                else if (num >= 10000 && ans.Contains(num % 100) && ans.Contains(num / 100))
                {
                    ans.Remove(num % 100);
                    ans.Remove(num / 100);
                    log = $"{ind,2}  -  {num / 100,3} {num % 100,2}";
                }
                else if (num >= 10000 && ans.Contains(num % 1000) && ans.Contains(num / 1000))
                {
                    ans.Remove(num % 1000);
                    ans.Remove(num / 1000);
                    log = $"{ind,2}  -  {num / 1000,2} {num % 1000,3}";
                }
                else
                {
                    log = $"{ind,2}  - FAILED!!!";
                    keepGoing = false;
                }
                Console.WriteLine(log);
            }
            Console.WriteLine();

            // -- from the sums of cubes it looks like either 17 or more likely 845 is another starting number

            Console.WriteLine("Third Power");

            num = 845;
            ans.Remove(num);
            Console.WriteLine($" 1  -   {num,5}");

            keepGoing = true;
            for (int ind = 2; ind < 12 && keepGoing; ind++)
            {
                string log = "";
                num = SumOfPower3(num);
                if (num < 1000 && ans.Contains(num))
                {
                    ans.Remove(num);
                    log = $"{ind,2}  -  {num,6}";
                }
                else if (num < 10000 && ans.Contains(num / 100) && ans.Contains(num % 100))
                {
                    ans.Remove(num / 100);
                    ans.Remove(num % 100);
                    log = $"{ind,2}  -   {num / 100,2} {num % 100,2}";
                }
                else
                {
                    keepGoing = false;
                    log = $"{ind,2}  - FAILED!!!";
                }
                Console.WriteLine(log);
            }
            Console.WriteLine();

#if false
                        // -- Try sums of fifth power for each answer
            foreach (var an in ans)
            {
                int pow = SumOfPower5(an);
                Console.Write($"{an,3} -> {pow,5}");
                int left = pow / 100;
                int rite = pow % 100;
                if (ans.Contains(left) && ans.Contains(rite))
                    Console.Write($" {left}|{rite} ");
                left = pow / 1000;
                rite = pow % 1000;
                if (ans.Contains(left) && ans.Contains(rite))
                    Console.Write($" {left}|{rite} ");
                Console.WriteLine();
            }

#endif
            // -- now it looks like 472 is the start of a 5th power seequnce

            Console.WriteLine("Fifth Power");

            num = 472;
            ans.Remove(num);
            Console.WriteLine($" 1  -   {num,5}");

            keepGoing = true;
            for (int ind = 2; ind < 12 && keepGoing; ind++)
            {
                string log = "";
                num = SumOfPower5(num);
                if (num < 10000 && ans.Contains(num % 100) && ans.Contains(num / 100))
                {
                    ans.Remove(num % 100);
                    ans.Remove(num / 100);
                    log = $"{ind,2}  -   {num / 100,2} {num % 100,2}";
                }
                else if (num < 10000 && ans.Contains(num))
                {
                    ans.Remove(num);
                    log = $"{ind,2}  -  {num,6}";
                }
                else if (num >= 10000 && ans.Contains(num % 100) && ans.Contains(num / 100))
                {
                    ans.Remove(num % 100);
                    ans.Remove(num / 100);
                    log = $"{ind,2}  -  {num / 100,3} {num % 100,2}";
                }
                else if (num >= 10000 && ans.Contains(num % 1000) && ans.Contains(num / 1000))
                {
                    ans.Remove(num % 1000);
                    ans.Remove(num / 1000);
                    log = $"{ind,2}  -  {num / 1000,2} {num % 1000,3}";
                }
                else
                {
                    log = $"{ind,2}  - FAILED!!!";
                    keepGoing = false;
                }
                Console.WriteLine(log);
            }


            //-- what's left unused?
            Console.WriteLine();
            Console.WriteLine("UNUSED");

            foreach (var n in ans)
                Console.Write($"{n} ");
            Console.WriteLine();
        }

        private static int SumOfPower2(int num)
        {
            int sum = 0;
            foreach (var ch in num.ToString())
            {
                int d = ch - '0';
                sum += d * d;
            }
            return sum;
        }
        private static int SumOfPower3(int num)
        {
            int sum = 0;
            foreach (var ch in num.ToString())
            {
                int d = ch - '0';
                sum += d * d * d;
            }
            return sum;
        }
        private static int SumOfPower4(int num)
        {
            int sum = 0;
            foreach (var ch in num.ToString())
            {
                int d = ch - '0';
                sum += d * d * d * d;
            }
            return sum;
        }
        private static int SumOfPower5(int num)
        {
            int sum = 0;
            foreach (var ch in num.ToString())
            {
                int d = ch - '0';
                sum += d * d * d * d * d;
            }
            return sum;
        }
    }
}