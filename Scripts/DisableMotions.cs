using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DisableMotions : MonoBehaviour
{
    // Start is called before the first frame update
    //if still in menu, this script is active to pause enemy and player motions
    public KnightMotion[] enemies;
    public Player_Motion player;
    public GameObject gamePanel;
    public GameObject startPanel;
    public GameObject menuCamera;
    public Animation fadein;
    public Animation fadeout;

    void Start()
    {
        disableMotion();
        //fadein = GetComponent<Animation>();
        //fadeout = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gamePanel.activeSelf == true)
        {
            player.gameObject.SetActive(true);
            player.enabled = true;
            //switch cameras
            StartCoroutine(switchCameras());
            startMotion();
        }
                    
    }
    //start motion on play
    void startMotion()
    {
        for (int i = 0; i < enemies.Length; i++)
            enemies[i].agent.enabled = true; 
  
    }
    //disable motion when not play
    void disableMotion()
    {
        for (int i = 0; i < enemies.Length; i++)
            enemies[i].agent.enabled = false;
        player.animator.enabled = true;
        player.controller.enabled = false;
        player.aCamera.SetActive(false);
        menuCamera.SetActive(true);

    }

    public IEnumerator switchCameras()
    {
        StartCoroutine(playFadeout());
        player.aCamera.SetActive(true);
        menuCamera.SetActive(false);
        StartCoroutine(playFadein());
        yield return null;
    }

    public IEnumerator playFadein()
    {
        fadein.Play();
        yield return new WaitForSeconds(2.29f);
        fadein.Stop();
        if (!fadein.isPlaying)
            fadein.enabled = false;
    }

    public IEnumerator playFadeout()
    {
        fadeout.Play();
        yield return new WaitForSeconds(2.29f);
        fadeout.Stop();
        if (!fadeout.isPlaying)
            fadeout.enabled = false;
    }

}
