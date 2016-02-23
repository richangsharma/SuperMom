using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform Supermom;
	public Vector2
		Margin,
		smoothing;
	public BoxCollider2D Bounds;
	private Vector3
		_min,
		_max;
	public bool isFollowing{ get; set; }
	public Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		var x = transform.position.x;
		var y = transform.position.y;
		if (isFollowing) {
			if(Mathf.Abs(x-Supermom.position.x)>Margin.x)
				x=Mathf.Lerp(x,Supermom.position.x,smoothing.x*Time.deltaTime);
			if(Mathf.Abs(y-Supermom.position.y)>Margin.y)
				y=Mathf.Lerp(y,Supermom.position.y,smoothing.y*Time.deltaTime);
		}
		var cameraHalfWidth = cam.orthographicSize * ((float)Screen.width / Screen.height);
		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + cameraHalfWidth, _max.y - cameraHalfWidth);
		transform.position = new Vector3 (x, y, transform.position.z);

	}
}
