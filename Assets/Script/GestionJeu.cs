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
            //load la scene du chien
            SceneManager.LoadScene("niv-1-chien");
            //audio niveau jeu
            audioS.PlayOneShot(nivchien, 20f);
            //change la scene aleatoire pour le prochain niveau
            SceneAleatoire = Random.Range(0f, 100f);
        }
        else if (SceneAleatoire >= 50f)
        {
            //load la scene du chat
            SceneManager.LoadScene("niv-1-chat");
            //audio niveau jeu
            audioS.PlayOneShot(nivchat, 20f);
            //change la scene aleatoire pour le prochain niveau
            SceneAleatoire = Random.Range(0f, 100f);
        }
    }

    //Changement de scene après la réussite du niveau 1
    public void Niv1Reussis()
    {
        
        if (Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-1-chien" ||
            Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-1-chat") {
            //Debug pour vérifier niveau change
            Debug.Log("Niv1Reussis"); 
          
            if(SceneAleatoire < 50f)
            {
                //load la scene du chien
                SceneManager.LoadScene("niv-2-chien");
                //audio niveau jeu
                //audioS.PlayOneShot(nivchien, 20f);
                //change la scene aleatoire pour le prochain niveau
                SceneAleatoire = Random.Range(0f, 100f);

            }
        else if (SceneAleatoire >= 50f)
            {
                //load la scene du chat
                SceneManager.LoadScene("niv-2-chat");
                //audio niveau jeu
                //audioS.PlayOneShot(nivchat, 20f);
                //change la scene aleatoire pour le prochain niveau
                SceneAleatoire = Random.Range(0f, 100f);

            }
            //remettre la variable a false pour prochain niveau
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
                //load la scene du chien
                SceneManager.LoadScene("niv-3-chien");
                //audio niveau jeu
                //audioS.PlayOneShot(nivchien, 20f);
                //change la scene aleatoire pour le prochain niveau
                SceneAleatoire = Random.Range(0f, 100f);

            }
            else if (SceneAleatoire >= 50f)
            {
                //load la scene du chat
                SceneManager.LoadScene("niv-3-chat");
                //audio niveau jeu
                //audioS.PlayOneShot(nivchat, 20f);
                //change la scene aleatoire pour le prochain niveau
                SceneAleatoire = Random.Range(0f, 100f);

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
