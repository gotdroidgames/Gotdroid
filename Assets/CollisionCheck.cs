using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCheck : MonoBehaviour
{
    public bool kaza;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "carDoor")
        {
            Debug.Log("kaza");
            kaza = true;
            ItemPick.Instance.cameraCar.fieldOfView = 0;
            ItemPick.Instance.deadPanel.SetActive(true);         
        }
       
    }

    private void Update()
    {
        if (kaza == true)
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(1);
            }
        }
        
    }
}
