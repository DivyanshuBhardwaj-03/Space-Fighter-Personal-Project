using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public InputField input_Player_Name;
   // public Text show_Player_Name;
    public Canvas canvas;
   

   // private XMLManager xMLManager;
    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

     //   xMLManager = GameObject.Find("High-Score").GetComponent<XMLManager>();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        canvas.gameObject.SetActive(false);
       // PlayerController.Instance.canvas.gameObject.SetActive(true);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void HighScoreDisplay()
    {
        canvas.gameObject.SetActive(false);
        SceneManager.LoadScene(2);
      //  XMLManager.Instance.Load();
        
     //   HighScores.Instance.canvas.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
