using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine;

public class Goal : MonoBehaviour
{
  GameObject goalText;
  private bool isGoal = false;
  [DllImport("__Internal")]
  private static extern void StartEyeDetection();
  
  void Start()
  {
    goalText = GameObject.Find("Canvas").transform.Find("GoalText").gameObject;
  }
  // ぶつかった際に呼ばれるメソッド
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      goalText.SetActive(true);
      isGoal = true;
      StartEyeDetection();
      Quit();
      
    }
    // Time.timeScale = 0f; // Stop the game
  }

  void Quit() 
  {
    #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
    #else
      Application.Quit();
    #endif 
  }
}
