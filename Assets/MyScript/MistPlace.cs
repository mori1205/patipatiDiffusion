using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

// public class MistPlace : MonoBehaviour
// {
//   [DllImport("__Internal")]
//   private static extern void StartEyeDetection();

//   // public GameObject[] objects; // 5つのオブジェクト
//   // public int objectsToSelect = 3; // 選択するオブジェクトの数


//   // List<GameObject> selectedObjects = new List<GameObject>(); // 選択されたオブジェクトのリスト
//   // private int playerCollisionCount = 0; // プレイヤーとの衝突回数

//   void Start()
//   {
//     // SelectObjects();
//     // // 選択されたオブジェクトを表示
//     // foreach (GameObject obj in selectedObjects)
//     // {
//     //   Debug.Log("Selected Object: " + obj.name);
//     // }
//   }

  // void SelectObjects()
  // {
  //   // ランダムにオブジェクトを選択する
  //   // List<GameObject> indexes = new List<GameObject>();

  //   List<int> indexes = new List<int>();

  //   for (int i = 0; i < objectsToSelect; i++)
  //   {
  //     int randomIndex;
  //     do
  //     {
  //       randomIndex = Random.Range(0, objects.Length);
  //     } while (indexes.Contains(randomIndex));

  //     indexes.Add(randomIndex);
  //     selectedObjects.Add(objects[randomIndex]);
  //     Debug.Log(randomIndex);
  //   }
  //   // selectedObjects.Sort((a, b) => a.name.CompareTo(b.name)); // オブジェクトを名前でソートする（小さい順）
  // }

//   void OnTriggerEnter(Collider collision)
//   {
//     Debug.Log("sssss");
//     if (collision.gameObject.tag == "Player")
//     {
//     //   playerCollisionCount++;

//     //   if (selectedObjects.Contains(collision.gameObject))
//     //   {
//     //     Debug.Log("Player collided with selected object!");
//     //     if (playerCollisionCount >= objectsToSelect)
//     //     {
//     //       Debug.Log("aaaaaa");
//     //       TriggerEvent();
//     //     }
//     //   }
//     //   else
//     //   {
//     //     Debug.Log("non-selected");
//     //   }
//     Debug.Log("non-selected");
//     }
//   }

//   // void TriggerEvent()
//   // {
//   //   // 選択されたオブジェクトにイベントを発生させる
//   //   foreach (GameObject obj in selectedObjects)
//   //   {
//   //     if (obj != null)
//   //     {
//   //       Debug.Log("StartDetection");
//   //       StartEyeDetection();
//   //     }
//   //   }
//   // }
// }

public class MistPlace : MonoBehaviour
{
  public List<GameObject> objects = new List<GameObject>(); // OnTriggerを検知するオブジェクトのリストを初期化

  void Start()
  {
    if (objects.Count < 3)
    {
      Debug.LogError("Objects list does not contain enough objects.");
      return;
    }

    // リストからランダムに3つのオブジェクトを選択
    List<GameObject> selectedObjects = new List<GameObject>();
    while (selectedObjects.Count < 3)
    {
      int randomIndex = Random.Range(0, objects.Count);
      GameObject selectedObject = objects[randomIndex];
      if (!selectedObjects.Contains(selectedObject))
      {
        selectedObjects.Add(selectedObject);
      }
    }

    // 選択された3つのオブジェクトにRigidbodyと当たり判定を追加
    foreach (GameObject obj in selectedObjects)
    {
      Rigidbody rb = obj.AddComponent<Rigidbody>();
      rb.isKinematic = true; // 他のオブジェクトに影響を与えないようにする

      BoxCollider collider = obj.AddComponent<BoxCollider>(); // ここを適切な当たり判定に変更してください
      collider.isTrigger = true; // OnTriggerEnterを使用するために必要
    }
  }

  void OnTriggerEnter(Collider other)
  {
    // 衝突したオブジェクトが選択されたオブジェクトの中にあるかチェック
    if (objects.Contains(other.gameObject))
    {
      Debug.Log("Collision detected with " + other.gameObject.name);
    }
  }
}
