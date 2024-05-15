using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class KnightMotion : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject player;
    public AudioSource attackSound;
    public Player_Motion playerMotion;
    public int hits = 0;
    public bool attackThePlayer = false, isDead = false, isAttacking = false, isIdle=true;
    public Collider NPCcollider;
    public float dist;
    readonly float minDist = 3;
    public float frames = 0;
    public GameObject healthbar;
    public float attackFarmes = 20;

    //public Collider enemy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        NPCcollider = GetComponent<Collider>();
        attackSound = GetComponent<AudioSource>();
        healthbar.SetActive(false);
        //playerCollider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()    {
        if(frames < playerMotion.iFrame)
             frames++;

        if (attackFarmes < playerMotion.maxAttackFrame)
        {
            attackFarmes++;
        }
        if (this.gameObject.activeSelf == true)
        {
            if (agent.enabled && !attackThePlayer)
            {
                agent.SetDestination(target.transform.position);
            }

            else if (agent.enabled && attackThePlayer)
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
                StartCoroutine(continueWalking());

            }

            if (isIdle || playerMotion.animator.enabled == true)
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

            else
                StartCoroutine(continueWalking());

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
        if(this.isDead)
            return true;
        return false;
    }      

    public IEnumerator Dead()
    {
        animator.SetInteger("KnightState", 3);
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
        if (attackFarmes == playerMotion.maxAttackFrame)
        {
            hits++;
            attackFarmes = 0;
        }
        if (hits == 3)
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

    public IEnumerator goIdle()
    {
        agent.isStopped = true;
        if (!animator.enabled)
        {
            animator.enabled = true;
        }
        animator.SetInteger("KnightState", 1);

        float seconds = UnityEngine.Random.Range(2, 5);
        yield return new WaitForSeconds(seconds);
        StartCoroutine(continueWalking());
    
    }

    public IEnumerator continueWalking()
    {
        isAttacking = false;
        if (!agent.enabled)
            agent.enabled = true;
        if (!isDead)
            animator.SetInteger("KnightState", 2);
     
        yield return null;
    }

    public IEnumerator attackInPlace()
    {
        isAttacking = true;
        animator.SetInteger("KnightState", 5);
        StartCoroutine(playerMotion.hitPlayer());
        yield return new WaitForSeconds(1.2f);
         //StartCoroutine(continueWalking());       
    }  
   

    private void OnTriggerEnter(Collider other)
    {
        //if enemy steps into player radius, set to attack player
        if (other.transform.tag == "Player")

        {
            //if idle enemies, set to move
            isIdle = false;
            attackThePlayer = true;
            agent.stoppingDistance = 3;
            //HP bar appears
            healthbar.SetActive(true);
            
            
        }
    }

}
  


