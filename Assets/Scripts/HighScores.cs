
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    public static HighScores Instance;
    public HighScoreDisplay[] highScoreDisplayArray;
    public Canvas canvas;
    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    public string best_Player_Name;
    public int best_Player_Score;
    private string best_Player_Score_Text;
    private string[] splitString;
  //  public PlayerController playerController;
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        /* AddNewScore("John", 4500);
         AddNewScore("Max", 5520);
         AddNewScore("Dave", 380);
         AddNewScore("Steve", 6654);
         AddNewScore("Mike", 11021);
         AddNewScore("Teddy", 3252);*/
        // XMLManager.Instance.LoadScores();

       // playerController = GameObject.Find("Player").GetComponent<PlayerController>();

       // XMLManager.Instance.Load();
        UpdateDisplay();
    }

    public void PlayerData()
    {
        best_Player_Name = PlayerController.Instance.player_Name;
        best_Player_Score_Text = PlayerController.Instance.scoreText.text;
        splitString = best_Player_Score_Text.Split(':' );
        // best_Player_Score = int.Parse(best_Player_Score_Text);
        best_Player_Score = int.Parse(splitString[1]);
        //  best_Player_Score = int.Parse(PlayerController.Instance.scoreText.text);
        
        AddNewScore(best_Player_Name, best_Player_Score);
        
        /*  best_Player_Name = playerController.show_Current_Player.text;
          best_Player_Score_Text = playerController.scoreText.text;
          best_Player_Score = int.Parse(best_Player_Score_Text);
          AddNewScore(best_Player_Name, best_Player_Score);*/
    }
    // Update is called once per frame
    void UpdateDisplay()
    {

        scores = XMLManager.Instance.LoadScores();

        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));
        for( int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
       
        
    }


  void AddNewScore(string entryName, int entryScore)
  {
      scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
     Save();
  }

  /**/  private void Save()
    {
        XMLManager.Instance.SaveScores(scores);
    }

    public void MainMenu()
    {
      
        canvas.gameObject.SetActive(false);
      //
        SceneManager.LoadScene(0);
      //  canvas.gameObject.SetActive(true);
       // StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByBuildIndex(0)));
        
       MenuManager.Instance. canvas.gameObject.SetActive(true);
        // SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));

    }
    public IEnumerator WaitForSceneLoad(Scene scene)
    {
        while(scene.isLoaded == false)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(scene);
        
    }
}

