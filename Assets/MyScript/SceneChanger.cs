using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
  bool penalty = false;
  bool reward = false;
  bool Obstacle = false;

  // void Start() {
  //   Debug.Log("")
  // }

  void Update()
  {
    Debug.Log("");
    if (penalty == true || Input.GetKey(KeyCode.Q))
    {
      SceneManager.LoadScene("Penalty", LoadSceneMode.Single);
    }

    if (reward == true || Input.GetKey(KeyCode.W))
    {
      SceneManager.LoadScene("Reward", LoadSceneMode.Single);
    }
    if (Obstacle == true || Input.GetKey(KeyCode.E))
    {
      SceneManager.LoadScene("Obstacle", LoadSceneMode.Single);
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

  public void obstacle()
  {
    Obstacle = true;
  }
}
