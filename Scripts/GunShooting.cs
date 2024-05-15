using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GunShooting : MonoBehaviour
{
    public GameObject eye;
    //public GameObject target;
    public GameObject muzzle;
    public KnightMotion enemy;
    public GameObject arrow;
    //public AudioSource sound;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
       // sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(shooting());
        }
    }

    IEnumerator shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(eye.transform.position, eye.transform.forward, out hit))
        {
            if (hit.collider.gameObject == enemy.gameObject )
            {
                StartCoroutine(enemy.getHit());
            }
            //target.transform.position = hit.point;
            line.enabled = true;
         //  line.SetPosition(0, muzzle.transform.position);
            //line.SetPosition(1, target.transform.position);
          //sound.Play();
            yield return new WaitForSeconds(0.5f);
            line.enabled = false;
        }

    }
    


}