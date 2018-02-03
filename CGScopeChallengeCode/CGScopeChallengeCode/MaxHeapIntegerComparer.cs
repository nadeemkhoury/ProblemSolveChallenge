using System.Collections.Generic;
using System.Numerics;

namespace CGScopeChallengeCode
{
    public class MaxHeapIntegerComparer : IComparer<BigInteger>
    {
        public int Compare(BigInteger x, BigInteger y)
        {
            return -1 * x.CompareTo(y);
        }
    }
}