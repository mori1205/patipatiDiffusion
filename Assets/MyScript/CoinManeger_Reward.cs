using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManeger_Reward : MonoBehaviour
{
  [SerializeField] int point = 1;
  private GameObject scoreText;
  private ScoreManeger_Reward scoreManeger;

  private void Start()
  {
    scoreText = GameObject.Find("ScoreText");
    scoreManeger = scoreText.GetComponent<ScoreManeger_Reward>();
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(new Vector3(0, 0, 0.5f)); //コインを回転
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      GetScore();
    }
  }

  void GetScore()
  {
    scoreManeger.score = scoreManeger.score + point;
    //コインを消滅
    Destroy(this.gameObject);
  }
}
