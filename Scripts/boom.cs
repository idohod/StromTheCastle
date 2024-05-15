using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public GameObject wall;
    public GameObject[] wallParts;
    public int numOfShooting = 0;
    public float frames = 0;
    public float Maxframes = 10;



    // Start is called before the first frame update
    void Start()
    {
        frames++;

    }

    // Update is called once per frame
    void Update()
    {
        if (frames < Maxframes)
            frames++;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(wall.gameObject == other.gameObject)
        {
            StartCoroutine(destroyWall());
        }
       
    }


    public IEnumerator destroyWall()
    {
       for(int i = 0; i < wallParts.Length; i++)
        {
            if (wallParts[i].activeSelf && i < numOfShooting)
            {
                wallParts[i].SetActive(false);
            }
        }
        if (frames == Maxframes)
        {
            numOfShooting++;
            frames = 0;
        }
        yield return null;
    }
}
