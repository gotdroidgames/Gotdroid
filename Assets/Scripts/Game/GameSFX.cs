using UnityEngine;

public class GameSFX : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()   
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Ba�lang��ta sirenin �almad���ndan emin ol
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P)) // P tu�una bas�ld���nda
        //{
        //    if (audioSource.isPlaying)
        //    {
        //        audioSource.Stop(); // Siren zaten �al�yorsa durdur
        //    }
        //    else
        //    {
        //        audioSource.Play(); // Siren �alm�yorsa ba�lat
        //    }
        //}
    }
}
