using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyToDoorBehavior : MonoBehaviour
{
    public Animator animator;
    public GameObject key;
    public Text text;
    AudioSource ASource;
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
        ASource = GetComponent<AudioSource>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!key.activeSelf)
            {
                animator.SetBool("DoorOpening", true);
                ASource.PlayDelayed(0.3f);
            }
            else
            {
                text.text = "You need a key to open this door.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "";
    }
}
