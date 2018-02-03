using System.Collections.Generic;
using System.Numerics;

namespace CGScopeChallengeCode
{
    public class MinHeapBigIntergerComparer : IComparer<BigInteger>
    {
        public int Compare(BigInteger x, BigInteger y)
        {
            return x.CompareTo(y); 
        }
    }
}