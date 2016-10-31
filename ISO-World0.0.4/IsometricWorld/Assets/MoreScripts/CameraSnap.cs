using UnityEngine;
using System.Collections;

public class CameraSnap : MonoBehaviour {

    float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.E))
        {

            Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, new Vector3(90, 0, 0), Time.deltaTime * speed);
        }
	}
}
