using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public ProgressBar bar;
    public KingMotion king;
    public float maxHP = 100;
    private int curHits = 1;


    void Start()
    {
        
       // bar.BarValue = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.isActiveAndEnabled)
            bar.BarValue = maxHP;

        if (king.hits == curHits)
        {
            maxHP -= (float)(100/6);
            curHits++;
        }
        
    }
}
