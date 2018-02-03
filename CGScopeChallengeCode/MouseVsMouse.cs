using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGScopeChallengeCode
{
    public enum MouseMeaning
    {
        Animal,
        ComputerMouse,
        Unknown
    }

    public class MouseVsMouse
    {
        public Dictionary<string, MouseMeaning> commonDictionary = new Dictionary<string, MouseMeaning>();

        public MouseVsMouse()
        {
            SetUpCommonDictionary();
        }

        public MouseMeaning[] DistinguishSentences(int sentencesCount, string[] sentences)
        {
            if (sentences.Length != sentencesCount)
                throw new Exception("Sentence count does not equal sentences.");

            List<MouseMeaning> mouseMeanings = new List<MouseMeaning>();

            for (int i = 0; i < sentences.Length; i++)
            {
                var sentenceDictionary = SetUpSentenceDictionary(sentences[i]);

                Dictionary<MouseMeaning, int> numberOfrelatedHouseMeaning = SeeHowManyMouseMeaningRelatedToThisSentence(sentenceDictionary);

                if (numberOfrelatedHouseMeaning[MouseMeaning.Animal] > numberOfrelatedHouseMeaning[MouseMeaning.ComputerMouse])
                    mouseMeanings.Add(MouseMeaning.Animal);
                else if (numberOfrelatedHouseMeaning[MouseMeaning.Animal] < numberOfrelatedHouseMeaning[MouseMeaning.ComputerMouse])
                {
                    mouseMeanings.Add(MouseMeaning.ComputerMouse);
                }
                else
                {
                    mouseMeanings.Add(MouseMeaning.Unknown);
                }
            }

            return mouseMeanings.ToArray();
        }

        private Dictionary<MouseMeaning, int> SeeHowManyMouseMeaningRelatedToThisSentence(
            Dictionary<string, int> sentenceDictionary)
        {
            var resultDictionary = new Dictionary<MouseMeaning, int>()
            {
                {MouseMeaning.Animal, 0},
                {MouseMeaning.ComputerMouse, 0}

            };

            foreach (KeyValuePair<string, int> wordKeyValuePair in sentenceDictionary)
            {
                if (commonDictionary.ContainsKey(
                    SantizeFileName(
                        wordKeyValuePair.Key)))
                {
                    var mouseMeaning = commonDictionary[wordKeyValuePair.Key];

                    resultDictionary[mouseMeaning]++;
                }
            }
            return resultDictionary;

        }
     
        private string SantizeFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c, ' '));
        }

        private Dictionary<string, int> SetUpSentenceDictionary(string sentence)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var word in sentence.Split(' '))
            {
                var lowerWord = word.ToLower();
                if (word.Trim() != "")
                {
                    if (!dictionary.ContainsKey(lowerWord))
                        dictionary.Add(lowerWord, 1);
                    else
                    {
                        dictionary[lowerWord]++;
                    }
                }
            }

            return dictionary;
        }

        /* I decided to use dictionary since it is O(1) in lookup and searching. It also takes O(1) in adding. I tried to use Trie tree and levenshetinDistance to see the level of tolerance of strings. 
      * But it didn't word since the algorthim needs some modification to chnage node type to hold MouseMeaning. I decided to use dictionary and I know the disadvantage of dictionary since it 
      * looks exactly the same of the word without any string comparison tolerance. we can use linq to check the first and end characters. but I didnt have the time to immplment this approch. 

         */

        private void SetUpCommonDictionary()
        {
            commonDictionary = new Dictionary<string, MouseMeaning>();

            commonDictionary.Add("cheese", MouseMeaning.Animal);
            commonDictionary.Add("genome", MouseMeaning.Animal);
            commonDictionary.Add("tail", MouseMeaning.Animal);
            commonDictionary.Add("environmental", MouseMeaning.Animal);
            commonDictionary.Add("temperature", MouseMeaning.Animal);
            commonDictionary.Add("postnatal", MouseMeaning.Animal);
            commonDictionary.Add("balance", MouseMeaning.Animal);
            commonDictionary.Add("climbing", MouseMeaning.Animal);
            commonDictionary.Add("running", MouseMeaning.Animal);
            commonDictionary.Add("rodent", MouseMeaning.Animal);
            commonDictionary.Add("snout", MouseMeaning.Animal);
            commonDictionary.Add("ears", MouseMeaning.Animal);
            commonDictionary.Add("pest", MouseMeaning.Animal);
            commonDictionary.Add("rat", MouseMeaning.Animal);
            commonDictionary.Add("repellents", MouseMeaning.Animal);
            commonDictionary.Add("bait", MouseMeaning.Animal);
            commonDictionary.Add("traps", MouseMeaning.Animal);
            commonDictionary.Add("body", MouseMeaning.Animal);
            commonDictionary.Add("scaly", MouseMeaning.Animal);
            commonDictionary.Add("phylogenies", MouseMeaning.Animal);
            commonDictionary.Add("breeding", MouseMeaning.Animal);
            commonDictionary.Add("species", MouseMeaning.Animal);
            commonDictionary.Add("well-adapted", MouseMeaning.Animal);
            commonDictionary.Add("adapted", MouseMeaning.Animal);
            commonDictionary.Add("sleep", MouseMeaning.Animal);
            commonDictionary.Add("captive", MouseMeaning.Animal);
            commonDictionary.Add("behavioral", MouseMeaning.Animal);
            commonDictionary.Add("polygamous", MouseMeaning.Animal);
            commonDictionary.Add("living", MouseMeaning.Animal);

            commonDictionary.Add("input", MouseMeaning.ComputerMouse);
            commonDictionary.Add("device", MouseMeaning.ComputerMouse);
            commonDictionary.Add("breakthroughs", MouseMeaning.ComputerMouse);
            commonDictionary.Add("computer", MouseMeaning.ComputerMouse);
            commonDictionary.Add("wireless", MouseMeaning.ComputerMouse);
            commonDictionary.Add("usb", MouseMeaning.ComputerMouse);
            commonDictionary.Add("gaming", MouseMeaning.ComputerMouse);
            commonDictionary.Add("object", MouseMeaning.ComputerMouse);
            commonDictionary.Add("roll", MouseMeaning.ComputerMouse);
            commonDictionary.Add("flat", MouseMeaning.ComputerMouse);
            commonDictionary.Add("optical", MouseMeaning.ComputerMouse);
            commonDictionary.Add("sensor", MouseMeaning.ComputerMouse);
            commonDictionary.Add("mobile", MouseMeaning.ComputerMouse);
            commonDictionary.Add("phone", MouseMeaning.ComputerMouse);
            commonDictionary.Add("tablet", MouseMeaning.ComputerMouse);
            commonDictionary.Add("keyboard", MouseMeaning.ComputerMouse);
            commonDictionary.Add("practice", MouseMeaning.ComputerMouse);
            commonDictionary.Add("users", MouseMeaning.ComputerMouse);
            commonDictionary.Add("elbow", MouseMeaning.ComputerMouse);
            commonDictionary.Add("grip", MouseMeaning.ComputerMouse);
            commonDictionary.Add("squeeze", MouseMeaning.ComputerMouse);
            commonDictionary.Add("pivoting", MouseMeaning.ComputerMouse);
            commonDictionary.Add("light", MouseMeaning.ComputerMouse);
            commonDictionary.Add("clicking", MouseMeaning.ComputerMouse);
            commonDictionary.Add("button", MouseMeaning.ComputerMouse);
            commonDictionary.Add("use", MouseMeaning.ComputerMouse);
            commonDictionary.Add("hold", MouseMeaning.ComputerMouse);
            commonDictionary.Add("arrow", MouseMeaning.ComputerMouse);
            commonDictionary.Add("display", MouseMeaning.ComputerMouse);
            commonDictionary.Add("onscreen", MouseMeaning.ComputerMouse);
            commonDictionary.Add("laser", MouseMeaning.ComputerMouse);
            commonDictionary.Add("modern", MouseMeaning.ComputerMouse);
        }

    }
}
