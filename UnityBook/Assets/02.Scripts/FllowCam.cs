using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCam : MonoBehaviour {
    public Transform targetTr;
    public float dist = 10.0f;
    public float height = 3;
    public float dampTrace = 20;
    private Transform tr;
	
	void Start () {
        tr = GetComponent<Transform>();
	}

    private void LateUpdate()
    {
        tr.position = Vector3.Lerp(tr.position, targetTr.position - (targetTr.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
        tr.LookAt(targetTr.position);
    }
}
