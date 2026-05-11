using UnityEngine;
using UnityEngine.EventSystems;

public class Niv2balles : MonoBehaviour
{
    //Permet d'effacer les balles
    public void Prendballe(BaseEventData eventData)
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<Collider2D>().enabled = false;

    }


}
