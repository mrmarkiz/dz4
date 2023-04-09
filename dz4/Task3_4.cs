using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    internal class Task3_4
    {
        public static void Run3()
        {
            Console.WriteLine("Enter text to convert into morse code:");
            string text = Console.ReadLine();
            text = text.ToLower();
            string result = Morse.Coder.Code(text);
            Console.WriteLine("Result:");
            Console.WriteLine(result);
        }
        public static void Run4()
        {
            Console.WriteLine("Enter text to decode from morse code:");
            string text = Console.ReadLine();
            string result = Morse.Decoder.Decode(text);
            Console.WriteLine("Result:");
            Console.WriteLine(result);
        }
    }
    namespace Morse
    {
        class Globals
        {
            public static Dictionary<char, string> code_letters = new Dictionary<char, string>()
            {
                {'a', ".-"},
                {'b', "-..." },
                {'c', "-.-." },
                {'d',"-.." },
                {'e', "." },
                {'f', "..-." },
                {'g', "--." },
                {'h', "...." },
                {'i', ".." },
                {'j', ".---" },
                {'k', "-.-" },
                {'l', ".-.." },
                {'m', "--" },
                {'n', "-." },
                {'o', "---" },
                {'p', ".--." },
                {'q', "--.-" },
                {'r', ".-." },
                {'s', "..." },
                {'t', "-" },
                {'u', "..-" },
                {'v', "...-" },
                {'w', ".--" },
                {'x', "-..-" },
                {'y', "-.--" },
                {'z', "--.." }
            };
            public static Dictionary<char, string> code_numbers = new Dictionary<char, string>()
            {
                {'1', ".----"},
                {'2', "..---" },
                {'3', "...--" },
                {'4',"....-" },
                {'5', "....." },
                {'6', "-...." },
                {'7', "--..." },
                {'8', "---.." },
                {'9', "----." },
                {'0', "-----" }
            };
            public static Dictionary<char, string> code_symbols = new Dictionary<char, string>()
            {
                {'?', "..--.."},
                {'!', "-.-.--" },
                {'.', ".-.-.-" },
                {',',"--..--" },
                {';', "-.-.-." },
                {':', "---..." },
                {'+', ".-.-." },
                {'-', "-....-" },
                {'/', "-..-." },
                {'=', "-...-" }
            };
            /*
            public static Dictionary<string, char> decode_letters = new Dictionary<string, char>()
            {
                {".-", 'a'},
                {"-...", 'b'},
                {"-.-.", 'c'},
                {"-..", 'd'},
                {".", 'e'},
                {"..-.", 'f' },
                {"--.", 'g' },
                {"....", 'h' },
                {"..", 'i' },
                {".---", 'j' },
                {"-.-", 'k' },
                {".-..", 'l' },
                {"--", 'm' },
                {"-.", 'n' },
                {"---", 'o' },
                {".--.", 'p' },
                {"--.-", 'q' },
                {".-.", 'r' },
                {"...", 's' },
                {'t', "-" },
                {'u', "..-" },
                {'v', "...-" },
                {'w', ".--" },
                {'x', "-..-" },
                {'y', "-.--" },
                {'z', "--.." }
            };
            public static Dictionary<char, string> decode_numbers = new Dictionary<char, string>()
            {
                {'1', ".----"},
                {'2', "..---" },
                {'3', "...--" },
                {'4',"....-" },
                {'5', "....." },
                {'6', "-...." },
                {'7', "--..." },
                {'8', "---.." },
                {'9', "----." },
                {'0', "-----" }
            };
            public static Dictionary<char, string> decode_symbols = new Dictionary<char, string>()
            {
                {'?', "..--.."},
                {'!', "-.-.--" },
                {'.', ".-.-.-" },
                {',',"--..--" },
                {';', "-.-.-." },
                {':', "---..." },
                {'+', ".-.-." },
                {'-', "-....-" },
                {'/', "-..-." },
                {'=', "-...-" }
            };
            */
        }

        class Coder
        {
            public static string Code(string s)
            {
                string result = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                        result += "   ";
                    else if (Globals.code_letters.ContainsKey(s[i]))
                    {
                        result += Globals.code_letters[s[i]];
                        result += ' ';
                    }
                    else if (Globals.code_numbers.ContainsKey(s[i]))
                    {
                        result += Globals.code_numbers[s[i]];
                        result += ' ';
                    }
                    else if (Globals.code_symbols.ContainsKey(s[i]))
                    {
                        result += Globals.code_symbols[s[i]];
                        result += ' ';
                    }
                }
                return result;
            }
        }

        class Decoder
        {
            private static T KeyByValue<T, W>(Dictionary<T, W> dict, W val)
            {
                T key = default;
                foreach (KeyValuePair<T, W> pair in dict)
                {
                    if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                    {
                        key = pair.Key;
                        break;
                    }
                }
                return key;
            }

            public static string Decode(string s)
            {
                string result = "";
                string[] s_words = s.Split("   ");
                for (int i = 0; i < s_words.Length; i++)
                {
                    string[] s_letters = s_words[i].Split(' ');
                    for (int j = 0; j < s_letters.Length; j++)
                    {
                        if (Globals.code_letters.ContainsValue(s_letters[j]))
                        {
                            result += char.ToUpper(KeyByValue(Globals.code_letters, s_letters[j]));
                        }
                        else if (Globals.code_numbers.ContainsValue(s_letters[j]))
                        {
                            result += char.ToUpper(KeyByValue(Globals.code_numbers, s_letters[j]));
                        }
                        else if (Globals.code_symbols.ContainsValue(s_letters[j]))
                        {
                            result += char.ToUpper(KeyByValue(Globals.code_symbols, s_letters[j]));
                        }
                    }
                    result += ' ';
                }
                return result;
            }
        }
    }
}
