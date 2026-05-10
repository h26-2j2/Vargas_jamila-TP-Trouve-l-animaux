using UnityEngine;

public class Interractivitéanimaux : MonoBehaviour
{
    //variables public
    public bool estChien;
    public string reponse;

    public static bool changementScene;
    public GestionJeu gestionJeu;

    //sprites

    //animation
    public GameObject Victoire;
    //public Animator VictoireA;

    //sons
    public AudioClip bravoS;
    public AudioClip erreurS;

    public AudioClip Mbravo;

    AudioSource audioS;

    void Start()
    {
        //récupérer le composant AudioSource
        audioS = GetComponent<AudioSource>();
        GameObject jeu = GameObject.Find("Jeu");
        gestionJeu = jeu.GetComponent<GestionJeu>();
        //changementScene = false;

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
            //VictoireA.Play("Victoire", 0, 1f);

            changementScene = true;

            Invoke("NivReussis", 2f);
        }
        else if (!estChien && reponse == "chat")
        {
            //audio
            audioS.PlayOneShot(bravoS, 5f);
            audioS.PlayOneShot(Mbravo, 0.2f);
            //animation victoire
            Victoire.SetActive(true);
            //VictoireA.Play("Victoire", 0, 0f);

            changementScene = true;

           Invoke("NivReussis", 2f);
        }
        else
        {
            Debug.Log("Mauvaise réponse");
            changementScene = false;
            //si pas bonne reponse
            audioS.PlayOneShot(erreurS, 5f);
        }
    }
    public void NivReussis()
    {
                if (changementScene)
        {
            gestionJeu.Niv1Reussis();
        }
    }
}
