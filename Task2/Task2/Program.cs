using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Businesslogic;
using Task2.Contracts;
using Task2.Model;

namespace Task2
{
    /*
    Создать программу обработки текста учебника по программированию с использованием классов: Символ, Слово, Предложение, Знак препинания и др. 
    (состав и иерархию классов продумать самостоятельно). Во всех задачах с формированием текста заменять табуляции и последовательности пробелов одним пробелом.
 
Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Reader textReader = new Reader("text.txt");
            TrimmedText trimmedText = new TrimmedText(textReader.Read());
            Console.WriteLine(trimmedText.ToString());
            Worker worker = new Worker(trimmedText);
            foreach (var a in worker.SortSentencesInAscendingOrderOfTheNumberOfWords())
            {
                Console.WriteLine(a);
            }
            foreach (var a in worker.GetQuestionSentences())
            {
                Console.WriteLine(a);
            }
            foreach (string s in worker.FindWordsByLenght(2))
            {
                Console.WriteLine(s);
            }
            worker.DeleteWords(1);
            worker.ReplaceWords(1, 2, "qwertttttttttttttttttt");
            Console.WriteLine(trimmedText.ToString());
            Console.ReadLine();
        }
    }
}
