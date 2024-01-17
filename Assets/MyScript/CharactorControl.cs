using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterControl : MonoBehaviour
{
  CharacterController controller;

  public float gravity = 10f;
  private float jumpSpeed = 3.0f;
  public float moveSpeed = 5f; // 前進する速度

  Vector3 moveDirection;

  private bool jumpUpEnd = false;

  bool isJumping = false;
  [SerializeField] float jumpTime;

  void Start()
  {
    controller = GetComponent<CharacterController>();
  }

  void Update()
  {
    if (controller.isGrounded) //キャラクターが地面についている時
    {
      if (Input.GetButtonDown("Jump") || isJumping)
      {
        moveDirection.y = jumpSpeed;
        jumpUpEnd = false;
        jumpTime = 0;
      }
    }
    else
    { //キャラクターが地面についていない時
      if (Input.GetButton("Jump") || (jumpTime < 3f && isJumping)) //ジャンプしている時
      {
        jumpTime += Time.deltaTime;
        moveDirection.y = jumpSpeed;
      }

      if (Input.GetButtonUp("Jump") || (!jumpUpEnd && !isJumping)) //ボタンを離した時
      {
        jumpUpEnd = true;
      }
    }

    // 自動で前進する
    moveDirection.z = moveSpeed;

    moveDirection.y -= gravity * Time.deltaTime;

    controller.Move(moveDirection * Time.deltaTime);
  }

  public void PerformJump()
  {
    isJumping = true;
    // animSpeed = 0f;
  }

  public void StopJump()
  {
    isJumping = false;
  }
}
