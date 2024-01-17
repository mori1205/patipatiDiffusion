using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_and_Jump : MonoBehaviour
{
  private Animator animator;

  [SerializeField]
  private float speed = 1.0f; // 通常の速度

  [SerializeField]
  private float jumpSpeed = 0.5f; // ジャンプ中の速度


  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
    animator.SetBool("isRun", true); // 初期状態を走りに設定
  }

  // Update is called once per frame
  void Update()
  {
    float currentSpeed = animator.GetBool("isJump") ? jumpSpeed : speed; // ジャンプ中かどうかで速度を変更
    transform.position += transform.forward * Time.deltaTime;

    AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
    if (state.IsName("Jump") && state.normalizedTime > 1.0f)
    {
      animator.SetBool("isJump", false);
      // ここで走りアニメーションを開始する
      animator.SetBool("isRun", true);
    }

    // スペースキーが押されたときだけジャンプを実行
    // if (Input.GetKey(KeyCode.Space))
    // {
    //     // Debug.Log("ジャンプ");
    //     // ジャンプアニメーションを開始
    //     animator.SetBool("isJump", true);
    //     animator.SetBool("isRun", false);
    // }

    // // ジャンプが終了したら再びRunアニメーションに切り替え
    // AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
    // if (state.IsName("Jump"))
    // {
    //     animator.SetBool("isJump", false);
    //     animator.SetBool("isRun", true);
    // }
  }

  public void PerformJump()
  {

    if (!animator.GetBool("isJump")) // ジャンプ中でなければジャンプを実行
    {
      animator.SetBool("isRun", false); // 走りを停止
      animator.SetBool("isJump", true); // ジャンプを開始
    }
  }

  void OnTriggerEnter(Collider other) 
  {
    if(other.CompareTag("Coin"))
    {
      Destroy(other.gameObject); // コインを破壊する
    }  
  }

}
