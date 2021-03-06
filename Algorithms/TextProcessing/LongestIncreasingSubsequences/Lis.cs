﻿using System;

namespace Algorithms.TextProcessing.LongestIncreasingSubsequences
{
    public class LIS<T> where T : IComparable<T>
    {
        public static T[] Find(T[] sequence)
        {
            int lisLength = 1;
            var minLasts = new int[sequence.Length];
            var resultChain = new int[sequence.Length];

            resultChain[0] = -1;

            for (int i = 1; i < sequence.Length; ++i)
            {
                T current = sequence[i];
                int index = FindFirstGreaterOrEqual(sequence, current, minLasts, lisLength);
                T greaterOrEqual = sequence[minLasts[index]];

                if (index == lisLength || current.CompareTo(greaterOrEqual) < 0)
                {
                    minLasts[index] = i;
                    resultChain[i] = index == 0 ? -1 : minLasts[index - 1];
                }

                if (index == lisLength)
                {
                    ++lisLength;
                }
            }

            return ExtractResult(sequence, resultChain, minLasts[lisLength - 1], lisLength);
        }

        private static int FindFirstGreaterOrEqual(T[] sequence, T element, int[] minLasts, int lisLength)
        {
            int start = 0;
            int end = lisLength - 1;

            if (element.CompareTo(sequence[minLasts[start]]) <= 0)
            {
                return 0;
            }

            if (element.CompareTo(sequence[minLasts[end]]) > 0)
            {
                return lisLength;
            }

            while (end - start > 1)
            {
                int middle = (start + end) / 2;
                int cmp = element.CompareTo(sequence[minLasts[middle]]);

                if (cmp == 0)
                {
                    return middle;
                }

                end = cmp < 0 ? middle : end;
                start = cmp > 0 ? middle : start;
            }

            return end;
        }

        private static T[] ExtractResult(T[] sequence, int[] resultChain, int lastIndex, int lisLength)
        {
            var lis = new T[lisLength];
            int currentIndex = lastIndex;

            for (int i = lisLength - 1; i >= 0; --i)
            {
                lis[i] = sequence[currentIndex];
                currentIndex = resultChain[currentIndex];
            }

            return lis;
        }
    }
}