using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class TouchDelete : MonoBehaviour
{
    //[SerializeField]
    //SpriteRenderer sr;
    [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
    private ParticleSystem particle;
    public static Vector3 disappearPoint;
    private AudioSource audio2;
    [SerializeField]
    private AudioClip E11;
    [SerializeField]
    private AudioClip E12;
    [SerializeField]
    private AudioClip E13;
    [SerializeField]
    private AudioClip E14;
    [SerializeField]
    private AudioClip E15;
    [SerializeField]
    private AudioClip E21;
    [SerializeField]
    private AudioClip E22;
    [SerializeField]
    private AudioClip E23;
    [SerializeField]
    private AudioClip E24;
    [SerializeField]
    private AudioClip E25;
    [SerializeField]
    private AudioClip E31;
    [SerializeField]
    private AudioClip E32;
    [SerializeField]
    private AudioClip E33;
    [SerializeField]
    private AudioClip E34;
    [SerializeField]
    private AudioClip E35;
    
    private TextAsset _csvFile;
    private List<string[]> _csvData = new List<string[]>();
    [SerializeField]
    GameObject objnotes;
    GameObject clickedGameObject;
    int instantiatePlace = 0;
    int lagFrame = 0;
    float height = 2.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        _csvFile = Resources.Load("tab") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }
       
        StartCoroutine(Fumen());
        audio2 = gameObject.AddComponent<AudioSource>();

    }


    // Start is called before the first frame update
    
    

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            
            
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayOrigin, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.CompareTag("notes"))
                {
                    disappearPoint = hitInfo.collider.gameObject.transform.position;

                    //SpriteRenderer hamon = Instantiate(sr, new Vector3(disappearPoint.x, 2, disappearPoint.z), Quaternion.identity);

                    //Debug.Log(mousePosition);
                    // パーティクルシステムのインスタンスを生成する。
                    ParticleSystem newParticle = Instantiate(particle);
                    // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
                    newParticle.transform.position = disappearPoint;
                    // パーティクルを発生させる。
                    newParticle.Play();
                    ParticleSystem.MainModule par = newParticle.GetComponent<ParticleSystem>().main;
                    
                    
                    // インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
                    // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
                    Destroy(newParticle.gameObject, 5.0f);
                    


                    if (disappearPoint.x > -10 && disappearPoint.x < 0)
                    {
                        par.startColor = Color.red;
                        if (disappearPoint.z == 15)
                        {
                            audio2.PlayOneShot(E11);
                            Debug.Log("1-1");
                        }
                        else if (disappearPoint.z == 10)
                        {
                            audio2.PlayOneShot(E21);
                            Debug.Log("2-1");
                        }
                        else if (disappearPoint.z == 5)
                        {
                            audio2.PlayOneShot(E31);
                            Debug.Log("3-1");
                        }
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E41);
                        //    Debug.Log("4-1");
                        //}
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E51);
                        //    Debug.Log("5-1");
                        //}
                    }
                    else if (disappearPoint.x > 0 && disappearPoint.x < 10)
                    {

                        par.startColor = Color.magenta;
                        if (disappearPoint.z == 15)
                        {
                            audio2.PlayOneShot(E12);
                            Debug.Log("1-2");
                        }
                        else if (disappearPoint.z == 10)
                        {
                            audio2.PlayOneShot(E22);
                            Debug.Log("2-2");
                        }
                        else if (disappearPoint.z == 5)
                        {
                            audio2.PlayOneShot(E32);
                            Debug.Log("3-2");
                        }
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E42);
                        //    Debug.Log("4-2");
                        //}
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E52);
                        //    Debug.Log("5-2");
                        //}
                    }
                    else if (disappearPoint.x > 10 && disappearPoint.x < 20)
                    {
                        par.startColor = Color.yellow;
                        if (disappearPoint.z == 15)
                        {
                            audio2.PlayOneShot(E13);
                            Debug.Log("1-3");
                        }
                        else if (disappearPoint.z == 10)
                        {
                            audio2.PlayOneShot(E23);
                            Debug.Log("2-3");
                        }
                        else if (disappearPoint.z == 5)
                        {
                            audio2.PlayOneShot(E33);
                            Debug.Log("3-3");
                        }
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E43);
                        //    Debug.Log("4-3");
                        //}
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E53);
                        //    Debug.Log("5-3");
                        //}
                    }
                    else if (disappearPoint.x > 20 && disappearPoint.x < 30)
                    {
                        par.startColor = Color.green;
                        if (disappearPoint.z == 15)
                        {
                            audio2.PlayOneShot(E14);
                            Debug.Log("1-4");
                        }
                        else if (disappearPoint.z == 10)
                        {
                            audio2.PlayOneShot(E24);
                            Debug.Log("2-4");
                        }
                        else if (disappearPoint.z == 5)
                        {
                            audio2.PlayOneShot(E34);
                            Debug.Log("3-4");
                        }
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E44);
                        //    Debug.Log("4-4");
                        //}
                        //else if (disappearPoint.z == -5)
                        //{
                        //    audio.PlayOneShot(E54);
                        //    Debug.Log("5-4");
                        //}
                    }
                    else if (disappearPoint.x > 30 && disappearPoint.x < 40 )
                    {
                        par.startColor = Color.cyan;
                        if (disappearPoint.z == 15)
                        {
                            audio2.PlayOneShot(E15);
                            Debug.Log("1-5");
                        }
                        else if (disappearPoint.z == 10)
                        {
                            audio2.PlayOneShot(E25);
                            Debug.Log("2-5");
                        }
                        else if (disappearPoint.z == 5)
                        {
                            audio2.PlayOneShot(E35);
                            Debug.Log("3-5");
                        }
                        //else if (disappearPoint.z == 0)
                        //{
                        //    audio.PlayOneShot(E45);
                        //    Debug.Log("4-5");
                        //}
                        //else if (disappearPoint.z == -5)
                        //{
                        //    audio.PlayOneShot(E55);
                        //    Debug.Log("5-5");
                        //}
                    }

                    Destroy(hitInfo.collider.gameObject);
                     //if(mousePosition.x > 80 && mousePosition.x < 210 &&)
                      //
                        
                }

            }


        }
    }
    private IEnumerator Fumen()
    {
        
        
        for (int i = 0; i < 14; i++)
        {
            
            
            //instantiatePlace
            //int lagTime = 1;

            

            if (_csvData[i][1] == "1")
            {
                instantiatePlace = 15;
            }
            if (_csvData[i][1] == "2")
            {
                instantiatePlace = 10;
            }
            if (_csvData[i][1] == "3")
            {
                instantiatePlace = 5;
            }
            if (_csvData[i][1] == "4")
            {
                instantiatePlace = 0;
            }

            //lagFlame
            // if (_csvData[i][3] == "0")
            // {
            //     lagFrame = 5;
            // }
            // if (_csvData[i][3] == "1")
            // {
            //     lagFrame = 8;
            // }
            // if (_csvData[i][3] == "2")
            // {
            //     lagFrame = 25;
            // }
            // if (_csvData[i][3] == "3")
            // {
            //     lagFrame = 30;
            // }
            // if (_csvData[i][3] == "4")
            // {
            //     lagFrame = 12;
            // }
            // if (_csvData[i][3] == "5")
            // {
            //     lagFrame = 11;
            // }
            if (_csvData[i][3] == "0")
            {
                lagFrame = 5;
            }
            if (_csvData[i][3] == "1")
            {
                lagFrame = 0;
            }
            if (_csvData[i][3] == "2")
            {
                lagFrame = 66;
            }
            if (_csvData[i][3] == "3")
            {
                lagFrame = 134;
            }
            if (_csvData[i][3] == "4")
            {
                lagFrame = 50;
            }
            if (_csvData[i][3] == "5")
            {
                lagFrame = 150;
            }

            switch(_csvData[i][2])
            {
                case "0":
                    height = 2.13f;
                    break;
                case "1":
                    height = 2.12f;
                    break;    
                case "2":
                    height = 2.11f;
                    break;
                case "3":
                    height = 2.1f;
                    break;   
                case "4":
                    height = 2.09f;
                    break;
                case "5":
                    height = 2.08f;
                    break;   
                case "6":
                    height = 2.07f;
                    break;
                case "7":
                    height = 2.06f;
                    break;   
                case "8":
                    height = 2.05f;
                    break;
                case "9":
                    height = 2.04f;
                    break;   
                case "10":
                    height = 2.03f;
                    break;
                case "11":
                    height = 2.02f;
                    break; 
                case "12":
                    height = 2.01f;
                    break; 
                case "13":
                    height = 2.0f;
                    break; 
                default:
                    Debug.Log("error");
                    break;
            }
            GameObject notes = Instantiate(objnotes, new Vector3(60, height, instantiatePlace), Quaternion.identity);
            notes.GetComponentInChildren<TextMeshPro>().text = "Tap!";
             switch(_csvData[i][0])
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

            for (int h = 0; h < lagFrame; h++)
            {
                yield return null;
            }
            //yield return new WaitForSeconds(lagTime);
        }
    }
}
