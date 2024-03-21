using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Note : MonoBehaviour
{
  GameObject noteText;
  private bool isNote = false;


  void Start()
  {
    noteText = GameObject.Find("Canvas").transform.Find("NoteText").gameObject;
  }
  // ぶつかった際に呼ばれるメソッド
  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Player" && !isNote)
    {
      Debug.Log("warning");
      noteText.SetActive(true);
      isNote = true;
      StartCoroutine(DeactivateNoteText());
    }

  }
  IEnumerator DeactivateNoteText()
  {
    yield return new WaitForSeconds(1); // Change the delay time as needed
    noteText.SetActive(false);
    isNote = false;
  }
}
