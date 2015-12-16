using UnityEngine;
using System.Collections;

public class RayPlane : MonoBehaviour
{
	public float minDistance = 0;
	[SerializeField]
	private Collider RaycastBackPlane;
	[SerializeField]
	private Collider CollisionPlane;

	private Vector3 prevClickPos;
    private bool prevMouseState = false;
	
	/// <summary>
	/// Method called once per frame.
	/// </summary>
	void Update()
    {
		// Hide RayPlane
		CollisionPlane.gameObject.SetActive(false);
		// Si la souris est appuyée, ...
		bool mouseState = Input.GetMouseButton(0);
		if(mouseState)
        {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit();
			// Get the Mouse Raycast
			if(Physics.Raycast(ray, out hitInfo))
            {
				// Get hit point.
				Vector3 clickPos = hitInfo.point;
				// If the raycast hits the plane, ...
				if(hitInfo.collider.Equals(RaycastBackPlane))
                {
					// Get distance between both points
					float distance = Vector2.Distance(clickPos, prevClickPos);
					// If the distance between both points is high enough, ...
					if(distance >= minDistance && prevMouseState)
                    {
						// Place the RayPlane
                        CollisionPlane.transform.position = Vector3.Lerp(clickPos, prevClickPos, 0.5f);
						// Rotate the RayPlane
						float dx = clickPos.x - prevClickPos.x;
						float dy = clickPos.y - prevClickPos.y;
                        CollisionPlane.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dy, dx) * 180 / Mathf.PI);
						// Scale the RayPlane?
						Vector3 RayPlaneScale = CollisionPlane.transform.localScale;
						RayPlaneScale.x = distance;
						CollisionPlane.transform.localScale = RayPlaneScale;
						// Display RayPlane
						CollisionPlane.gameObject.SetActive(true);
                    }
                    // Update previous hit position.
                    prevClickPos = clickPos;
                }
			}
		}
        prevMouseState = mouseState;
	}
}
