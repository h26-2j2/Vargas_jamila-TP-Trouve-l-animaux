using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Deplacementperso : MonoBehaviour
{
    //variables public
    public float Vitesse = 5f;


    //Animator
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //animation + deplacement personnage
        if (SceneManager.GetActiveScene().name == "niv-3-chat")
        {
         
        }

        //Bravo animation
        if (SceneManager.GetActiveScene().name == "bravo")
        {
            anim.SetBool("Bravo", true);
        }
    }
}
