using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
  public float jumpPower;
  private Rigidbody rb;
  private bool isJumping = false;
  public static Vector3 disappearPoint;

    // Start is called before the first frame update
    void Start()
    {

      rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown (KeyCode.UpArrow)) {
          this.transform.Translate (0, 0, 10);
      }
      if (Input.GetKeyDown (KeyCode.DownArrow)) {
          this.transform.Translate (0, 0, -10);
      }
      if (Input.GetKeyDown(KeyCode.RightArrow)) {
          this.transform.Translate (5, 0, 0);
       }
      if (Input.GetKeyDown(KeyCode.LeftArrow)) {
          this.transform.Translate (-5, 0, 0);
      }
      if(Input.GetKeyDown(KeyCode.Space)&& !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;


            isJumping = true;

        }

      //Debug.Log(disappearPoint);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }



}
