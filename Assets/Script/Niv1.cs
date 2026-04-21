using UnityEngine;
using UnityEngine.InputSystem;

public class Niv1 : MonoBehaviour
{
    //variables public
    public bool estChien;
    public string reponse;

    public static bool changementScene;

    //sprites
    //private SpriteRenderer spriteR;

    //animation
    public GameObject Victoire;
    public Animator VictoireA;
    //Animator animS;

    //sons
    public AudioClip bravoS;
    public AudioClip erreurS;

    public AudioClip Mbravo;

    AudioSource audioS;

    void Start()
    {
        //récupérer le composant AudioSource
        audioS = GetComponent<AudioSource>();

        //spriteR = GetComponent<SpriteRenderer>();
        //animS = GetComponent<Animator>();
    }

   
    //interaction pour trouver la bonne réponse
    public void Bonnereponse()
        {
        if (estChien && reponse == "chien")
        {
            //audio
            audioS.PlayOneShot(bravoS, 5f);
            audioS.PlayOneShot(Mbravo, 0.2f);
            //animation victoire
            Victoire.SetActive(true);
            VictoireA.Play("Victoire", 0, 1f);

            changementScene = true;
        }
        else if (!estChien && reponse == "chat")
        {
            //audio
            audioS.PlayOneShot(bravoS, 5f);
            audioS.PlayOneShot(Mbravo, 0.2f);
            //animation victoire
            Victoire.SetActive(true);
            VictoireA.Play("Victoire", 0, 0f);

            changementScene = true;
        }
        else
        {
            changementScene = false;
            //si pas bonne reponse
            audioS.PlayOneShot(erreurS, 5f);
        }
    }

    //animation future

    //public void Animation()
    //{
    //    if (estChien) {

    //        animS.Play("estToucher", 0, 0f);
    //        //animS.ResetTrigger("estToucher");
    //        //animS.SetTrigger("estToucher");
    //    }
    //    else if (!estChien)
    //    {
    //       //animS.Play("chat_0 2");
    //    }
    //}
}
