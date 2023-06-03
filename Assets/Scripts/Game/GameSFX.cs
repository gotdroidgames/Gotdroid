using UnityEngine;

public class GameSFX : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()   
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Baþlangýçta sirenin çalmadýðýndan emin ol
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P)) // P tuþuna basýldýðýnda
        //{
        //    if (audioSource.isPlaying)
        //    {
        //        audioSource.Stop(); // Siren zaten çalýyorsa durdur
        //    }
        //    else
        //    {
        //        audioSource.Play(); // Siren çalmýyorsa baþlat
        //    }
        //}
    }
}
