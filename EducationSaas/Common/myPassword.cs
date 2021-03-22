using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public sealed class myPassword
    {
        private static Lazy<myPassword> lazy = new Lazy<myPassword>(() => new myPassword());
        public static myPassword Instance { get { return lazy.Value; } }

        private myPassword()
        {

        }

        private int GetLengthScore(string password) { return Math.Min(10, password.Length) * 6; }

        private int GetLowerScore(string password)
        {
            int rawScore = password.Length - Regex.Replace(password, "[a-z]", "").Length;
            return Math.Min(2, rawScore) * 5;
        }

        private int GetUpperScore(string password)
        {
            int rawScore = password.Length - Regex.Replace(password, "[A-Z]", "").Length;
            return Math.Min(2, rawScore) * 5;
        }

        private int GetDigitScore(string password)
        {
            int rawScore = password.Length - Regex.Replace(password, "[0-9]", "").Length;
            return Math.Min(2, rawScore) * 5;
        }

        private int GetSymbolScore(string password)
        {
            int rawScore = Regex.Replace(password, "[a-zA-Z0-9]", "").Length;
            return Math.Min(2, rawScore) * 5;
        }
        private int GeneratePasswordScore(string password)
        {
            if (password == null)
            {
                return 0;
            }

            int lengthScore = GetLengthScore(password);
            int lowerScore = GetLowerScore(password);
            int upperScore = GetUpperScore(password);
            int digitScore = GetDigitScore(password);
            int symbolScore = GetSymbolScore(password);

            return lengthScore + lowerScore + upperScore + digitScore + symbolScore;
        }
        public enum PasswordStrength
        {
            Kabul_Edilemez,
            Zayif,
            Normal,
            Guclu,
            Guvenli
        }

        /// <summary>
        /// bu method cagirilacak
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public PasswordStrength GetPasswordStrength(string password)
        {
            int score = GeneratePasswordScore(password);
            if (score < 50)
                return PasswordStrength.Kabul_Edilemez;
            else if (score < 60)
                return PasswordStrength.Zayif;
            else if (score < 80)
                return PasswordStrength.Normal;
            else if (score < 90)
                return PasswordStrength.Guclu;
            else
                return PasswordStrength.Guvenli;
        }
    }
}
