using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class ScoreManeger_Obstacle : MonoBehaviour
{
  private Text scoreText;
  public int score = 0;

 

  // Start is called before the first frame update
  void Start()
  {
    scoreText = GetComponent<Text>();
    scoreText.text = "0";
  }

  // Update is called once per frame
  void Update()
  {
    scoreText.text = score.ToString();

    if (score >= 15)
    {
      // StartEyeDetection();
      Time.timeScale = 0f; // Stop the game
    }
  }
}
