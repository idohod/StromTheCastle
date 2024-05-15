using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMotion : MonoBehaviour
{
    public GameObject crossHair;
    public GameObject crossHairFocus;
    private Animator animator;
    public GameObject PlayerEye;
    public Text text;
    public KeyPickup key;
    // AudioSource AudioSource;
    //public GameObject keyBox;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
      //  AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the player focus is on drawer then change the crosshair
        RaycastHit hit;
        if (Physics.Raycast(PlayerEye.transform.position, PlayerEye.transform.forward, out hit))
        {
            if (hit.collider.gameObject == this.gameObject )
            {
                crossHair.SetActive(false);
                crossHairFocus.SetActive(true);
                // if the focus is on drawer  then if it is close show text "press O to open"
                // otherwise show text "press C to open"
                if (!animator.GetBool("OpenChest"))
                    text.text = "press SPACE to open";
                else
                    text.text = "";


                if (Input.GetKey(KeyCode.Space) && !animator.GetBool("OpenChest"))
                {
                    animator.SetBool("OpenChest", true);
                    StartCoroutine(key.changeBool());
                    //AudioSource.PlayDelayed(0.3f);
                    text.text = "";
                }
                
               
            }
            else
            {
                crossHair.SetActive(true);
                crossHairFocus.SetActive(false);
                // the focus is not on drawer
                text.text = "";
            }
        }
    }

    
}


