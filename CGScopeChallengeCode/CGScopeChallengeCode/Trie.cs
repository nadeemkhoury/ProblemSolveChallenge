////using System;
////using System.Collections.Generic;

////namespace CGScopeChallengeCode
////{
////    public static class DamerauLevenshtein
////    {
////        public static int DamerauLevenshteinDistanceTo(this string @string, string targetString)
////        {
////            return DamerauLevenshteinDistance(@string, targetString);
////        }

////        public static int DamerauLevenshteinDistance(string string1, string string2)
////        {
////            if (String.IsNullOrEmpty(string1))
////            {
////                if (!String.IsNullOrEmpty(string2))
////                    return string2.Length;

////                return 0;
////            }

////            if (String.IsNullOrEmpty(string2))
////            {
////                if (!String.IsNullOrEmpty(string1))
////                    return string1.Length;

////                return 0;
////            }

////            int length1 = string1.Length;
////            int length2 = string2.Length;

////            int[,] d = new int[length1 + 1, length2 + 1];

////            int cost, del, ins, sub;

////            for (int i = 0; i <= d.GetUpperBound(0); i++)
////                d[i, 0] = i;

////            for (int i = 0; i <= d.GetUpperBound(1); i++)
////                d[0, i] = i;

////            for (int i = 1; i <= d.GetUpperBound(0); i++)
////            {
////                for (int j = 1; j <= d.GetUpperBound(1); j++)
////                {
////                    if (string1[i - 1] == string2[j - 1])
////                        cost = 0;
////                    else
////                        cost = 1;

////                    del = d[i - 1, j] + 1;
////                    ins = d[i, j - 1] + 1;
////                    sub = d[i - 1, j - 1] + cost;

////                    d[i, j] = Math.Min(del, Math.Min(ins, sub));

////                    if (i > 1 && j > 1 && string1[i - 1] == string2[j - 2] && string1[i - 2] == string2[j - 1])
////                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
////                }
////            }

////            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
////        }
////    }
////}
//public class Trie
//{
//    private TrieNode head;

//    public Trie()
//    {
//        head = new TrieNode();
//    }

//    /**
//     * Add a word to the trie.
//     * Adding is O (|A| * |W|), where A is the alphabet and W is the word being searched.
//     */
//    public void AddWord(string word)
//    {
//        TrieNode curr = head;

//        curr = curr.GetChild(word[0], true);

//        for (int i = 1; i < word.Length; i++)
//        {
//            curr = curr.GetChild(word[i], true);
//        }

//        curr.AddCount();
//    }

//    /**
//     * Get the count of a partictlar word.
//     * Retrieval is O (|A| * |W|), where A is the alphabet and W is the word being searched.
//     */
//    public int GetCount(string word)
//    {
//        TrieNode curr = head;

//        foreach (char c in word)
//        {
//            curr = curr.GetChild(c);

//            if (curr == null)
//            {
//                return 0;
//            }
//        }

//        return curr.count;
//    }

//    internal class TrieNode
//    {
//        private LinkedList<TrieNode> children;

//        public int count { private set; get; }
//        public char data { private set; get; }

//        public TrieNode(char data = ' ')
//        {
//            this.data = data;
//            count = 0;
//            children = new LinkedList<TrieNode>();
//        }

//        public TrieNode GetChild(char c, bool createIfNotExist = false)
//        {
//            foreach (var child in children)
//            {
//                if (child.data == c)
//                {
//                    return child;
//                }
//            }

//            if (createIfNotExist)
//            {
//                return CreateChild(c);
//            }

//            return null;
//        }

//        public void AddCount()
//        {
//            count++;
//        }

//        public TrieNode CreateChild(char c)
//        {
//            var child = new TrieNode(c);
//            children.AddLast(child);

//            return child;
//        }
//    }
//}