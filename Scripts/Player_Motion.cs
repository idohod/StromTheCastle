using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Motion : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    float speed;
    float angularSpeed = 100;
    public GameObject aCamera;
    public int hits = 0;
    public int MaxHits = 20;
    //public Text text;
    public SphereCollider playerCollider;
    public float iFrame = 50;
    public float kingFrame = 48;
    public float frames = 0;
    public float walkFrame = 14;
    public float maxAttackFrame = 10;

    public KnightMotion[] paladins;
    public KingMotion king;
    public AudioSource[] stepSounds;
    public GameObject deadPanel;
    public GameObject victoryPanel;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<SphereCollider>();
        animator.enabled = false;
        controller.enabled = true;
        deadPanel.SetActive(false);
        victoryPanel.SetActive(false);

        // text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float dz, dx;
        float rotationAboutY, rotationAboutX = 0;

        rotationAboutX += -1 * angularSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        rotationAboutY = angularSpeed * Time.deltaTime * Input.GetAxis("Mouse X");

        if (controller.enabled == true)
        {
            aCamera.transform.Rotate(rotationAboutX, 0, 0);
            transform.Rotate(0, rotationAboutY, 0);
        }
        else
        {
            aCamera.transform.Rotate(0, 0, 0);
            transform.Rotate(0, 0, 0);
        }
        
        


        //hold LShift to Sprint
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 25;
        else
            speed = 12.5f;


        dz = speed * Time.deltaTime * Input.GetAxis("Vertical");
        dx = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        //dy = speed * Time.deltaTime * Input.GetAxis("Jump");

        Vector3 motion = new Vector3(dx, -0.2f, dz);
        motion = this.transform.TransformDirection(motion);

        //play step sound on WASD movement
        if (frames < walkFrame)
            if (Input.GetKey(KeyCode.LeftShift))
                frames = frames + 1.5f;
            else
                frames++;

        if (frames >= walkFrame)
        {
            if ((controller.enabled == true) &&
           (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
           || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                StartCoroutine(playStepSound());
                frames = 0;
            }
        }




        if (controller.enabled == true)
            controller.Move(motion);

        if (hits < 0)
        {
            hits = 0;
        }

        if (checkIfPlayerDead() == true || (allPaladinsDeads() && king.isDead))
            controller.enabled = false;


        if (allPaladinsDeads() && king.isDead)
        {
            victoryPanel.SetActive(true);
        }
        else
            victoryPanel.SetActive(false);


    }

    public IEnumerator playStepSound()
    {
        //stepsounds
        int rememberInt = 4;

        for (int i = 0; i < stepSounds.Length; i++)
        {
            if (stepSounds[i].gameObject.activeSelf == true)
                stepSounds[i].gameObject.SetActive(false);
        }
        int random = calculateRandomInt(rememberInt);
        rememberInt = random;
        stepSounds[random].gameObject.SetActive(true);
        
            if (!stepSounds[0].isPlaying && !stepSounds[1].isPlaying 
            && !stepSounds[2].isPlaying && !stepSounds[3].isPlaying)
                stepSounds[random].Play();
 
        yield return null; 
        
    }

    int calculateRandomInt(int n)
    {
        int rand = (int)Random.Range(0, stepSounds.Length);
        while (rand == n)
            rand = (int)Random.Range(0, stepSounds.Length);

        return rand;
    }

    public IEnumerator kingHitPlayer()
    {

        if (king.frames == kingFrame && king.isAttacking == true
            && (king.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack State")))

        {
            hits++;
            king.frames = 0;
            king.attackSound.PlayDelayed(0.1f);
            //player get hit sound
        }

        if (checkIfPlayerDead() == true)
        {

            animator.enabled = true;
            animator.SetBool("AliveState", false);
            StartCoroutine(waitBeforPanel());
            deadPanel.SetActive(true); 
            //insert game over music?
        }
       yield return new WaitForSeconds(0);

    }


    public IEnumerator hitPlayer()
    {
        for(int i = 0; i < paladins.Length; i++)
        {
            if(paladins[i].frames == iFrame && paladins[i].isAttacking==true
                && (paladins[i].animator.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Attack")))

            {
                hits++;
                paladins[i].frames = 0;
                paladins[i].attackSound.PlayDelayed(0.1f);
            }
           
        }

        if (checkIfPlayerDead() == true)
        {

            animator.enabled = true;
            animator.SetBool("AliveState", false);
            StartCoroutine(waitBeforPanel());
            deadPanel.SetActive(true);
            //insert game over music?
        }
        yield return new WaitForSeconds(0);

    }
    private IEnumerator waitBeforPanel()
    {
        yield return new WaitForSeconds(3f);

    }

    public bool allPaladinsDeads()
    {
        for (int i = 0; i < paladins.Length; i++)
        {
            if (paladins[i].isActiveAndEnabled && !paladins[i].IsEnemyDead())
            {
                return false;
            }
                       
        }
       
        return true;

    }

    public bool checkIfPlayerDead()
    {
        if (hits == MaxHits)
        {
            return true;
        }
        return false;
    }
}
 