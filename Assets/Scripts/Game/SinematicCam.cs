using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinematicCam : MonoBehaviour
{
    public Transform spawnFirst;
    public GameObject player;
    public bool isPlay = false;
    public static SinematicCam Instance;
    public GameObject canvas;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }
    void Update()
    {
        if (gameObject.transform.position == new Vector3(3.68f, 2.9f, -12.9f))
        {
            gameObject.SetActive(false);
            Debug.Log("+");

            player.transform.localPosition = new Vector3(2.7f, -0.6f, -15f);
            player.transform.localRotation = spawnFirst.transform.localRotation;
            isPlay = true;
            canvas.SetActive(true);
        }
    }
}
