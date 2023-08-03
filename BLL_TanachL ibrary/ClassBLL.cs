using DAL_tanachLibrary;
using Newtonsoft.Json;

namespace BLL_TanachLibrary
{
    public class ClassBLL
    {
        public static void fillDictionaryLetterIndex(string fileContent)
        {

            int count = 0;
            Dictionary<string, List<int>> WordIndexDictionary = new Dictionary<string, List<int>>();

            string[] fileContentArray = fileContent.Split();

            for (int i = 0; i < fileContentArray.Length; i++)
            {
                var currentWord = fileContentArray[i];
                bool b = WordIndexDictionary.ContainsKey(currentWord);
                if (b)
                {
                    WordIndexDictionary[currentWord].Add(count);
                }
                else
                {
                    WordIndexDictionary.Add(currentWord, new List<int>());
                    WordIndexDictionary[currentWord].Add(count);
                }
                count = count+fileContentArray[i].Length+1;
            }
            string js = JsonConvert.SerializeObject(WordIndexDictionary);

            File.WriteAllText("C:/sarah kayla/Programing/C#/project/tanachLetterIndex7.Json", js);
        }


        // loop through the dictionry get the list of indexes where the word appears
        // returns the number of the word in a string
        public static string searchDictionary(String currentWord)
        {
            Dictionary<String, List<int>> WordIndexDictionary = ClassDAL.convertFromJsonToDictionary();
            List<int> keyList = new List<int>();
            keyList = WordIndexDictionary[currentWord];
            String strIndexes = " ";
            foreach (int key in keyList)
            {
                strIndexes += key.ToString() + " ";
            }
            return strIndexes;
        }

        // list of indexes of letter that the word starts for highlighting
        // works for any string not just a full word
        public static List<int> highlight(string word, string all)
        {
            List<int> keyListLetter = new List<int>();
            string str = all;
            int place = str.IndexOf(word);
            while (place != -1)
            {
                keyListLetter.Add(place);
                place = str.IndexOf(word, place + word.Length);
            }
            return keyListLetter;
        }

        // returns the list of the letters searched
        public static List<int> indexOfLetter(string word)
        {
            List<int> keyListLetter = new List<int>();
            Dictionary<String, List<int>> WordIndexDictionary = ClassDAL.convertFromJsonToDictionary();
            keyListLetter = WordIndexDictionary[word];
            return keyListLetter;
        }

        // returns a list of indexes where the word appears
        public static List<int> searchDictionary1(String currentWord)
        {
            Dictionary<String, List<int>> WordIndexDictionary = ClassDAL.convertFromJsonToDictionary();
            List<int> keyList = new List<int>();
            keyList = WordIndexDictionary[currentWord];
           
            return keyList;
        }
    }
}