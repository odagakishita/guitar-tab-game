using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aboutHamon : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer hamons = Instantiate(sr, new Vector3(TouchDelete.disappearPoint.x,2, TouchDelete.disappearPoint.z), Quaternion.identity);
    }
}
