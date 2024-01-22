using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
  bool penalty = false;
  bool reward = false;

  // void Start() {
  //   Debug.Log("")
  // }

  void Update()
  {
    Debug.Log("");
    if (penalty == true || Input.GetKey(KeyCode.Q))
    {
      SceneManager.LoadScene("obstacle_penalty", LoadSceneMode.Single);
    }

    if (reward == true || Input.GetKey(KeyCode.W))
    {
      SceneManager.LoadScene("obstacle_reward", LoadSceneMode.Single);
    }
  }
  public void obstacle_penalty()
  {
    penalty = true;
  }

  public void obstacle_reward()
  {
    reward = true;
  }
}
