using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ItemPick : MonoBehaviour
{
    Camera camera;
    public List<GameObject> pickUpItem = new List<GameObject>();
    public List<string> itemStr = new List<string>();
    public List<TextMeshProUGUI> itemTxt = new List<TextMeshProUGUI>();
    public Animator itemPickAnimator;
    public Sprite trueAssets, falseAssets;
    public GameObject garajeDoor;
   
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
                itemPickAnimator.SetBool("itemPickUp", true);
                StartCoroutine(objectfalse());

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100) && pickUpItem.Contains(hit.transform.gameObject))
                {



                    for (int i = 0; i < itemStr.Count; i++)
                    {
                        if (itemTxt[i].text.Contains(hit.transform.gameObject.name))
                        {
                            itemTxt[i].GetComponent<TextMeshProUGUI>().color = Color.green;
                            itemTxt[i].GetComponent<ID>().correctItem.sprite = trueAssets;
                            itemTxt[i].GetComponent<ID>().correctItem.color = Color.green;
                        }
                    }
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.tag == "ButtonGaraje")
                {
                    Debug.Log("++");
                    garajeDoor.GetComponent<Transform>().DOMove(new Vector3(garajeDoor.transform.position.x, 4.7f, garajeDoor.transform.position.z), .5f);
                }


            }
        
       
        
    }

    IEnumerator objectfalse()
    {
        yield return new WaitForSeconds(1.5f);
        itemPickAnimator.SetBool("itemPickUp", false);
    }

}