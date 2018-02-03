using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using PriorityQueue.Collections;
using PriorityQueue.Comparers;


namespace CGScopeChallengeCode
{
    public class RunningMedian
    {
        private readonly PriorityQueue<BigInteger> maximumHeapThatContainLowerNumbers = new PriorityQueue<BigInteger>(new MaxHeapIntegerComparer()); // Max Heap -- Left

        private readonly PriorityQueue<BigInteger> minimumHeapThatContainHigherNumbers = new PriorityQueue<BigInteger>(new MinHeapBigIntergerComparer()); // Min Heap -- Right

        public double[] GetMedians(BigInteger[] integers, int arraySize)
        {
            if(integers.Length != arraySize)
                throw new Exception("Array size is not equal to integers size.");

            double[] medians = new double[integers.Length];

            for (int i = 0; i < integers.Length; i++)
            {
                BigInteger number = integers[i];

                AddNewRandomNumber(number);
                medians[i] = GetMedian();
            }

            return medians; 
        }

        private void AddNewRandomNumber(BigInteger newNumber)
        {
            if (minimumHeapThatContainHigherNumbers.Count == maximumHeapThatContainLowerNumbers.Count)
            {
                if (minimumHeapThatContainHigherNumbers.Peek() != 0 &&
                    newNumber > minimumHeapThatContainHigherNumbers.Peek())
                {
                    maximumHeapThatContainLowerNumbers.Offer(minimumHeapThatContainHigherNumbers.Poll());
                    minimumHeapThatContainHigherNumbers.Offer(newNumber);
                }
                else
                {
                    maximumHeapThatContainLowerNumbers.Offer(newNumber);
                }
            }
            else
            {
                if (newNumber < maximumHeapThatContainLowerNumbers.Peek())
                {
                    minimumHeapThatContainHigherNumbers.Offer(maximumHeapThatContainLowerNumbers.Poll());
                    maximumHeapThatContainLowerNumbers.Offer(newNumber);
                }
                else
                {
                    minimumHeapThatContainHigherNumbers.Offer(newNumber);
                }

            }
        }

        private double GetMedian()
        {
            if (maximumHeapThatContainLowerNumbers.Count == 0)
                return (double)minimumHeapThatContainHigherNumbers.Peek();

            if (minimumHeapThatContainHigherNumbers.Count == 0)
                return (double)maximumHeapThatContainLowerNumbers.Peek();

            if (maximumHeapThatContainLowerNumbers.Count == minimumHeapThatContainHigherNumbers.Count)
            {
                return (double)(minimumHeapThatContainHigherNumbers.Peek() + maximumHeapThatContainLowerNumbers.Peek()) / 2;
            }
            if (maximumHeapThatContainLowerNumbers.Count > minimumHeapThatContainHigherNumbers.Count)
            {
                return (double)maximumHeapThatContainLowerNumbers.Peek();

            }

            return (double)minimumHeapThatContainHigherNumbers.Peek();
        }
    }
}