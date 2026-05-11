using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.InputSystem;

public class GestionJeu : MonoBehaviour
{
    //Generer un Scene Aléatoire   
    private float SceneAleatoire = 0f;


    //sons
    public AudioClip nivchat;
    public AudioClip nivchien;

    AudioSource audioS;

    void Start()
    {
        //Generer le nombre au Debut du Jeu
        SceneAleatoire = Random.Range(0f, 100f);
        //Garder le script entre les Scènes
        DontDestroyOnLoad(gameObject);

        //Récupérer le composant AudioSource
        audioS = GetComponent<AudioSource>();

        //Recommencer le jeu après 10 secondes
        Invoke("Recommencer",10f);
        
        //Melange premier fois
        SceneAleatoire = Random.Range(0f, 100f);
    }

    void Update()
    {
        //Demarrer le Jeu
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DemarrerJeu();
        }
        
    }

    //Activer avec le bouton Demarrer
    public void DemarrerJeu()
    {
        //Scene aleatoire niveau 1
        if (SceneAleatoire < 50f)
        {
            SceneManager.LoadScene("niv-1-chien");
            audioS.PlayOneShot(nivchien, 20f);
            SceneAleatoire = Random.Range(0f, 100f);
        }
        else if (SceneAleatoire >= 50f)
        {
            SceneManager.LoadScene("niv-1-chat");
            audioS.PlayOneShot(nivchat, 20f);
            SceneAleatoire = Random.Range(0f, 100f);
        }
    }

    public void Niv1Reussis()
    {
        
        if (Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-1-chien" ||
            Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-1-chat") {
            Debug.Log("Niv1Reussis"); 
          
            if(SceneAleatoire < 50f)
            {
                SceneManager.LoadScene("niv-2-chien");
                //audioS.PlayOneShot(nivchien, 20f);
                SceneAleatoire = Random.Range(0f, 100f);

            }
        else if (SceneAleatoire >= 50f)
            {
                SceneManager.LoadScene("niv-2-chat");
                //audioS.PlayOneShot(nivchat, 20f);
                SceneAleatoire = Random.Range(0f, 100f);

            } 
            Interractivitéanimaux.changementScene = false;
        }
    }

    public void Niv2Reussis()
    {
        if (Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-2-chien" ||
           Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-2-chat")
        {
            Debug.Log("Niv2Reussis");
            if (SceneAleatoire < 50f)
            {
                SceneManager.LoadScene("niv-3-chien");
                //audioS.PlayOneShot(nivchien, 20f);

            }
            else if (SceneAleatoire >= 50f)
            {
                SceneManager.LoadScene("niv-3-chat");
                //audioS.PlayOneShot(nivchat, 20f);

            }
            Interractivitéanimaux.changementScene = false;
        }
    }

    public void Niv3Reussis()
    {

    }
    //recommencer le jeu 
    public void Recommencer()
    {
        //if (Interractivitéanimaux.changementScene == true)
        //{
        //    //enlever le son
        //    audioS.Stop();
        //    //remettre la variable a false
        //    Interractivitéanimaux.changementScene = false;
        //    //mettre la scene du départ
        //    SceneManager.LoadScene("intro");
        //}
    }
}
