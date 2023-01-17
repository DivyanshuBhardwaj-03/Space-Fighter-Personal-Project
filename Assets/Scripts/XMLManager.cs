using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Linq;
public class XMLManager : MonoBehaviour
{
    public static XMLManager Instance;
    public Leaderboard leaderboard;
    List<HighScoreEntry> scores;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        if (!Directory.Exists(Application.persistentDataPath + "/HighScores/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/HighScores/");
        }
    }

  
    
  

    public void SaveScores(List<HighScoreEntry> scoresToSave)
    {
        leaderboard.list = scoresToSave;
        XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
        if(!File.Exists(Application.persistentDataPath + "/HighScores/highscores.xml"))
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Create);
            serializer.Serialize(stream, leaderboard);
            stream.Close();
        }
        else
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.persistentDataPath + "/HighScores/highscores.xml");
           // XmlNode list = doc.CreateNode(XmlNodeType.Element,"list",null);
            XmlNode parentNode = doc.SelectSingleNode("Leaderboard/list");
            XmlElement highScoreEntry = doc.CreateElement("HighScoreEntry");
            parentNode.AppendChild(highScoreEntry);

            XmlElement name = doc.CreateElement("name");
            XmlElement score = doc.CreateElement("score");
            name.InnerText = HighScores.Instance.best_Player_Name;
            score.InnerText = (HighScores.Instance.best_Player_Score).ToString();
           // parentNode.InsertAfter(highScoreEntry, parentNode.FirstChild);

            highScoreEntry.AppendChild(name);
            highScoreEntry.AppendChild(score);
          //  doc.DocumentElement.AppendChild(highScoreEntry);
          //  doc.DocumentElement.AppendChild(list);
            doc.Save(Application.persistentDataPath + "/HighScores/highscores.xml");
           /* FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Append);
            serializer.Serialize(stream, leaderboard);
            stream.Close();
           */
        }
       /* FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();*/
    }

    public List<HighScoreEntry> LoadScores()
    {
        if(File.Exists(Application.persistentDataPath + "/HighScores/highscores.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
            FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            
        }
        return leaderboard.list;
    }
    [System.Serializable]
    public class Leaderboard
    {
        public List<HighScoreEntry> list = new List<HighScoreEntry>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
