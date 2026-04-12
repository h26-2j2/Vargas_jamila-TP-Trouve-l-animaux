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
        }
        else if (SceneAleatoire >= 50f)
        {
            SceneManager.LoadScene("niv-1-chat");
            audioS.PlayOneShot(nivchat, 20f);    
        }
    }

    //recommencer le jeu 
    public void Recommencer()
    {
        if(Niv1.changementScene == true)
        {
            //enlever le son
            audioS.Stop();
            //remettre la variable a false
            Niv1.changementScene = false;
            //mettre la scene du départ
            SceneManager.LoadScene("intro");
        }
    }
}
