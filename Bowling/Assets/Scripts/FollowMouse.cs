using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	// mouse position on the screen
	private Vector3 _position;

	// public accessors (read-only)
	public Vector3 position {
		get 
		{
			return _position;
		}
	}
	
	void Awake () 
	{	
		_position = Vector3.zero;
	}

	void Update()
	{
		RaycastHit raycastHit;
		if( Physics.Raycast(Camera.main.ScreenPointToRay (Input.mousePosition), out raycastHit, Mathf.Infinity) )
		{
			_position.x = raycastHit.point.x;
			_position.y = raycastHit.point.y;
			_position.z = raycastHit.point.z;
		}
	}
}


