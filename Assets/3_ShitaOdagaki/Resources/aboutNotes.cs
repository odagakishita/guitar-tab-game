
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class aboutNotes : MonoBehaviour
{
    //public Material Mat;
    private TextAsset _csvFile;
    private List<string[]> _csvData = new List<string[]>();
    [SerializeField]
    GameObject objnotes;
    
    int instantiatePlace = 0;
    int lagFrame = 0;
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
        Debug.Log(objnotes);
        StartCoroutine(Fumen());
        

    }
    //void SetMatColor(Color col)
    //{
    //    Mat.color = col; //Materialの色を変える
    //}
    
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
                lagFrame = 60;
            }
            if (_csvData[i][3] == "3")
            {
                lagFrame = 120;
            }
            if (_csvData[i][3] == "4")
            {
                lagFrame = 60;
            }
            if (_csvData[i][3] == "5")
            {
                lagFrame = 11;
            }
            GameObject notes = Instantiate(objnotes, new Vector3(70, 2, instantiatePlace), Quaternion.identity);
            //notes.GetComponentInChildren<TextMeshPro>().text = _csvData[i][0];
            //GameObject basenotes = Instantiate(baseobjnotes, new Vector3(50, 2, instantiatePlace - ), Quaternion.identity);
            //var c = notes.GetComponent<Renderer>().material.color;
            
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
