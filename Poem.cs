using HaikuExtensions;
using System.Text;

namespace HaikuPoems
{
    public class Poem
    {
        List<string> poemList;
        List<int> syllablesInEachLine;
        StringBuilder results;
        string title;
        public Poem(List<string> poemList)
        {
            this.PoemList = poemList;
            syllablesInEachLine = new List<int>();
            Results = new StringBuilder();
        }

        public List<string> PoemList { get => poemList; set => poemList = value; }
        public string Title { get => title; set => title = value; }
        public List<int> SyllablesInEachLine { get => syllablesInEachLine; set => syllablesInEachLine = value; }
        public StringBuilder Results { get => results; set => results = value; }

        public void processHaiku()
        {
            bool isHaiku = false;
            countSyllablesInLine();
            runReport();
        }

        private void runReport()
        {
            hasExactlyThreeLines();
            checkLineOne();
            checkLineTwo();
            checkLineThree();
        }

        public bool isHaiku()
        {
            return results.Length == 0;
        }

        private void hasExactlyThreeLines()
        {
            if (poemList.Count!=3)
            {
                results.AppendLine(String.Format("Expecting the haiku to have 3 linesbut found {0}", poemList.Count));
            }
        }

        private void checkLineOne()
        {
            if (syllablesInEachLine[0]!=5)
            {
                results.AppendLine(String.Format("Line 1 of a haiku should have 5 syllables but this has {0}", syllablesInEachLine[0]));
            }
        }        
        
        private void checkLineTwo()
        {
            if (syllablesInEachLine[1]!=7)
            {
                results.AppendLine(String.Format("Line 2 of a haiku should have 7 syllables but this has {0}", syllablesInEachLine[1]));
            }
        }        
        
        private void checkLineThree()
        {
            if (syllablesInEachLine[2]!=5)
            {
                results.AppendLine(String.Format("Line 3 of a haiku should have 5 syllables but this has {0}", syllablesInEachLine[2]));
            }
        }

        private void countSyllablesInLine()
        {           
            foreach (string line in poemList)
            {
                int countSyllablesInLine = 0;
                string strippedLine = line.StripPunctuation();
                List<string> splitLine = strippedLine.Split(" ").ToList();
                foreach (string word in splitLine)
                {
                    countSyllablesInLine += countSyllablesInWord(word);
                }
                syllablesInEachLine.Add(countSyllablesInLine);
            }         
        }

        private int countSyllablesInWord(string word)
        {
            int countSyllablesInWord = 0;
       
            for(int i = 0; i< word.Length; i++)
            {
                char currentLetter = word[i];
                //At last letter
                if (i+1>=word.Length)
                {
                    if (currentLetter.Equals('y'))
                    {
                        countSyllablesInWord++;
                    }
                    else if (currentLetter.Equals('e') && countSyllablesInWord==0)
                    {
                        countSyllablesInWord++;
                    }
                    else if (currentLetter.IsVowel() && !currentLetter.Equals('e'))
                    {
                        countSyllablesInWord++;
                    }
                }
                else if (currentLetter.IsVowel() && !word[i+1].IsVowel())
                {
                    Console.WriteLine(currentLetter);
                    countSyllablesInWord++;
                }
            }
            return countSyllablesInWord;
        }
    }
}
