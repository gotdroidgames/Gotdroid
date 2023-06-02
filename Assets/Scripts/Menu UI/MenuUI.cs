using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject[] menuUIButtons = new GameObject[3];

    void MEnuUIButtons(GameObject optionButton, GameObject playButton, GameObject quitButton, GameObject backGround,GameObject backButton)

    {
        menuUIButtons[0] = optionButton;
        menuUIButtons[1] = playButton;
        menuUIButtons[2] = quitButton;
        menuUIButtons[3] = backGround;
        menuUIButtons[4] = backButton;
    }

    public void Options()
    {
        menuUIButtons[3].SetActive(true);
        menuUIButtons[4].SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {

    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
