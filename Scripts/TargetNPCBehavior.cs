using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetNPCBehavior : MonoBehaviour 
{
    // Start is called before the first frame update
    public KnightMotion npc;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == npc.gameObject)
        {
            float x, y, z;
            x = Random.Range(-50, 50);
            z = Random.Range(-20, 150);

            y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0.2f, z));

            transform.position = new Vector3(x, y, z);

            StartCoroutine(npc.goIdle());
        }
    }

 
}
