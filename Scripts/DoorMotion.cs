using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorIsOpening", true);
        audioSource.PlayDelayed(0.3f);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpening", false);
       audioSource.PlayDelayed(0.3f);

    }
}
