using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class obstacle_reward : MonoBehaviour
{
  GameObject FightText; // Assign the GameOverText object in the Inspector
  private bool isFight = false;

  // JavaScript関数を呼び出す
  // [DllImport("__Internal")]
  // private static extern void StartEyeDetection();

  void Start()
  {
    FightText = GameObject.Find("Canvas").transform.Find("FightText").gameObject;

  }
  void OnTriggerEnter(Collider collider)
  {
    if (!isFight && collider.gameObject.tag == "Player")
    {
      // StartEyeDetection();
      FightText.SetActive(true);
      isFight = true;
      // Time.timeScale = 0f; // Stop the game
    }
  }
  void OnTriggerExit(Collider collider)
  {
    if (collider.gameObject.tag == "Player")
    {
      isFight = false;
      FightText.SetActive(false);
    }
  }
}