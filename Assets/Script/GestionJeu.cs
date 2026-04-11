using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.InputSystem;

public class GestionJeu : MonoBehaviour
{
    //Generer un Scene Aléatoire   
    public float SceneAleatoire = 0f;

    void Start()
    {
        //Generer le nombre au Debut du Jeu
        SceneAleatoire = Random.Range(0f, 100f);
        //Garder le script entre les Scènes
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        //Demarrer le Jeu avec la touche Espace
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DemarrerJeu();
        }
    }

    //Activer avec le bouton Demarrer
    public void DemarrerJeu()
    {
        //Scene aleatoire
        if (SceneAleatoire < 50f)
        {
            SceneManager.LoadScene("niv-1-chien");
        }
        else if (SceneAleatoire >= 50f)
        {
            SceneManager.LoadScene("niv-1-chat");
        }
    }
    //public void Recommencer()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    ////}
}
