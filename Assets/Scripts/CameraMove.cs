using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    float lastXmouse = 1000,diffX=0;
    public GameObject SnakeBody;
    List<Vector3> bodyPos = new List<Vector3>();
	// Use this for initialization
	void Start () {
	}
    private void FixedUpdate()
    {
        Vector3 oldHeadPos = transform.GetChild(0).position;
        transform.position = new Vector3(0, transform.position.y + Time.fixedDeltaTime*2, -10);
       
        if (lastXmouse!=1000)
        {
            lastXmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            transform.GetChild(0).localPosition += new Vector3((lastXmouse+diffX-transform.GetChild(0).position.x)*0.15f,0,0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            lastXmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            diffX = transform.GetChild(0).position.x - lastXmouse;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastXmouse = 1000;
        }
        bodyPos.RemoveAt(0);
        bodyPos.Add(transform.GetChild(0).position);
        SnakeBody.GetComponent<LineRenderer>().SetPositions(bodyPos.ToArray());
        Vector2 headDirection = (transform.GetChild(0).position - oldHeadPos);
        transform.GetChild(0).eulerAngles = new Vector3(0, 0,-Mathf.Atan(headDirection.x/headDirection.y ) * 180 / Mathf.PI);
    }
}
