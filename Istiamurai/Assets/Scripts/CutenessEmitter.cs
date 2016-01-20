using UnityEngine;
using System.Collections;

public class CutenessEmitter : MonoBehaviour
{
    [Range(0.1f, 5.0f)]
    public float timeBetweenEmitions = 2.0f;

    private float lastEmitionTime = 0;
	
	void Update()
    {
        //If time since last emition long enough, ...
	    if(Time.time >= lastEmitionTime + timeBetweenEmitions) {
            //Get a random throwable item.
            GameObject item = null;
            //Emit this item.
            GameObject newItem = GameObject.Instantiate(item, transform.position, transform.rotation) as GameObject;
            //Modify the attributes of the new item.
            //TODO
        }
	}
}
