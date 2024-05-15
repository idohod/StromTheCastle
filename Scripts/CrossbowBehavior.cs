using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBehavior : MonoBehaviour
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
       if (enabled)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetBool("Fire", true);
               
            }
            else
                animator.SetBool("Fire", false);
        }
      
    }

   
}
