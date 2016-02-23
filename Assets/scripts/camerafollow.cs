using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
	public Supermom_controller Supermom;
	public bool isfollowing;
	
	public float XoffSet;
	public float YoffSet;
	// Use this for initialization
	void Start () {
		Supermom =FindObjectOfType<Supermom_controller> ();
		isfollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isfollowing)
			transform.position = new Vector3 (Supermom.transform.position.x + XoffSet, Supermom.transform.position.y + YoffSet, -10);	
	}
}
