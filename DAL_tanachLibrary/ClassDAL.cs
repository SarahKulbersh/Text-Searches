using Newtonsoft.Json;

namespace DAL_tanachLibrary;

public class ClassDAL
{
    // converts from json file to dictionary
    public static string readDic()
    {
        string text = File.ReadAllText("C:/Programming/C#/project/tanachLetterIndex.Json");
        return text;
    }
    public static string readFile()
    {
        string text = File.ReadAllText("C:/Programming/C#/project/tanachWithChanges.txt");
        return text;
    }
    public static Dictionary<String, List<int>> convertFromJsonToDictionary()
    {
        Dictionary<String, List<int>> WordIndexDictionary;
        WordIndexDictionary = JsonConvert.DeserializeObject<Dictionary<String, List<int>>>(readDic());
        return WordIndexDictionary;
    }
}