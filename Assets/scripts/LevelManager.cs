using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject currentCheckpoint;
	public Supermom_controller supermom;

	// Use this for initialization
	void Start () {
		supermom = FindObjectOfType<Supermom_controller> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
public void Respawn()
	{
		supermom.transform.position = currentCheckpoint.transform.position;
	}
}
