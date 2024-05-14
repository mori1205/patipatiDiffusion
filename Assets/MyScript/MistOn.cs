using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Linq;

public class MistOn : MonoBehaviour
{
  //点眼処理
  [DllImport("__Internal")]
  private static extern void StartEyeDetection();

  //噴霧壁を配列に入れる
  public List<GameObject> mistWalls;

  // 0から4までの数字のリストを作成
  List<int> numbers;
  // 重複なしで3つの数字をランダムに選ぶ
  List<int> selectedNumbers;

  void Start()
  {
    // mistWalls = new List<GameObject>();
    numbers = Enumerable.Range(0, 5).ToList();
    selectedNumbers = new List<int>();

    for (int i = 0; i < 3; i++) // 条件式を修正
    {
      int index = Random.Range(0, numbers.Count);
      selectedNumbers.Add(numbers[index]);

      numbers.RemoveAt(index);
    }
    selectedNumbers.Sort(); // 数字を小さい順にソート
    // selectedNumbers.Add(0);
    // selectedNumbers.Add(2);
    // selectedNumbers.Add(4);
    
    for (int i = 0; i < selectedNumbers.Count; i++)
    {
      Debug.Log(selectedNumbers[i]);
    }
  }

  void OnTriggerEnter(Collider collider)
  {
    Debug.Log("Detection");
    // foreach (int index in selectedNumbers)
    // {
    //   if (collider.gameObject.tag == "mist" && index < mistWalls.Count && collider.gameObject == mistWalls[index]) // indexが範囲内かどうかをチェック
    //   {
    //     Debug.Log("Detection");
    //     StartEyeDetection();
    //   }
    // }

    for (int i = 0; i < selectedNumbers.Count; i++)
    {
      Debug.Log(selectedNumbers[i]);
    }
    Debug.Log("mistwall count = " +mistWalls.Count);


    for (int i = 0; i < selectedNumbers.Count; i++)
    {
      Debug.Log("Dete");
      Debug.Log("プレイヤー当たった" + collider.gameObject.name);
      Debug.Log(mistWalls[selectedNumbers[i]]);

      if (collider.gameObject.tag == "Mist" && selectedNumbers[i] < mistWalls.Count && collider.gameObject.name == mistWalls[selectedNumbers[i]].name) // indexが範囲内かどうかをチェック
      //collider.gameObject.tag == "mist" && selectedNumbers[i] < mistWalls.Count && collider.gameObject.GetInstanceID() == mistWalls[selectedNumbers[i]].GetInstanceID()
      {
        Debug.Log("Detectiony");
        StartEyeDetection();
      }
    }

  }
}
//  && selectedNumbers[i] < mistWalls.Count && collider.gameObject == mistWalls[selectedNumbers[i]]