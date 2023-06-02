using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    Camera camera;
    public List<GameObject> pickUpItem = new List<GameObject>();
    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        if (Input.GetKeyDown("f"))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,100) && pickUpItem.Contains(hit.transform.gameObject))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

}
