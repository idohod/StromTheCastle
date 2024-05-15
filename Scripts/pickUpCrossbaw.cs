using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pickUpCrossbaw : MonoBehaviour
{
    public GameObject crossbawOnTable;
    public GameObject crossbawOnHand;
    public GameObject daggerOnHand;
    public GameObject daggerOnTable;
    public GameObject PlayerEye;
    public GameObject table;
    public Text text;
    public float dist;
    readonly float minDist = 10;

    // Start is called before the first frame update
    void Start()
    {
        crossbawOnTable.SetActive(true);
        crossbawOnHand.SetActive(false);
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(crossbawOnTable.transform.position, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(PlayerEye.transform.position, PlayerEye.transform.forward, out hit))
        {

            if (dist <= minDist)
            {

                if (hit.collider.gameObject == crossbawOnTable.gameObject &&
                 hit.collider.gameObject != daggerOnTable.gameObject &&
                 hit.collider.gameObject != table.gameObject)

                {
                    if (crossbawOnTable.activeSelf == true)
                        text.text = "Press E to pickup the crossbaw";
                    else
                        text.text = "";
                }

                if (Input.GetKey(KeyCode.E))
                {
                    crossbawOnTable.SetActive(false);
                    crossbawOnHand.SetActive(true);
                    text.text = "";
                    if (daggerOnHand.activeSelf == true)
                    {
                        daggerOnHand.SetActive(false);
                        text.text = "";

                    }
                    if (daggerOnTable.activeSelf == false)
                    {
                        daggerOnTable.SetActive(true);
                    }
                }

            }
            else
                text.text = "";
        }

    }
}
