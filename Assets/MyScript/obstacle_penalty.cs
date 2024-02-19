using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class obstacle_penalty : MonoBehaviour
{
  GameObject gameOverText; // Assign the GameOverText object in the Inspector
  private bool isGameOver = false;

  // JavaScript関数を呼び出す
  [DllImport("__Internal")]
  private static extern void StartEyeDetection();

  void Start()
  {
    gameOverText = GameObject.Find("Canvas").transform.Find("GameOverText").gameObject;

  }
  void OnCollision(Collider collider)
  {
    if (!isGameOver)
    {
      StartEyeDetection();
      gameOverText.SetActive(true);
      isGameOver = true;
      // Time.timeScale = 0f; // Stop the game
    }
  }

}