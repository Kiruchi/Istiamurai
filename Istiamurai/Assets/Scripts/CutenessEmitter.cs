using UnityEngine;
using System.Collections;

public class CutenessEmitter : MonoBehaviour
{
    [Range(0.1f, 5.0f)]
    public float timeBetweenEmitions = 2.0f;
    [Range(0.1f, 2.0f)]
    public float amplification = 1.0f;
    public Transform throwableItems;
    public Transform thrownItems;

    [SerializeField]
    private Vector3 impulseDirection;
    private float lastEmitionTime = 0;

	void Update()
    {
        //If time since last emition long enough, ...
        if(Time.time >= lastEmitionTime + timeBetweenEmitions && throwableItems != null)
        {
            //Get a random throwable item.
            if(throwableItems.childCount == 0)
            {
                Debug.LogError("No throwable items available.");
                return;
            }
            Transform item = throwableItems.GetChild(Random.Range(0, throwableItems.childCount - 1));
            //Emit this item.
            GameObject newItem = GameObject.Instantiate(item.gameObject, transform.position, item.rotation) as GameObject;
            //Modify the attributes of the new item.
            newItem.SetActive(true);
            newItem.transform.SetParent(thrownItems);
            newItem.GetComponent<Rigidbody>().AddForce(amplification * impulseDirection, ForceMode.Impulse);
            newItem.GetComponent<Rigidbody>().AddTorque(new Vector3(2, 3, 4), ForceMode.Impulse);
            //Update Emition time
            lastEmitionTime = Time.time;
        }
	}
}
