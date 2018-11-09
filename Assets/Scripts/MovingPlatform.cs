using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject platform;
    public float moveSpeed;
    public Transform startPoint;
    public Transform endPoint;
    bool moveRight = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(platform.transform.position.x >= endPoint.position.x)
        {
            moveRight = false;
        }
        if(platform.transform.position.x <= startPoint.position.x)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            platform.transform.position = new Vector2(platform.transform.position.x + moveSpeed * Time.deltaTime, platform.transform.position.y);
        }
        else
        {
            platform.transform.position = new Vector2(platform.transform.position.x - moveSpeed * Time.deltaTime, platform.transform.position.y);
        }
	}
}
