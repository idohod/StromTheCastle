using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public ProgressBar bar;
    public KnightMotion enemy;
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

        if (enemy.hits == curHits)
        {
            maxHP -= (float)(100 / 3);
            curHits++;
        }
       
    }
}
