using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorMotion : MonoBehaviour
{
    Animator animator;
    AudioSource sound;
   public KnightMotion[] paladins;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            animator.SetBool("OpenDoor", true);
            sound.PlayDelayed(0.3f);
        }
        for (int i = 0; i < paladins.Length; i++)
        {
            if (other.transform.tag == "goal" && !paladins[i].isDead)
            {
                animator.SetBool("OpenDoor", true);

            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            sound.PlayDelayed(0.3f);
            animator.SetBool("OpenDoor", false);
        }
        for (int i = 0; i < paladins.Length; i++)
        {
            if (other.transform.tag == "goal" && !paladins[i].isDead)
            {
                animator.SetBool("OpenDoor", false);

            }
        }

    }
}
