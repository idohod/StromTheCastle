using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class playerAttack : MonoBehaviour
{
    Animator animator;
    public KnightMotion[] enemy;
    public KingMotion king;
    public GameObject eye;
    AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();



    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", true);
            sound.PlayDelayed(0.1f);
            StartCoroutine(attack());
        }
        else
        {
            animator.SetBool("isAttacking", false);
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
                king.NPCcollider.enabled = false;
                StartCoroutine(king.getHit());
                if (!king.isDead)
                {
                    yield return new WaitForSeconds(0.5f);
                    king.NPCcollider.enabled = true;
                }
                else
                    yield return new WaitForSeconds(0);
            }

            //paladins
            for (int i = 0; i < enemy.Length; i++)
            {
                if (Physics.Raycast(eye.transform.position, eye.transform.forward, out hit))
                {
                    if (hit.collider.gameObject == enemy[i].gameObject)
                    {
                        enemy[i].NPCcollider.enabled = false;
                        StartCoroutine(enemy[i].getHit());
                        if (!enemy[i].isDead)
                        {
                            yield return new WaitForSeconds(0.1f);
                            enemy[i].NPCcollider.enabled = true;
                        }
                        else
                            yield return new WaitForSeconds(0);
                        break;

                    }

                    yield return null;
                }
            }
        }
    }

}
