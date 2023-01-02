using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Rigidbody playerRb;
    public GameObject laserPrefab;
    private AudioSource playerAudio;
    public AudioClip laserSound;
    private float speed = 8.0f;
    private float xBound = 8.5f;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeCountText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button highScoreButton;
    private int score;
    private int lifeCount;
    public bool isGameActive;

    public TextMeshProUGUI show_Current_Player;
  //  public Text show_Best_Player;
    private string temp_Player_Name;
    [HideInInspector]
    public string player_Name;
   // public int player_Score; 
   // List<HighScoreEntry> scores;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody Component of Player
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        isGameActive = true;
        UpdateScore(0);
        UpdateLife(5);

        // Debug.Log (typeof(GameObject).ToString());

    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        New_Player_Name();
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
        
    }

    // Moving player along x Axis using arrow key inputs
    void MovePlayer()
    { 
        if (isGameActive)
        {

        float horizontalInput = Input.GetAxis("Horizontal");

       // transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);    // transform.Translate allows to move object irrespective of the presence of Rigidbody component
        playerRb.AddForce(Vector3.right * horizontalInput * speed);                         // We can use AddForce to move oject when Rigidody component is attached to it

        // Using Spacebar to shoot projectile
  if (Input.GetKeyDown(KeyCode.Space))
       {
            Instantiate(laserPrefab, this.transform.position, laserPrefab.transform.rotation);
            playerAudio.PlayOneShot(laserSound,0.8f);
       }
  
    }

    }

    // Constraining Player area of Movement on x Axis
    void ConstrainPlayerPosition()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    // Updating Score Count
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
       // player_Score = score;
    }

    // Updating Life Count
    public void UpdateLife(int lifetoAdd)
    {
        lifeCount += lifetoAdd;
        lifeCountText.text = "Life : " + lifeCount;
        if (lifeCount < 1)
        {
            GameOver();
        }
    }

    // Displaying GameOver Screen
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        show_Current_Player.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        highScoreButton.gameObject.SetActive(true);
        Display_Current_Player(temp_Player_Name, score);
        HighScores.Instance.PlayerData();
       // Save_High_Scores();
      // HighScores.best_Score = score;
      // HighScores.best_Player_Name = temp_Player_Name;
     //  XMLManager.Instance.Save();
    }

    // Restart Game on Button Click
    public void RestartGame()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }

    public void New_Player_Name()
    {
        temp_Player_Name = MenuManager.Instance.input_Player_Name.text;
        player_Name = temp_Player_Name;
    }

    public void Display_Current_Player(string name, int points)
    {
        show_Current_Player.text = $"Your Score : {name} : {points}";
    }

    /*void Save_High_Scores()
    {
        HighScores.Instance.AddNewScore(player_Name,player_Score);
    }*/

    public void HighScoreMenu()
    {
       // XMLManager.Instance.Load();
        SceneManager.LoadScene(2);
    }
}
