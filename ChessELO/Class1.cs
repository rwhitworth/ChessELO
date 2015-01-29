using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessELO
{
    public class EloScore
    {
        public enum Winner
        {
            Black, White, Draw
        };

        public int factor = 32;
        public int divisor = 400;

        public EloResult CalcElo(int WhiteELO, int BlackELO, ChessELO.EloScore.Winner WhoWon)
        {
            // A2 = A1 + 32 (G-(1/(1+10 ** ((B1-A1)/400))))
            float G = 0;
            float A1 = System.Convert.ToSingle(WhiteELO);
            float B1 = System.Convert.ToSingle(BlackELO);
            if (WhoWon == Winner.Black) { G = 0; }
            if (WhoWon == Winner.White) { G = 1; }
            if (WhoWon == Winner.Draw) { G = 1/2; }

            double addsub = factor * (G - (1 / (1 + System.Math.Pow(10, ((B1 - A1) / divisor)))));
            int addsubint = System.Convert.ToInt32(addsub);

            EloResult result = new EloResult();

            if (WhoWon == Winner.Draw)
            {
                result.Black = BlackELO;
                result.White = WhiteELO;
            }
            if (WhoWon == Winner.White)
            {
                result.White = WhiteELO + addsubint;
                result.Black = BlackELO - addsubint;
            }
            if (WhoWon == Winner.Black)
            {
                result.White = WhiteELO + addsubint;
                result.Black = BlackELO - addsubint;
            }
            result.updown = addsubint;

            return result;
        }
    }


    public class EloResult
    {
        public int Black = 0;
        public int White = 0;
        public int updown = 0;
    }
}
