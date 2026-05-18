using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GestionJeu : MonoBehaviour
{
    //Generer un Scene Aléatoire   
    private float SceneAleatoire = 0f;

    //variables public
    public bool finintro;

    //sons
    public AudioClip niv1chat;
    public AudioClip niv1chien;

    public AudioClip niv2chat;
    public AudioClip niv2chien;

    public AudioClip niv3chat;
    public AudioClip niv3chien;

    public AudioClip Mfin;

    AudioSource audioS;

    void Start()
    {
        //Generer le nombre au Debut du Jeu
        SceneAleatoire = Random.Range(0f, 100f);

        //Garder le script entre les Scènes
        DontDestroyOnLoad(gameObject);

        //Récupérer le composant AudioSource
        audioS = GetComponent<AudioSource>();

        //Melange premier fois
        SceneAleatoire = Random.Range(0f, 100f);

        //mettre fin intro false 
        finintro = false;
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
            audioS.PlayOneShot(niv1chien, 20f);

            //laisser l'intro
            Invoke("Finirintro", 5f);

            //change la scene aleatoire pour le prochain niveau
            SceneAleatoire = Random.Range(0f, 100f);
        }
        else if (SceneAleatoire >= 50f)
        {
            //load la scene du chat
            SceneManager.LoadScene("niv-1-chat");
            //audio niveau jeu
            audioS.PlayOneShot(niv1chat, 20f);

            //laisser l'intro
            Invoke("Finirintro", 5f);

            //change la scene aleatoire pour le prochain niveau
            SceneAleatoire = Random.Range(0f, 100f);
        }
    }

    //Changement de scene après la réussite du niveau 1
    public void Niv1Reussis()
    {

        if (Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-1-chien" ||
            Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-1-chat")
        {
            //Debug pour vérifier niveau change
            Debug.Log("Niv1Reussis");

            if (SceneAleatoire < 50f)
            {
                //load la scene du chien
                SceneManager.LoadScene("niv-2-chien");

                //audio niveau jeu
                audioS.PlayOneShot(niv2chien, 20f);

                //laisser l'intro
                Invoke("Finirintro", 7f);

                //change la scene aleatoire pour le prochain niveau
                SceneAleatoire = Random.Range(0f, 100f);
            }
            else if (SceneAleatoire >= 50f)
            {
                //load la scene du chat
                SceneManager.LoadScene("niv-2-chat");

                //audio niveau jeu
                audioS.PlayOneShot(niv2chat, 20f);

                //laisser l'intro
                Invoke("Finirintro", 7f);

                //change la scene aleatoire pour le prochain niveau
                SceneAleatoire = Random.Range(0f, 100f);
            }
            //remettre la variable a false pour prochain niveau
            Interractivitéanimaux.changementScene = false;
        }
    }

    //Changement de scene après la réussite du niveau 2
    public void Niv2Reussis()
    {
        if (Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-2-chien" ||
           Interractivitéanimaux.changementScene == true && SceneManager.GetActiveScene().name == "niv-2-chat")
        {
            //Debug pour vérifier niveau change
            Debug.Log("Niv2Reussis");

            if (SceneAleatoire >= 0f && SceneAleatoire < 25f)
            {
                //arreter audio niveau precedent
                audioS.Stop();
                //load la scene du chien
                SceneManager.LoadScene("niv-3-chien");

                //audio niveau jeu
                audioS.PlayOneShot(niv3chien, 20f);

                //laisser l'intro
                Invoke("Finirintro", 7f);
            }
            else if (SceneAleatoire >= 25f && SceneAleatoire < 50f)
            {
                //arreter audio niveau precedent
                audioS.Stop();

                //load la scene du chien
                SceneManager.LoadScene("niv-3-chien-alt");

                //audio niveau jeu
                audioS.PlayOneShot(niv3chien, 20f);

                //laisser l'intro
                Invoke("Finirintro", 7f);

            }
            else if (SceneAleatoire >= 50f && SceneAleatoire < 75f)
            {
                //arreter audio niveau precedent
                audioS.Stop();

                //load la scene du chat
                SceneManager.LoadScene("niv-3-chat");

                //audio niveau jeu
                audioS.PlayOneShot(niv3chat, 20f);

                //laisser l'intro
                Invoke("Finirintro", 7f);
            }
            else if (SceneAleatoire >= 75f)
            {
                //arreter audio niveau precedent
                audioS.Stop();

                //load la scene du chat
                SceneManager.LoadScene("niv-3-chat-alt");

                //audio niveau jeu
                audioS.PlayOneShot(niv3chat, 20f);

                //laisser l'intro
                Invoke("Finirintro", 7f);
            }
            Interractivitéanimaux.changementScene = false;
        }
    }

    //Changement de scene après la réussite du niveau 3
    public void Niv3Reussis()
    {
        if (SceneManager.GetActiveScene().name == "niv-3-chien" || SceneManager.GetActiveScene().name == "niv-3-chat" || SceneManager.GetActiveScene().name == "niv-3-chien-alt" || SceneManager.GetActiveScene().name == "niv-3-chat-alt")
        {
            //Debug pour vérifier niveau change
            Debug.Log("Niv3Reussis");

            //arreter audio niveau precedent
            audioS.Stop();
            //charger la scene de fin
            SceneManager.LoadScene("bravo");
            //son de fin
            audioS.PlayOneShot(Mfin, 8f);

            //recommencer le jeu après 5 secondes
            Invoke("Recommencer", 5f);
        }
    }
    //recommencer le jeu 
    public void Recommencer()
    {
        //enlever le son
        audioS.Stop();

        //remettre la variable a false
        Interractivitéanimaux.changementScene = false;
        //mettre la scene du départ
        SceneManager.LoadScene("intro");
        //Assurer que la variable change
        SceneAleatoire = Random.Range(0f, 100f);

        //detruit le script pour recommencer le jeu
        Destroy(gameObject);
    }

    //ceci permet a l'intro de jouer avan que le joueur click sur l'animal
    public void Finirintro()
    {
        Debug.Log("Fin intro");
        finintro = true;
    }
}
