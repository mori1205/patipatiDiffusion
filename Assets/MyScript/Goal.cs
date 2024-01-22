using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

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
  private void OnTriggerEnter(Collider other)
  {
    if (!isGoal)
    {
      goalText.SetActive(true);
      isGoal = true;
      StartEyeDetection();
      Time.timeScale = 0f; // Stop the game
    }
  }
}
