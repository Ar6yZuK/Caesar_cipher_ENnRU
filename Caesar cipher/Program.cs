using System;

namespace Caesar_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string str = "";
                int shiftInt = 1;
                {
                    Console.Write("Введи сдвиг(от -33 до 33 или -26 до 26):");
                    if (int.TryParse(Console.ReadLine(), out shiftInt))
                    {
                        Console.Write("Введи текст(английские и русские символы будут сдвинуты):");
                        str = Console.ReadLine();
                        if (!string.IsNullOrEmpty(str))
                        {
                            Console.WriteLine(Cipher.Encypt(str, shiftInt));
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
            }

        }
    }
    class Cipher
    {
        const string alphabetru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; // 33 длина
        const string alphabetRU = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; // 33 длина
        const string alphabeten = "abcdefghijklmnopqrstuvwxyz"; // 26 lenght
        const string alphabetEN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // 26 lenght

        /// <summary>
        /// Возвращает true если в строке <paramref name="str"/> в позиции <paramref name="Index"/> английская буква.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        static public bool IsEnglish(string str, int Index)
        {
            for (int i = 0; i < alphabeten.Length; i++)
            {
                if (str[Index] == alphabeten[i])
                {
                    return true;
                }
            }
            for (int i = 0; i < alphabetEN.Length; i++)
            {
                if (str[Index] == alphabetEN[i])
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Возвращает true если в строке <paramref name="str"/> в позиции <paramref name="Index"/> русская буква.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        static public bool IsRussian(string str, int Index)
        {
            for (int i = 0; i < alphabetru.Length; i++)
            {
                if (str[Index] == alphabetru[i])
                {
                    return true;
                }
            }
            for (int i = 0; i < alphabetRU.Length; i++)
            {
                if (str[Index] == alphabetRU[i])
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Возвращает true если буква в позиции <paramref name="Index"/> в строке <paramref name="str"/> из английского или русского алфавита заглавная.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        static public bool IsUpper(string str, int Index)
        {
            if (IsRussian(str, Index))
            {
                for (int i = 0; i < alphabetRU.Length; i++)
                {
                    if (str[Index] == alphabetRU[i])
                    {
                        return true;
                    }
                }
            }
            else if (IsEnglish(str, Index))
            {
                for (int i = 0; i < alphabetEN.Length; i++)
                {
                    if (str[Index] == alphabetEN[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Возвращает true если буква в позиции <paramref name="Index"/> в строке <paramref name="str"/> из английского или русского алфавита прописная.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        static public bool IsLower(string str, int Index)
        {
            if (IsRussian(str, Index))
            {
                for (int i = 0; i < alphabetru.Length; i++)
                {
                    if (str[Index] == alphabetru[i])
                    {
                        return true;
                    }
                }
            }
            else if (IsEnglish(str, Index))
            {
                for (int i = 0; i < alphabeten.Length; i++)
                {
                    if (str[Index] == alphabeten[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static public string Encypt(string str, int shift)
        {
            string str2 = "";
            for (int i = 0; i < str.Length && str2.Length <= str.Length; i++)
            {
                if (IsRussian(str, i))
                {
                    if (IsLower(str, i))
                    {
                        for (int j = 0; j < alphabetru.Length && str2.Length <= str.Length; j++)
                        {
                            if (str[i] == alphabetru[j])
                            {
                                str2 += alphabetru[(Math.Abs((alphabetru.Length + shift + j)) % alphabetru.Length)];
                                break;
                            }
                        }
                    }
                    else if (IsUpper(str, i))
                    {
                        for (int j = 0; j < alphabetRU.Length && str2.Length <= str.Length; j++)
                        {
                            if (str[i] == alphabetRU[j])
                            {
                                str2 += alphabetRU[(Math.Abs((alphabetRU.Length + shift + j)) % alphabetRU.Length)];
                                break;
                            }
                        }
                    }
                    else
                    {
                        str2 += str[i];
                    }
                }
                else if (IsEnglish(str, i))
                {
                    if (IsLower(str, i))
                    {
                        for (int j = 0; j < alphabeten.Length && str2.Length <= str.Length; j++)
                        {
                            if (str[i] == alphabeten[j])
                            {
                                str2 += alphabeten[(Math.Abs((alphabeten.Length + shift + j)) % alphabeten.Length)];
                                break;
                            }
                        }
                    }
                    else if (IsUpper(str, i))
                    {
                        for (int j = 0; j < alphabetEN.Length && str2.Length <= str.Length; j++)
                        {
                            if (str[i] == alphabetEN[j])
                            {
                                str2 += alphabetEN[(Math.Abs((alphabetEN.Length + shift + j)) % alphabetEN.Length)];
                                break;
                            }
                        }
                    }
                    else
                    {
                        str2 += str[i];
                    }
                }
                else
                {
                    str2 += str[i];
                }
            }
            return str2;
        }
    }
}
