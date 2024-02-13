using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    //[SerializeField]
    //[Tooltip("発生させるエフェクト(パーティクル)")]
    //private ParticleSystem particle;
    public static Vector3 hitPos;
  [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
    private ParticleSystem particle;
 
  public AudioClip sound;
  
  public AudioClip sound2;
  
  public AudioClip sound3;
  
  public AudioClip sound4;
  
  public AudioClip sound5;
  
  public AudioClip sound6;
  AudioSource audio1;


  //public static Vector3 resetPoint;
  void Start()
  {
    Application.targetFrameRate = 60;
    audio1 = gameObject.AddComponent<AudioSource>();

  }
  void OnTriggerEnter(Collider other)
  {

        if (other.gameObject.tag == "notes" || other.gameObject.tag == "basenotes")

        {
            hitPos = other.gameObject.transform.position;
            ParticleSystem newParticle = Instantiate(particle);
            newParticle.transform.position = hitPos;
            newParticle.Play();
            ParticleSystem.MainModule par = newParticle.GetComponent<ParticleSystem>().main;

            if(hitPos.z == -10){

              audio1.PlayOneShot(sound);

            }
            if(hitPos.z == -5){

              audio1.PlayOneShot(sound2);
            }
            if(hitPos.z == 0){

              audio1.PlayOneShot(sound3);
            }
            if(hitPos.z == 5){

              audio1.PlayOneShot(sound4);
            }
            if(hitPos.z == 10){

              audio1.PlayOneShot(sound5);
            }
            if(hitPos.z == 15){

              audio1.PlayOneShot(sound6);
            }
            // 0.2秒後に消える

            Destroy(other.gameObject, 0.2f);

        }
  }
}
