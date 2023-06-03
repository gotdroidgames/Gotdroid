using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] TextMeshProUGUI countDownText;
    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (SinematicCam.Instance.isPlay == true)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }
        
    }
}
