using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class ItemPick : MonoBehaviour
{
    Camera camera;
    public Camera cameraCar;
    public List<GameObject> pickUpItem = new List<GameObject>();
    public List<string> itemStr = new List<string>();
    public List<TextMeshProUGUI> itemTxt = new List<TextMeshProUGUI>();
    public Animator itemPickAnimator;
    public Sprite trueAssets, falseAssets;
    public GameObject garajeDoor;
    public GameObject rotationObject;
    public GameObject rotationTwo;
    public List<GameObject> doorObject = new List<GameObject>();
    public bool isCar;
    public static ItemPick Instance;
    public GameObject playerCamera, carCamera;
    public GameObject player;
    public int inventoryItem;
    public TextMeshProUGUI infoText;
    public AudioSource itemTakeSound, doorSound, carSound;
    public GameObject itemListGo;
    public TextMeshProUGUI item;
    public GameObject deadPanel,winPanel;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }


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

    public void AgainGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        if (SinematicCam.Instance.isPlay == true)
        {
           
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 100f;
            mousePos = camera.ScreenToWorldPoint(mousePos);
            if (Input.GetKeyDown("f"))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 4) && pickUpItem.Contains(hit.transform.gameObject))
                {
                    itemPickAnimator.SetBool("itemPickUp", true);
                    StartCoroutine(objectfalse());
                    itemTakeSound.Play();
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
                    inventoryItem++;
                }

                else if (hit.transform.gameObject.tag == "door")
                {
                    doorSound.Play();
                    if (!doorObject.Contains(hit.collider.gameObject))
                    {
                        hit.collider.gameObject.GetComponent<Transform>().rotation = rotationObject.GetComponent<Transform>().rotation;
                        doorObject.Add(hit.collider.gameObject);
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<Transform>().rotation = rotationTwo.GetComponent<Transform>().rotation;
                        doorObject.Remove(hit.collider.gameObject);
                    }
                }
                else if (hit.transform.gameObject.tag == "garajeDoor")
                {
                    if (inventoryItem == 6)
                    {
                        infoText.text = "Garaj Butonuna Bas!";
                        StartCoroutine(backInfo());
                        itemListGo.SetActive(false);
                        doorSound.Play();
                        if (!doorObject.Contains(hit.collider.gameObject))
                        {
                            hit.collider.gameObject.GetComponent<Transform>().rotation = rotationObject.GetComponent<Transform>().rotation;
                            doorObject.Add(hit.collider.gameObject);
                        }
                        else
                        {
                            hit.collider.gameObject.GetComponent<Transform>().rotation = rotationTwo.GetComponent<Transform>().rotation;
                            doorObject.Remove(hit.collider.gameObject);
                        }
                    }
                    else
                    {
                        infoText.text = "Etrafta ki malzemeleri topla!";
                        StartCoroutine(backInfo());
                    }
                }
                else if (hit.transform.gameObject.tag == "carDoor")
                {
                    item.gameObject.SetActive(true);
                    carSound.loop = true;
                    carSound.Play();
                    isCar = true;
                    Debug.Log("arabaya bindi");
                    playerCamera.SetActive(false);
                    gameObject.SetActive(false);
                    carCamera.SetActive(true);
                }

                else if (hit.transform.gameObject.tag == "ButtonGaraje")
                {
                    Debug.Log("++");
                    garajeDoor.GetComponent<Transform>().DOMove(new Vector3(garajeDoor.transform.position.x, 7.3f, garajeDoor.transform.position.z), 2f);
                }
            }
        }


    }

    IEnumerator backInfo()
    {
        yield return new WaitForSeconds(3);
        infoText.text = "";
    }

    IEnumerator objectfalse()
    {
        yield return new WaitForSeconds(1.5f);
        itemPickAnimator.SetBool("itemPickUp", false);
    }

}