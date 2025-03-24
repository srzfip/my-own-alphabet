using System;
using System.Collections.Generic;
using System.Text;

class AlphabetTranslator
{
    static Dictionary<char, string> translationMap = new Dictionary<char, string>
    {
        {'A', ".-."}, {'B', ".v."}, {'C', ".(."}, {'D', "./."}, {'E', ".q."}, {'F', ".!."},
        {'G', ".%."}, {'H', "#-#"}, {'I', "#v#"}, {'J', "#(#"}, {'K', "#/#"}, {'L', "#q#"},
        {'M', "#!#"}, {'N', "#%#"}, {'O', "*/*"}, {'P', "*#*"}, {'Q', "*\"*"}, {'R', "*,*"},
        {'S', "*.*"}, {'T', "*&*"}, {'U', "*'*"}, {'V', "*!*"}, {'W', "*)*"}, {'X', "'!'"},
        {'Y', "'*'"}, {'Z', "'#'"}
    };

    static Dictionary<string, char> reverseTranslationMap = new Dictionary<string, char>();

    static AlphabetTranslator()
    {
        foreach (var pair in translationMap)
        {
            reverseTranslationMap[pair.Value] = pair.Key;
        }
    }

    static string TranslateToCustomAlphabet(string input)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in input.ToUpper())
        {
            if (translationMap.ContainsKey(c))
                result.Append(translationMap[c]); 
            else if (c == ' ') 
                result.Append(" ");
            else
                result.Append(c);
        }
        return result.ToString();
    }

    static string TranslateFromCustomAlphabet(string input)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder buffer = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            buffer.Append(input[i]);

           
            if (reverseTranslationMap.ContainsKey(buffer.ToString()))
            {
                result.Append(reverseTranslationMap[buffer.ToString()]);
                buffer.Clear();
            }
            else if (input[i] == ' ') 
            {
                result.Append(' ');
                buffer.Clear(); 
            }
        }
        return result.ToString();
    }

    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("1. Normal Text to new Alphabet ");
            Console.WriteLine("2. Translate Alphabet");
            Console.WriteLine("3. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write(" text : ");
                    string input = Console.ReadLine();
                    string translated = TranslateToCustomAlphabet(input);
                    Console.WriteLine("tanslated : " + translated);
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("text ");
                    string encodedInput = Console.ReadLine();
                    string decoded = TranslateFromCustomAlphabet(encodedInput);
                    Console.WriteLine("decoded: " + decoded);
                    Console.ReadKey();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("kurdthzsgrestgrw<ag.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
