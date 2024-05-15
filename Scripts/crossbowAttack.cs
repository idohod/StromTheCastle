using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossbowAttack : MonoBehaviour
{
    public GameObject eye;
    //public GameObject target;
    public GameObject muzzle;
    public KnightMotion[] enemies;
    public KingMotion king;
    private LineRenderer line;
    AudioSource bowAttack;

    // private bool attackEnemy = true;


    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        bowAttack = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(attack());
            bowAttack.PlayDelayed(0.1f);
        }
    }
       
    IEnumerator attack()
    {
        RaycastHit hit;

        //king
        if (Physics.Raycast(eye.transform.position, eye.transform.forward, out hit))
        {
            if (hit.collider.gameObject == king.gameObject)
            {
                StartCoroutine(king.getHit());
            }
            //target.transform.position = hit.point;
            line.enabled = true;
            line.SetPosition(0, muzzle.transform.position);
            //line.SetPosition(1, target.transform.position);
            line.enabled = false;
            //sound.Play();                             
            yield return new WaitForSeconds(0);
        }

        //paladins
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Physics.Raycast(eye.transform.position, eye.transform.forward, out hit))
            {
                if (hit.collider.gameObject == enemies[i].gameObject)
                {
                    StartCoroutine(enemies[i].getHit());
                }
                //target.transform.position = hit.point;
                line.enabled = true;
                line.SetPosition(0, muzzle.transform.position);
                //line.SetPosition(1, target.transform.position);
                line.enabled = false;
                //sound.Play();                             
                yield return new WaitForSeconds(0);
            }
        }
    }
    

    

}