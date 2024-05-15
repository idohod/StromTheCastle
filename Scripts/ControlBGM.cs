using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBGM : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource inCombat;
    public AudioSource overworld;
    public AudioSource bossbattle;
    public KnightMotion[] enemy;
    public KingMotion king;
    //public int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyAttackingPlayer() == true && kingAttackingPlayer() == false)
        {
            incrementVolume(inCombat);
            decrementVolume(overworld);
            //potentially decrease volume of other sources
        }
        else
        {
            decrementVolume(inCombat);
            incrementVolume(overworld);
            //potentially increase volume of other sources
        }

        if (kingAttackingPlayer() == true)
        {
            if (!bossbattle.isPlaying)
                bossbattle.Play();
            incrementVolume(bossbattle);
            decrementVolume(overworld);
            //potentially decrease volume of other sources
        }
        else
        {
            decrementVolume(bossbattle);
            incrementVolume(overworld);
            //potentially increase volume of other sources
        }


    }

    private void incrementVolume(AudioSource audio)
    {
        if (audio.volume < 0.4)
            audio.volume = audio.volume + 0.005f;
    }

    private void decrementVolume(AudioSource audio)
    {
        if (audio.volume > 0)
            audio.volume = audio.volume - 0.01f;
    }

    //public void playCombatBGM()
    //{
    //    if (!inCombat.isPlaying)
    //    {
    //        //play and increase volume from 0
    //        inCombat.PlayDelayed(0.3f);
    //        incrementVolume(inCombat);
    //    }
    //    else
    //    {
    //        decrementVolume(inCombat);
    //    }
    //}

    public bool currentlyAttackingPlayer()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].isActiveAndEnabled && enemy[i].attackThePlayer == true && enemy[i].isDead == false)
            {
                return true;
            }
        }
        return false;

    }

    public bool kingAttackingPlayer()
    {
        if (king.attackThePlayer == true && king.isDead == false)
            return true;
        return false;
    }
}
