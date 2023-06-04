using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colll : MonoBehaviour
{
    public bool winBool;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "carDoor")
        {
            ItemPick.Instance.winPanel.SetActive(true);
            winBool = true;
        }
    }

    private void Update()
    {
        if (winBool == true)
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
