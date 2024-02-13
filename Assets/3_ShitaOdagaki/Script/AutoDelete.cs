using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class AutoDelete : MonoBehaviour
{

    [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
    private ParticleSystem particle;
    [SerializeField]
    private AudioClip E41;
    [SerializeField]
    private AudioClip E42;
    [SerializeField]
    private AudioClip E43;
    [SerializeField]
    private AudioClip E44;
    [SerializeField]
    private AudioClip E45;
    [SerializeField]
    private AudioClip E51;
    [SerializeField]
    private AudioClip E52;
    [SerializeField]
    private AudioClip E53;
    [SerializeField]
    private AudioClip E54;
    [SerializeField]
    private AudioClip E55;
    [SerializeField]
    private AudioClip E61;
    [SerializeField]
    private AudioClip E62;
    [SerializeField]
    private AudioClip E63;
    [SerializeField]
    private AudioClip E64;
    [SerializeField]
    private AudioClip E65;
    private AudioSource audio3;
    private TextAsset _csvFile;
    private bool hasPlayedSound = false;
    private List<string[]> _csvData = new List<string[]>();
    public static Vector3 basePos;
    [SerializeField]
    GameObject baseobjnotes;
    int instantiatePlace = 0;
    int lagFrame = 0;
    void Start()
    {
        Application.targetFrameRate = 60;
        _csvFile = Resources.Load("basetab") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }
        
        audio3 = gameObject.AddComponent<AudioSource>();
        StartCoroutine(BaseFumen());

    }
    //void SetMatColor(Color col)
    //{
    //    Mat.color = col; //Materialの色を変える
    //}
    void Update()
    {
        // basePos = baseobjnotes.transform.position;
        // if(Input.GetMouseButtonDown(1))
        // {
        //     Debug.Log(basePos);
        // }
        GameObject[] basebase = GameObject.FindGameObjectsWithTag("basenotes");
        
        foreach (GameObject obj in basebase)
        {
            if (obj.transform.position.x < 15 && !hasPlayedSound)
            {
                Destroy(obj);
                    ParticleSystem newParticle = Instantiate(particle);
                    
                    newParticle.transform.position = obj.transform.position;
                    
                    newParticle.Play();
                    ParticleSystem.MainModule par = newParticle.GetComponent<ParticleSystem>().main;
                    par.startColor = Color.yellow;
                    Destroy(newParticle.gameObject, 5.0f);
                if (obj.transform.position.z == -10)
                {
                   
                  Debug.Log("6-3");
                  audio3.PlayOneShot(E63);
                  

                

                }
                if (obj.transform.position.z == -5)
                {
                   Debug.Log("5-3");
                   audio3.PlayOneShot(E53);
                   Debug.Log ("経過時間(秒)" + Time.time);
                }
                if (obj.transform.position.z == 0)
                { 
                  Debug.Log("4-3");
                  audio3.PlayOneShot(E43);
                  

                }
                hasPlayedSound = true;
            }
            else
            {
                hasPlayedSound = false;
            }
        }

    }
      private IEnumerator BaseFumen()
    {
        for (int j = 0; j < 7; j++)
        {
            
            

            switch (_csvData[j][1])
            {
                case "1":
                    instantiatePlace = 15;
                    break;
                case "2":
                    instantiatePlace = 10;
                    break;
                case "3":
                    instantiatePlace = 5;
                    break;
                case "4":
                    instantiatePlace = 0;
                    break;
                case "5":
                    instantiatePlace = -5;
                    break;
                case "6":
                    instantiatePlace = -10;
                    break;
                default:

                    break;
            }


            GameObject notes = Instantiate(baseobjnotes, new Vector3(80, 2, instantiatePlace), Quaternion.identity);
            // basePos = notes.transform.position;
           
            // if(basePos.x < 15)
            // {
            //     switch(instantiatePlace)
            //     {
            //         case -15:
            //            Debug.Log("6-3");
            //            break;
            //         case -10:
            //            Debug.Log("5-3");
            //            break;
            //         case -5:
            //            Debug.Log("4-3");
            //            break;
            //         default:
            //             Debug.Log("error");
            //             break;
            //     }
            // }

            switch (_csvData[j][0])
            {
                case "0":
                    notes.GetComponent<Renderer>().material.color = Color.white;
                    break;
                case "1":
                    notes.GetComponent<Renderer>().material.color = new Color32(248, 168, 133, 1);
                    Debug.Log("generatered");
                    break;
                case "2":
                    notes.GetComponent<Renderer>().material.color = Color.magenta;
                    break;
                case "3":
                    notes.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case "4":
                    notes.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case "5":
                    notes.GetComponent<Renderer>().material.color = Color.cyan;
                    break;
                case "6":
                    notes.GetComponent<Renderer>().material.color = Color.gray;
                    break;
                default:
                    Debug.Log("error");
                    break;
            }
            if (_csvData[j][3] == "0")
            {
                lagFrame = 0;
            }
            if (_csvData[j][3] == "5")
            {
                lagFrame = 131;
            }
            if (_csvData[j][3] == "6")
            {
                lagFrame = 268;
            }
            if (_csvData[j][3] == "7")
            {
                lagFrame = 133;
            }
            if (_csvData[j][3] == "8")
            {
                lagFrame = 140;
            }
            if (_csvData[j][3] == "9")
            {
                lagFrame = 129;
            }

            for (int k = 0; k < lagFrame; k++)
            {
                yield return null;
            }
            
        }
    }
}