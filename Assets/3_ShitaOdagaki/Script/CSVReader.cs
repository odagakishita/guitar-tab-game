using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    private TextAsset _csvFile;
    private List<string[]> _csvData = new List<string[]>();

    void Start()
    {
        _csvFile = Resources.Load("note2") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

        for (int i = 0; i < _csvData.Count; i++)
        {
            //Debug.Log( _csvData[i][0] + "秒, "　+  _csvData[i][1] + "弦, " + _csvData[i][2]  + "フレット, ");
        }
    }
}
