using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDoor : MonoBehaviour
{
    Animator animator;
    public KnightMotion guard;
    AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (guard.isDead)
        {
            animator.SetBool("OpenTheDoor", true);
            doorSound.PlayDelayed(0.1f);
        }
        else
            animator.SetBool("OpenTheDoor", false);
    }
}
