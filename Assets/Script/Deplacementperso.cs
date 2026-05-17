using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Deplacementperso : MonoBehaviour
{
    //Pour le déplacement du personnage:
    //https://www.youtube.com/watch?v=POcQy8aZ6Uw

    //variables public

    public float vitessedeplacement = 5f;

    Vector2 deplacementInput;

    public static bool changementScene;
    public GestionJeu gestionJeu;

    //rigidbody
    Rigidbody2D rb;

    //spriteRenderer
    SpriteRenderer sr;

    //Animator
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        //récuperer le script GestionJeu
        GameObject jeu = GameObject.Find("Jeu");
        gestionJeu = jeu.GetComponent<GestionJeu>();
    }

    void Update()
    {
        //animation + deplacement personnage
        if (SceneManager.GetActiveScene().name == "niv-3-chat" || SceneManager.GetActiveScene().name == "niv-3-chien")
        {
            rb.linearVelocity = vitessedeplacement * deplacementInput;

            if(deplacementInput.x != 0 || deplacementInput.y != 0)
            {
                anim.SetBool("Marche", true);
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


    public void OnDeplacement(InputAction.CallbackContext context)
    {
        deplacementInput = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Niv3Bon"))
        {
            anim.SetTrigger("Trouver");
            //audio felicitation

            //changement de scene apres 2 secondes
            Invoke("NivReussis", 2f);
        }
        else if (collision.gameObject.CompareTag("Niv3Mauvais"))
        {
            //audio pas bonne reponse
        }
    }

    public void NivReussis()
    {
        gestionJeu.Niv3Reussis();
    }
}
