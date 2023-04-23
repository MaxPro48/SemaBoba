using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement1 : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] public Transform CameraPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraPos.position;
    }
}
