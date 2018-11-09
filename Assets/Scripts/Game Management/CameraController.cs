using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	
	public float deadZoneWidth = 5f;
	public float deadZoneHeight = 5f;
	
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	
	
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		offset = player.transform.position - transform.position;
		if (offset.x > deadZoneWidth) {
			transform.position = new Vector3(player.transform.position.x - deadZoneWidth, transform.position.y, transform.position.z); 
		}
		if (offset.x < -deadZoneWidth) {
			transform.position = new Vector3(player.transform.position.x + deadZoneWidth, transform.position.y, transform.position.z);
		}
		if (offset.y > deadZoneHeight) {
			transform.position = new Vector3(transform.position.x, player.transform.position.y - deadZoneHeight, transform.position.z); 
		}
		if (offset.y < -deadZoneHeight) {
			transform.position = new Vector3(transform.position.x, player.transform.position.y + deadZoneHeight, transform.position.z); 
		}
		
		//transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
	}
}
