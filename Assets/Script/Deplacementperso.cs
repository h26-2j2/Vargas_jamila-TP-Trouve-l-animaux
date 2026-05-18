using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Deplacementperso : MonoBehaviour
{
    //Pour le d�placement du personnage:
    //https://www.youtube.com/watch?v=POcQy8aZ6Uw

    //variables public

    public float vitessedeplacement = 5f;

    Vector2 deplacementInput;

    public GestionJeu gestionJeu;

    //sons
    public AudioClip bravoS;
    public AudioClip erreurS;

    AudioSource audioS;

    //rigidbody
    Rigidbody2D rb;

    //spriteRenderer
    SpriteRenderer sr;

    //Animator
    public GameObject Victoire;

    Animator anim;


    void Start()
    {
        //r�cup�rer les composants
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioS = GetComponent<AudioSource>();

        //r�cuperer le script GestionJeu
        GameObject jeu = GameObject.Find("Jeu");
        gestionJeu = jeu.GetComponent<GestionJeu>();
    }

    void Update()
    {
        //animation + deplacement personnage
        if (SceneManager.GetActiveScene().name == "niv-3-chat" || SceneManager.GetActiveScene().name == "niv-3-chien" || SceneManager.GetActiveScene().name == "niv-3-chat-alt" || SceneManager.GetActiveScene().name == "niv-3-chien-alt")
        {
            //deplacement du personnage
            rb.linearVelocity = vitessedeplacement * deplacementInput;

            //animation de marche
            if (deplacementInput.x != 0 || deplacementInput.y != 0)
            {
                anim.SetBool("Marche", true);
                //permet de flipper le perso
                sr.flipX = rb.linearVelocity.x > 0;
            }
            else
            {
                anim.SetBool("Marche", false);
            }

        }

        //Bravo animation
        if (SceneManager.GetActiveScene().name == "bravo")
        {
            anim.SetTrigger("Trouver");
        }
    }

    //pour mouvement personnage
    public void OnDeplacement(InputAction.CallbackContext context)
    {
        deplacementInput = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //finir audio intro
        if (gestionJeu.finintro)
        {
            if (collision.gameObject.CompareTag("Niv3Bon"))
            {
                //animation victoire
                anim.SetTrigger("Trouver");
                Victoire.SetActive(true);

                //audio felicitation
                audioS.PlayOneShot(bravoS, 5f);

                //changement de scene apres 2 secondes
                Invoke("NivReussis", 2f);
            }
            else if (collision.gameObject.CompareTag("Niv3Mauvais"))
            {
                //audio pas bonne reponse
                audioS.PlayOneShot(erreurS, 5f);
            }
        }
    }

    //chercher fonction niv3reussir
    public void NivReussis()
    {
        gestionJeu.Niv3Reussis();
    }
}
