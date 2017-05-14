using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Contracts;
using Task2.Enums;
using Task2.Model;

namespace Task2.Businesslogic
{
    public class Worker
    {
        private readonly TrimmedText _trimmedText;

        public Worker(TrimmedText trimmedText)
        {
            _trimmedText = trimmedText;
        }

        public List<string> SortSentencesInAscendingOrderOfTheNumberOfWords()
        {
            return _trimmedText.Sentences.OrderBy(x => x.GetWordsCount()).Select(s => s.Value).ToList();
        }

        public List<string> GetQuestionSentences()
        {
            return _trimmedText.Sentences.Where(x => x.Value.Contains('?')).Select(s => s.Value).ToList();
        }

        public List<string> FindWordsByLenght(int wordLenght)
        {
            List<string> words = new List<string>();
            foreach (ISentence currentsentence in _trimmedText.Sentences.Where(x => x.Value.Contains('?')))
            {
                for (int i = 0; i < currentsentence.GetWordsCount(); i++)
                {
                    var currentElement = currentsentence.GetElementByIndex(i);
                    if (currentElement.SentenceElementType == SentenceElementTypes.Word &
                        currentElement.Value.Length == wordLenght)
                    {
                        words.Add(currentElement.Value);
                    }
                }
            }
            return words;

        }

        public void DeleteWords(int wordLenght)
        {
            var excludes = new HashSet<string> { ",", "." };
            string pattern = @"[aeiou]";
            List<string> edittedSentenceElementList = new List<string>();
            for (int i = 0; i <  _trimmedText.Sentences.Count();i++)
            {
                var sentence = _trimmedText.Sentences.ToList()[i];
                for (int k = 0; k < sentence.GetElementsCount(); k++)
                {
                    var currentElement = sentence.GetElementByIndex(k);
                    if (currentElement.SentenceElementType == SentenceElementTypes.Word &
                        currentElement.Value.Length == wordLenght &
                        !Regex.IsMatch(currentElement.Value.Substring(0, 1), pattern))
                    {
                        currentElement.Value = "";
                    }
                    edittedSentenceElementList.Add(currentElement.Value);
                }
                foreach (var s in edittedSentenceElementList)
                {
                    sentence.Value += excludes.Contains(s) ? s : string.Concat(" ", s);
                }
                // sentence.Value = string.Join(" ", edittedSentenceElementList.Where(x=>!x.Equals("")));
                edittedSentenceElementList.Clear();
            }
        }

        private void ReplaceValue(int wordLenght, ISentenceElement element, string newElement)
        {
            if (element.SentenceElementType == SentenceElementTypes.Word && element.Value.Length == wordLenght)
            {
                element.Value = newElement;
            }
        }

        public void ReplaceWords(int sentenceIndex, int wordLenght, string newValue)
        {
            var currentsentence = _trimmedText.GetSentenceByIndex(sentenceIndex);
            List<string> edittedSentenceElementList = new List<string>();
            for (int i = 0; i < currentsentence.GetWordsCount(); i++)
            {
                var currentElement = currentsentence.GetElementByIndex(i);
                if (currentElement == null) return;
                ReplaceValue(wordLenght, currentElement, newValue);
                edittedSentenceElementList.Add(currentElement.Value);
            }
            currentsentence.Value = string.Join(" ",edittedSentenceElementList);
        }
    }
}



