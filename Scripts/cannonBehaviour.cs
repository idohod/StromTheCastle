using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cannonBehaviour : MonoBehaviour
{
    Animator animator;
    public GameObject PlayerEye;
    public GameObject cannon;
    public Text text;
    public float dist;
    public KnightMotion guard;
    AudioSource sound;
    public boom boom;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

        text.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(PlayerEye.transform.position, transform.position);
        RaycastHit hit;
        float minDist = 18;
        if (Physics.Raycast(PlayerEye.transform.position, PlayerEye.transform.forward, out hit))
        {

            if (dist <= minDist && guard.isDead)
            {
                if (hit.collider.gameObject == cannon.gameObject)
                {
                    text.text = "Press E to shoot";
                    if (Input.GetKey(KeyCode.E))
                    {
                        animator.SetBool("attack", true);
                        sound.PlayDelayed(0.1f);
                        StartCoroutine(boom.destroyWall());
                        
                    }
                   else
                        animator.SetBool("attack", false);
                }
            }
            else
            {
                text.text = "";
            }
        }
       
    }
}
    
