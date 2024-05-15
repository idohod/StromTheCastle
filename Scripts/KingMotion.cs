using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KingMotion : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public GameObject player;
    public int hits = 0;
    public float dist;
    readonly float minDist = 3;
    public float frames = 0;
    public float attackFrames = 0;
    public AudioSource attackSound;
    public AudioSource battlecry;
    public AudioClip cryclip;
    public Player_Motion playerMotion;
    public bool attackThePlayer = false, isDead = false, isAttacking = false, isIdle = true, warCry = true;
    public Collider NPCcollider;
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        NPCcollider = GetComponent<Collider>();
        healthbar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (frames < playerMotion.kingFrame)
            frames++;

        if (attackFrames < playerMotion.maxAttackFrame)
        {
            attackFrames++;
        }
        //agent.baseOffset = 8;

        if (this.gameObject.activeSelf == true)
        {

            if (agent.enabled && attackThePlayer)
            {
                agent.SetDestination(player.transform.position);
                dist = Vector3.Distance(player.transform.position, transform.position);
            }

            if (isAttacking)
                agent.isStopped = true;

            if (!isIdle && !isDead)
            {
                agent.isStopped = false;
                animator.SetBool("IsStanding", false);
            }


            if (isIdle || playerMotion.animator.enabled == true || warCry)
                agent.isStopped = true;




            if (dist <= minDist + 0.2f && attackThePlayer && !isDead)
            {
                StartCoroutine(attackInPlace());
                // StartCoroutine(npcAttackPlayer());
            }
            else if (isDead)
            {
                StartCoroutine(Dead());
                StartCoroutine(DelayHealthBar());
            }
            else if (!isIdle && warCry)
                StartCoroutine(initBattleCry());
            else
            {
                StartCoroutine(continueWalking());
                //agent.baseOffset = 0;
            }
            if (healthbar.activeSelf)
            {
                Vector3 barPotision = new Vector3(transform.position.x, 6, transform.position.z);
                Vector3 barRotation = new Vector3(0, 0, 0);

                healthbar.transform.position = barPotision;
                healthbar.transform.Rotate(barRotation);
            }
        }
    
    }

    public bool IsEnemyDead()
    {
        if (this.isDead)
            return true;
        return false;
    }

    public IEnumerator Dead()
    {
        animator.SetInteger("KingState", 4);
        agent.isStopped = true;
        yield return null;
    }

    public IEnumerator DelayHealthBar()
    {
        yield return new WaitForSeconds(2f);
        healthbar.SetActive(false);
    }

    public IEnumerator getHit()
    {
        if (attackFrames == playerMotion.maxAttackFrame)
        {
            hits++;
            attackFrames = 0;
        }

        if (hits == 6)
        {
            isDead = true;
            //yield return new WaitForSeconds(2f);
            //healthbar.SetActive(false);
        }

        yield return new WaitForSeconds(0);

    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(continueWalking());
    }

    public IEnumerator continueWalking()
    {
        isAttacking = false;
        //agent.baseOffset = 0;
        if (!agent.enabled)
            agent.enabled = true;
        if (!isDead)
            animator.SetInteger("KingState", 2);

        yield return null;
    }

    public IEnumerator attackInPlace()
    {
        isAttacking = true;
        animator.SetInteger("KingState", 3);
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(playerMotion.kingHitPlayer());
        //StartCoroutine(continueWalking());       
    }

    public IEnumerator initBattleCry()
    {
        animator.SetInteger("KingState", 1);
        animator.SetBool("IsStanding", false);
        if (!battlecry.isPlaying)
            battlecry.PlayOneShot(cryclip);
        //HP bar appears
        healthbar.SetActive(true);
        yield return new WaitForSeconds(2.26f);
        warCry = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if enemy steps into player radius, set to attack player
        if (other.transform.tag == "Player")

        {
            //king does battle cry 
            //if idle enemy, set to move
            isIdle = false;
            attackThePlayer = true;
            agent.stoppingDistance = 3;
            
        }
    }
}
