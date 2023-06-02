using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPick : MonoBehaviour
{
    Camera camera;
    public List<GameObject> pickUpItem = new List<GameObject>();
    public List<string> itemStr = new List<string>();
    public List<TextMeshProUGUI> itemTxt = new List<TextMeshProUGUI>();
    public Animator itemPickAnimator;
    private void Start()
    {
        camera = Camera.main;
        itemPickAnimator = gameObject.GetComponent<Animator>();
        for (int i = 0; i < pickUpItem.Count; i++)
        {
            itemStr.Add(pickUpItem[i].name);
            itemTxt[i].text = itemStr[i];
        }
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

            if (Physics.Raycast(ray, out hit, 100) && pickUpItem.Contains(hit.transform.gameObject))
            {
                //itemPickAnimator.SetBool("itemPickUp", true);                
                StartCoroutine(objectfalse());
                for (int i = 0; i < itemStr.Count; i++)
                {
                    if (itemTxt[i].text.Contains(hit.transform.gameObject.name))
                    {
                        itemTxt[i].GetComponent<TextMeshProUGUI>().color = Color.green;
                    }
                }
                Destroy(hit.transform.gameObject);
            }

        }


    }

    IEnumerator objectfalse()
    {
        yield return new WaitForSeconds(1.5f);
        // itemPickAnimator.SetBool("itemPickUp", false);
    }

}
