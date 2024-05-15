using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SetDifficulty : MonoBehaviour
{
    public bool hardmode = false;
    public GameObject[] enemies;
    public Player_Motion player;
    public TextMeshProUGUI text;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hardmode == true)
            setToHard();
        else
            setToEasy();
    }

    public bool GetHardmode()
    {
        return hardmode;
    }

    void setToHard()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
            player.MaxHits = 10;
        }
    }

    void setToEasy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
            player.MaxHits = 20;
        }

    }

    public void changeBool()
    {
        if (hardmode == true)
        {

            hardmode = false;
            text.text = "Easy";
        }
        else
        {
            hardmode = true;
            text.text = "Hard";
        }

    }
}
