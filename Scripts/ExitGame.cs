using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void quitGame()

    {
      
            UnityEditor.EditorApplication.isPlaying = false;
        
            Application.Quit();
    }
}
