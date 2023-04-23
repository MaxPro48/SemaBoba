using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizationHandler : MonoBehaviour
{
    [SerializeField] public GameObject[] Enablers;
    [SerializeField] public GameObject[] Disablers;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerMove>())
        {
            foreach(GameObject enabler in Enablers)
            {
                enabler.SetActive(true);
            }
            foreach (GameObject disabler in Disablers)
            {
                disabler.SetActive(false);
            }
        }
    }
}
