using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine;

public class Goal : MonoBehaviour
{
  GameObject goalText;
  private bool isGoal = false;
  // [DllImport("__Internal")]
  // private static extern void StartEyeDetection();

  AudioSource audioSource;

  void Start()
  {
    goalText = GameObject.Find("Canvas").transform.Find("GoalText").gameObject;
    audioSource = GetComponent<AudioSource>();
  }
  // ぶつかった際に呼ばれるメソッド
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Player" && !isGoal)
    {
      audioSource.PlayOneShot(audioSource.clip);
      goalText.SetActive(true);

      // StartEyeDetection();

      Quit();
    }
  }

  void Quit()
  {
    // isGoal = true;
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
  }
}
