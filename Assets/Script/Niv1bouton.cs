using UnityEngine;
using UnityEngine.InputSystem;

public class Niv1bouton : MonoBehaviour
{
    public AudioClip BChien;
    public AudioClip BChat;

    private AudioSource audioS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioS = GetComponent<AudioSource>();

    }

    public void PlayChien()
    {
        audioS.PlayOneShot(BChien);
    }

    public void PlayChat()
    {
        audioS.PlayOneShot(BChat);
    }
}
