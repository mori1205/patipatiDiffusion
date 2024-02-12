using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MistPlace : MonoBehaviour
{
  // Start is called before the first frame update
  [DllImport("__Internal")]
  private static extern void StartEyeDetection();
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  void OnTriggerEnter(Collider collider)
  {
    Debug.Log("Mist");
    StartEyeDetection();
  }
}
