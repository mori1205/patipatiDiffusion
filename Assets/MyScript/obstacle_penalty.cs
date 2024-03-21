using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class obstacle_penalty : MonoBehaviour
{
  GameObject GameOverText; // Assign the GameOverText object in the Inspector
  // private bool isFight = false;

  // JavaScript関数を呼び出す
  // [DllImport("__Internal")]
  // private static extern void StartEyeDetection();

  void Start()
  {
    // Debug.Log("gameover");
    GameOverText = GameObject.Find("Canvas").transform.Find("GameOverText").gameObject;

  }
  void OnCollisionEnter(Collision collider)
  {
    if (collider.gameObject.tag == "Player")
    {
      // StartEyeDetection();
      Debug.Log("gameover");
      GameOverText.SetActive(true);
      // StartCoroutine(DeactivateFightText());
    }
  }
  

  // IEnumerator DeactivateFightText()
  // {
  //   yield return new WaitForSeconds(1); // Change the delay time as needed
  //   FightText.SetActive(false);
  // }
}