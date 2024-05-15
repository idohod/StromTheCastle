using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHealth : MonoBehaviour
{
    public PlayerHealthBar healthBar;
    public Player_Motion player;
    public GameObject heal;
    public AudioSource healup;
    // Start is called before the first frame update
    void Start()
    {
        heal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject && healthBar.HP < 100)
        {
            heal.SetActive(false);
            this.enabled = false;
            healthBar.HP += 50;
            player.hits -= 5;
            healthBar.curHits -= 5;
            healup.Play();

        }
    }
}
