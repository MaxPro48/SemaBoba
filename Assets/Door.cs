using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public LayerMask NPCMask;
    [SerializeField]public GameObject DoorObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((Physics.OverlapSphere(transform.position, 2f, NPCMask).Length > 0)){
            DoorObject.SetActive(false);
        }
        else
        {
            DoorObject.SetActive(true);
        }
    }
}
