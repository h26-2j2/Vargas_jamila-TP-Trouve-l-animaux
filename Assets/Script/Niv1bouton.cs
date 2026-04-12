using UnityEngine;
using UnityEngine.InputSystem;

public class Niv1bouton : MonoBehaviour
{
    //sons
    public AudioClip BChien;
    public AudioClip BChat;

    private AudioSource audioS;

    void Start()
    {
        //Récupérer le composant AudioSource
        audioS = GetComponent<AudioSource>();

    }

    //function chien audio
    public void PlayChien()
    {
        audioS.PlayOneShot(BChien, 0.4f);
    }

    //function chat audio
    public void PlayChat()
    {
        audioS.PlayOneShot(BChat, 0.9f);
    }
}
