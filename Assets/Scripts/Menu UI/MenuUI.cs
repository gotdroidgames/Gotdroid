using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject[] menuUIButtons = new GameObject[3];

    void MEnuUIButtons(GameObject optionButton, GameObject playButton, GameObject quitButton, GameObject backGround, GameObject backButton, GameObject yesButton, GameObject noButton)

    {
        menuUIButtons[0] = optionButton;
        menuUIButtons[1] = playButton;
        menuUIButtons[2] = quitButton;
        menuUIButtons[3] = backGround;
        menuUIButtons[4] = backButton;
        menuUIButtons[5] = yesButton;
        menuUIButtons[6] = noButton;
    }

    private void Start()
    {
        menuUIButtons[4].SetActive(false);
    }

    public void Options()
    {
        menuUIButtons[0].SetActive(false);
        menuUIButtons[1].SetActive(false);
        menuUIButtons[2].SetActive(false);
        menuUIButtons[3].SetActive(true);
        menuUIButtons[4].SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {
        menuUIButtons[0].SetActive(true);
        menuUIButtons[1].SetActive(true);
        menuUIButtons[2].SetActive(true);
        menuUIButtons[4].SetActive(false);
    }

    public void QuitMenu()
    {
        menuUIButtons[3].SetActive(true);
        menuUIButtons[5].SetActive(true);
        menuUIButtons[6].SetActive(true);
    }

    public void QuitCancel()
    {
        menuUIButtons[3].SetActive(false);
        menuUIButtons[5].SetActive(false);
        menuUIButtons[6].SetActive(false);
    }

    public void QuitAccept()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
