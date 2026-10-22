using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    public void PlayClick()
    {
        if (audioSource != null &&  clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
