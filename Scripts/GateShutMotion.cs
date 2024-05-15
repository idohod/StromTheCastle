using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateShutMotion : MonoBehaviour
{
    Animator animator;
    AudioSource shutsound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        shutsound = GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            while (animator.GetBool("GateShuts").Equals(false))
            {
                animator.SetBool("GateShuts", true);
                shutsound.Play();
            }
        }
    }
}
