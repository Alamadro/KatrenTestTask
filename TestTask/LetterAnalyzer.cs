using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal static class LetterAnalyzer
    {
        private static readonly List<char> _consonants = new List<char> { 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };
        private static readonly List<char> _vowel = new List<char> { 'А', 'О', 'У', 'Ы', 'И', 'Э', 'Е', 'Ё', 'Ю', 'Я' };

        public static CharType GetTypeLetter(char c)
        {
            if(_vowel.Contains(char.ToUpper(c))) return CharType.Vowel;
            else if(_consonants.Contains(char.ToUpper(c))) return CharType.Consonants;
            else return CharType.Unknown;
        }

        public static bool IsLetter(char c)
        {
            return _vowel.Contains(char.ToUpper(c)) || _consonants.Contains(char.ToUpper(c));
        }
    }
}
