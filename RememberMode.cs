using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberMode : MonoBehaviour
{
    // Start is called before the first frame update
    public SetDifficulty mode;
    public bool updateMode;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode.hardmode == true)
            updateMode = true;
        else
            updateMode = false;
    }
}
