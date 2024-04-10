using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
  public GameObject[] lifeArray = new GameObject[4]; //ライフの数を収納
  private int lifePoint = 4; //ライフの数を設定
  private bool obstacleHit = false; //当たったっか当たってないかの判定
  GameObject GameOverText; //ゲームオーバーになった際に表示させるテキストを表示

  // JavaScript関数を呼び出す
  [DllImport("__Internal")]
  private static extern void StartEyeDetection();

  void Start() 
  {
    GameOverText = GameObject.Find("Canvas").transform.Find("GameOverText").gameObject;
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "obstacle" && !obstacleHit)
    {
      ReduceLife();
      StartCoroutine(InvincibilityTime());
      obstacleHit = true;
    }
  }

  IEnumerator InvincibilityTime()
  {
    yield return new WaitForSeconds(5f);
    obstacleHit = false;
  }

  void ReduceLife()
  {
    if (lifePoint > 0)
    {
      lifeArray[lifePoint - 1].SetActive(false);
      lifePoint--;
    }

    if (lifePoint == 0)
    {
      GameOverText.SetActive(true);
      StartEyeDetection();
    }
  }
}