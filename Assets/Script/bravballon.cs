using UnityEngine;

public class bravballon : MonoBehaviour
{
    //vitesse de déplacement du ballon
    public float vitesseY = 1f;

    //limite de déplacement du ballon
    public float limiteYMax = 20f;
    public float limiteYMin = -25f;

    //position X aleatoire du ballon
    float positionX;

    void Start()
    {
        //générer une position X aléatoire pour le ballon au début
        positionX = Random.Range(-10f, 10f);
    }

    void Update()
    {
        //deplacer le ballon vers le haut
        float deplacementY = transform.position.y + vitesseY * Time.deltaTime;

        //si ballon limiteY retourne en bas aleatoirement
        if (deplacementY > limiteYMax)
        {
            //générer une nouvelle position X aléatoire pour le ballon
            positionX = Random.Range(-10f, 10f);
            //ajouter positionx
            limiteYMin = limiteYMin + positionX;
            //nouveau deplacement
            deplacementY = limiteYMin;
        }
        //mettre a jour la position du ballon
        transform.position = new Vector2(positionX, deplacementY);
    }
}
