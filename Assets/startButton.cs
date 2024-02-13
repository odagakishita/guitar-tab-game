using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class startButton : MonoBehaviour
{
    public void OnClickTostartButton()
    {
        SceneManager.LoadScene("3_Main");
    }
}
