using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Door_Slide_Motion : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onTriggerEnter(Collider other)
    {
        animator.SetBool("DoorIsOpening", true);
    }

    private void onTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpening", false);
    }
}
