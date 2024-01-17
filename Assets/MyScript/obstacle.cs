using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obstacle : MonoBehaviour
{
  GameObject gameOverText; // Assign the GameOverText object in the Inspector
  private bool isGameOver = false;

  // JavaScript関数を呼び出す
  // [DllImport("__Internal")]
  // private static extern void Motor();

  void Start()
  {
    gameOverText = GameObject.Find("Canvas").transform.Find("GameOverText").gameObject;

    // JavaScript関数を呼び出す
    // Motor();
  }
  void OnTriggerEnter(Collider collider)
  {
    if (!isGameOver)
    {
      gameOverText.SetActive(true);
      isGameOver = true;
      Time.timeScale = 0f; // Stop the game
    }
  }

}