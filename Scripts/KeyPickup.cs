using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyPickup : MonoBehaviour
{
    public GameObject key;
    public GameObject keyBox;
    public GameObject crossbaw;
    public GameObject dagger;
    public Text text;
    bool chestIsOpen = false;
    Animator animator;
    public GameObject PlayerEye;
    AudioSource sound;
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
        RaycastHit hit;
        if (Physics.Raycast(PlayerEye.transform.position, PlayerEye.transform.forward, out hit))
        {
            if (hit.collider.gameObject == keyBox.gameObject ||
                hit.collider.gameObject == dagger.gameObject ||
                hit.collider.gameObject == crossbaw.gameObject)
            {
                if (chestIsOpen)
                {
                    if (key.activeSelf == true)
                    {
                        text.text = "press E to take the key";
                    }
                    else
                        text.text = "";

                    if (Input.GetKey(KeyCode.E))
                    {
                        sound.PlayDelayed(0.1f);
                        key.SetActive(false);

                    }
                }
            }
            else
                text.text = "";


        }
    }
    public IEnumerator changeBool()
    {
        chestIsOpen = true;
        yield return new WaitForSeconds(0);
    }
}
