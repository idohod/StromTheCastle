using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickDagger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject daggerOnTable;
    public GameObject daggerOnHand;
    public GameObject crossbawOnHand;
    public GameObject crossbawOnTable;
    public GameObject PlayerEye;
    public GameObject table;
    public Text text;
    public float dist;
    readonly float minDist = 10;

    void Start()
    {
        daggerOnTable.SetActive(true);
        daggerOnHand.SetActive(false);
        text.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(daggerOnTable.transform.position, transform.position);
        RaycastHit hit;
        
        if (Physics.Raycast(PlayerEye.transform.position, PlayerEye.transform.forward, out hit))
        {
            if (dist <= minDist)
            {
                if (hit.collider.gameObject == daggerOnTable.gameObject &&
                hit.collider.gameObject != crossbawOnTable.gameObject &&
                hit.collider.gameObject != table.gameObject)

                {

                    if (daggerOnTable.activeSelf == true)
                        text.text = "Press E to pick up the dagger";
                    else
                        text.text = "";
                    if (Input.GetKey(KeyCode.E))
                    {
                        daggerOnTable.SetActive(false);
                        daggerOnHand.SetActive(true);
                        crossbawOnTable.SetActive(true);
                        crossbawOnHand.SetActive(false);
                        text.text = "";
                        if (crossbawOnHand.activeSelf == true)
                        {
                            crossbawOnHand.SetActive(false);
                        }
                        if (crossbawOnTable.activeSelf == false)
                        {
                            crossbawOnTable.SetActive(true);
                        }
                    }
                }
            }
            else
                text.text = "";
        }
    }

}
