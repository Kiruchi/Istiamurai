using UnityEngine;
using System.Collections;

public class FlyingObjectBehaviour : MonoBehaviour
{

    [SerializeField]
    private int pointsGiven;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("DestuctionColliders"))
        {
            // Destruction Collider
            Destroy(this.gameObject);
        }
        else if(other.tag.Equals("RayPlane"))
        {
            // RayPlane Collider
            Renderer r = GetComponent<Renderer>();
            if(r != null)
            {
                r.enabled = false;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            this.GetComponent<Collider>().enabled = false;
            GetComponent<Detonator>().Explode();
            GameManager.Instance.Score += pointsGiven;
            if(pointsGiven < 0)
            {
                GameManager.Instance.Lives--;
            }
        }
    }

}
