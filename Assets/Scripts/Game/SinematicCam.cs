using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinematicCam : MonoBehaviour
{
    



    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.position == new Vector3(3.68f, 2.9f, -12.9f))
        {
            gameObject.SetActive(false);
        }
    }
}
