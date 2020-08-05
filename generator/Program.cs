using System;
using System.Collections.Generic;
using System.Linq;

namespace generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int personsCount = 0;
            if ((args.Count() < 2) || !int.TryParse(args[1], out personsCount) || (personsCount < 1))
            {
                Console.WriteLine("Input parameter error");
                return;
            }
            PersonLocaleSettings personLocalSettings = new PersonLocaleSettings();
            if (!personLocalSettings.Load(args[0]))
            {
                Console.WriteLine("Input locale error");
                return;
            }
            double averageMistakesCount = 0;
            if ((args.Count() > 2) && (!double.TryParse(args[2], out averageMistakesCount) || (averageMistakesCount < 0)))
            {
                Console.WriteLine("Input parameter error");
                return;
            }          
            Person[] persons = new Person[personsCount];
            BaseForGeneration baseForGeneration = new BaseForGeneration();
            baseForGeneration.Load(args[0]);
            Random rnd = new Random();
            for (int i = 0; i < personsCount; ++i)
            {
                persons[i] = new Person(rnd, baseForGeneration, personLocalSettings);
            }
            if (averageMistakesCount > 0)
            {
                MakeMistakes(averageMistakesCount * personsCount, rnd, persons, args[0]);
            }
            for (int i = 0; i < personsCount; ++i)
            {
                persons[i].Print(personLocalSettings);
                Console.WriteLine();
            }
        }    
        static void MakeMistakes(double errorCount, Random rnd, Person[] persons, string locale)
        {
            int errorType, personForMistake, personPropertyForMistake;
            List<char> symbolsForMistakes = new List<char>();
            CreateSymbolList(symbolsForMistakes, locale);
            while (errorCount > 0)
            {
                errorType =  rnd.Next(1, 4);
                personForMistake = rnd.Next(0, persons.Count());
                personPropertyForMistake = rnd.Next(1, 10);
                if (persons[personForMistake][personPropertyForMistake].Length == 0)
                {
                    continue;
                }
                int mistakePosition = rnd.Next(0, persons[personForMistake][personPropertyForMistake].Length-1);
                if (errorType == 1)
                {
                    if(persons[personForMistake][personPropertyForMistake].Length==1)
                    {
                        continue;
                    }
                    persons[personForMistake][personPropertyForMistake] = persons[personForMistake][personPropertyForMistake].Remove(mistakePosition, 1);
                }
                else if (errorType == 2)
                {
                    persons[personForMistake][personPropertyForMistake] = persons[personForMistake][personPropertyForMistake].Insert(0, symbolsForMistakes[rnd.Next(0, symbolsForMistakes.Count)].ToString());
                }
                else
                {
                    if (persons[personForMistake][personPropertyForMistake].Length < 2)
                    {
                        continue;
                    }
                    string invertedSymbols = "" + persons[personForMistake][personPropertyForMistake][mistakePosition + 1] + persons[personForMistake][personPropertyForMistake][mistakePosition];
                    persons[personForMistake][personPropertyForMistake] = persons[personForMistake][personPropertyForMistake].Insert(mistakePosition, invertedSymbols);
                    persons[personForMistake][personPropertyForMistake] = persons[personForMistake][personPropertyForMistake].Remove(mistakePosition + 2, 2);
                }
                --errorCount;
            }
        }
        static void CreateSymbolList(List <char> symbols, string locale)
        {
            symbols.Clear();
            for (char i = '0'; i <= '9'; ++i)
            {
                symbols.Add(i);
            }
            if (locale == "en_US")
            {
                for (char i = 'A'; i <= 'Z'; ++i)
                {
                    symbols.Add(i);
                }
                for (char i = 'a'; i <= 'z'; ++i)
                {
                    symbols.Add(i);
                }
            }
            else
            {
                for (int i = 1040; i <= 1103; ++i)
                {
                    if ((i == 1080) && (locale == "be_BY"))
                    {
                        symbols.Add((char)1110);
                    }
                    if ((i == 1048) && (locale == "be_BY"))
                    {
                        symbols.Add((char)1030);
                    }
                    else if (((i == 1098) || (i == 1066)) && (locale == "be_BY"))
                    {
                        symbols.Add('\'');
                    }
                    else
                    {
                        symbols.Add((char)i);
                    }
                }
            }
        }
    }    
}
    