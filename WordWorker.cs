using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapFlab
{
    public static class WordWorker
    {
        public static string SyllableMaker(this string word)
        {
            if (word.Length < 2)
                return word;
            string[] glas = { "а", "у", "е", "ё", "ы", "о", "я", "и", "э", "ю" };// глассные
            word = word.ToLower();

            List<int> glasIndexes = new List<int>();//индексы глассных 
            for (int i = 0; i < word.Length; i++)//перебираем слово
            {
                string symbol = word.Substring(i, 1);//берем символ
                for (int j = 0; j < glas.Length; j++)
                {
                    if (symbol == glas[j])
                    {
                        glasIndexes.Add(i);
                        break;
                    }
                }
            }
            string result = string.Empty;
            for (int i = glasIndexes.Count - 1; i > 0; i--)
            {
                //if (glasIndexes[i] - glasIndexes[i - 1] == 1)
                //    continue;
                string symbol = word.Substring(glasIndexes[i] - 1, 1);
                if (symbol == "ь" || symbol == "ъ")
                {
                    int n = glasIndexes[i] - glasIndexes[i - 1] - 1;
                    result = "-" + word.Substring(glasIndexes[i]) + result;
                    word = word.Remove(glasIndexes[i]);
                }
                else
                {
                    int n = glasIndexes[i] - glasIndexes[i - 1] - 1;
                    int ind = glasIndexes[i - 1] + 1 + n / 2;
                    symbol = word.Substring(ind, 1);
                    if (symbol == "ь" || symbol == "ъ") ind++;

                    result = "-" + word.Substring(ind) + result;
                    word = word.Remove(ind);
                }
            }
            result = word + result;
            ///////////////////////////////////////////

            string res = string.Empty;

            for (int d = 0; d != result.Split('-').Length; d++)// убираем малые слоги
            {
                if (result.Split('-')[d].Length > 1)
                {
                    res += result.Split('-')[d] + "-";
                }
                else //if (result.Split('-')[d].Length < 3)
                {
                    res += result.Split('-')[d];
                }
            }

            string ress1 = string.Empty;
            for (int d = 0; d != res.Split('-').Length; d++)//убираем первый короткий слог
            {
                if (d == 0 && res.Split('-')[d].Length < 4)
                {
                    ress1 += res.Split('-')[d];
                }
                else //if (result.Split('-')[d].Length < 3)
                {
                    ress1 += res.Split('-')[d] + "-";
                }
            }
            res = string.Empty;
            for (int d = 0; d != ress1.Split('-').Length; d++)
            {
                if (d == 0 && ress1.Split('-')[d].Length < 4)
                {
                    res += ress1.Split('-')[d];
                }
                else //if (result.Split('-')[d].Length < 3)
                {
                    res += ress1.Split('-')[d] + "-";
                }
            }

            

            return res.ToString(); //кора-быль---
        }
    }
}