using UnityEngine;
using UnityEngine.SceneManagement;

public class Interractivitéanimaux : MonoBehaviour
{
    //variables public
    public bool estChien;
    public string reponse;

    public static bool changementScene;
    public GestionJeu gestionJeu;

    //animation
    public GameObject Victoire;

    Animator anim;

    //sons
    public AudioClip bravoS;
    public AudioClip erreurS;

    public AudioClip Mbravo;

    AudioSource audioS;

    void Start()
    {
        //récupérer le composant AudioSource
        audioS = GetComponent<AudioSource>();
        //recuperer le composant Animator
        anim = GetComponent<Animator>();

        //récuperer le script GestionJeu
        GameObject jeu = GameObject.Find("Jeu");
        gestionJeu = jeu.GetComponent<GestionJeu>();
        

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

            //changement de scene a true pour gestionJeu
            changementScene = true;
            //animation de reussite
            anim.SetTrigger("Reussir");

            //changement de scene apres 2 secondes
            Invoke("NivReussis", 2f);
        }
        else if (!estChien && reponse == "chat")
        {
            
            //audio
            audioS.PlayOneShot(bravoS, 5f);
            audioS.PlayOneShot(Mbravo, 0.2f);
            //animation victoire
            Victoire.SetActive(true);

            //changement de scene a true pour gestionJeu
            changementScene = true;
            //animation de reussite
            anim.SetTrigger("Reussir");

            //changement de scene apres 2 secondes
            Invoke("NivReussis", 2f);
        }
        else
        {
            //assurer que le changement de scene est a falsw
            changementScene = false;
            //si pas bonne reponse
            audioS.PlayOneShot(erreurS, 5f);
        }
    }

    //changement de scene apres la reussite du niveau
    public void NivReussis()
    {

        if (changementScene && SceneManager.GetActiveScene().name == "niv-1-chien" ||
      changementScene && SceneManager.GetActiveScene().name == "niv-1-chat")
        {
            gestionJeu.Niv1Reussis();
        }
        else if (changementScene && SceneManager.GetActiveScene().name == "niv-2-chien" ||
            changementScene && SceneManager.GetActiveScene().name == "niv-2-chat")
        {
            gestionJeu.Niv2Reussis();
        }
    }
}
