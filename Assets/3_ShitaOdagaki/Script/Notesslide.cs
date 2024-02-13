using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notesslide : MonoBehaviour
{

  void Start()
  {
        //GetComponent<Renderer>().material.color = new Color32(248, 168, 133, 1);
        Application.targetFrameRate = 60;
    }
  void Update()
  {

      
      Transform myTransform = this.transform;

      Vector3 pos = myTransform.position;

      pos.x -= 0.3f;

      myTransform.position = pos;


  }
}
