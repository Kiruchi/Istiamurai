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
            Destroy(this.gameObject);
        }
    }

}
