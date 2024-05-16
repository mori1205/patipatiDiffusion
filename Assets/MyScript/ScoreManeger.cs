using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
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
    // Debug.Log(score);
    scoreText.text = score.ToString();
  }
}
