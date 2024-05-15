using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public ProgressBar bar;
    public Player_Motion player;
    public int HP = 100;
    public int curHits = 1;
    public RememberTheMode current;



    // Start is called before the first frame update
    void Start()
    {
        //bar.BarValue = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.isActiveAndEnabled)
            bar.BarValue = HP;
        
        if (player.hits == curHits)
        {
            if (current.updateMode == true)
            {
                HP -= 10;
            }
            else
            {
                HP -= 5;
            }               
           
            curHits++;

        }
        if (HP > 100)
        {
            HP = 100;
        }
        if (curHits < 1)
        {
            curHits = 1;
        }

    }
    //public void changeMode()
    //{
    //    if(Hard == true)
    //        Hard = false;
                   
    //    else
    //        Hard = true;
            
        
    //}
}
