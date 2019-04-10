using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        ArrayList Beowulf;
        int counterletters = 0;
        int countSpaces = 0;
        static void Main(string[] args)
        {
            Program a = new Program();
            a.Beowulf = new ArrayList();
            a.ReadTextFiles();
        }

        public void Run() { this.ReadTextFiles(); }
        public void ReadTextFiles()
        {

            using (StreamReader sr = new StreamReader("U:/Users/725866/beowulf.txt"))
            {
                string line;
                int counter = 0;
                int a = 0, myWord = 1;
                float averageLetterPerWord;
                ArrayList lineNumbers = new ArrayList();
                ArrayList lineNumbers2 = new ArrayList();
                int linenum = 1;
                lineNumbers.Add(22);

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    Beowulf.Add(line);
                    FindNumberOfBlankSpaces(line);
                    counter++;

                    // SECTION C
                    if (line.Substring(0).Contains("Sea") || line.Substring(0).Contains("sea") && line.Substring(0).Contains("Fare") || line.Substring(0).Contains("fare"))
                    {
                        lineNumbers.Add(linenum);
                    }

                    // SECTION D
                    if (line.Substring(0).Contains("fare") || line.Substring(0).Contains("Fare"))
                    {
                        if (!(line.Substring(0).Contains("war") || line.Substring(0).Contains("War")))
                        {
                            lineNumbers2.Add(linenum);
                        }
                        
                    }

                    // COUNTING THE NUMBER OF WORDS  SECTION B
                    while (a <= line.Length - 1)
                    {
                        if (line[a] == ' ' || line[a] == '\n' || line[a] == '\t')
                        {
                            myWord++;
                        }
                        a++;
                    }
                    a = 0;

                    linenum++;  // SECTION C
                }
                // COUNTING THE NUMBER OF AVERAGE LETTERS IN WORD SECTION E
                averageLetterPerWord = counterletters / countSpaces;

                // SECTION A: NUMBER OF LINES
                Console.WriteLine("\n\n\n\n********************************\nThe number of lines in the paragraph is " + counter);
                Console.WriteLine("The number of words in paragraph is " + myWord);
                Console.WriteLine("The number of average letters per word is  " + averageLetterPerWord);


                // SECTION C: WORDS WHICH CONTAINS BOTH SEA AND FARE
                Console.WriteLine("The line which contains both sea and fare\n");
                foreach (int i in lineNumbers)
                {
                    Console.Write(i + " ");
                }

                // SECTION C: WORDS WHICH CONTAINS BOTH SEA AND FARE
                Console.WriteLine("The line which contains Fare, but not War\n");
                foreach (int i in lineNumbers2)
                {
                    Console.Write(i + " ");
                }

                Console.ReadLine();
            }

        }
        public int FindNumberOfBlankSpaces(string line)
        {
            foreach (char c in line)
            {
                if (char.IsLetter(c)) { counterletters++; }
                if (char.IsWhiteSpace(c)) { countSpaces++; }
            }
            return countSpaces;
        }
    }
}
