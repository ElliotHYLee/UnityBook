using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim
{
    public AnimationClip idle, runForward, runBackward, runRight, runLeft;
}

public class PlayerCtrl : MonoBehaviour {
    private float h = 0, v = 0;
    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 100;

    public Anim anim;
    public Animation _animation;

    void Start () {
        tr = GetComponent<Transform>();
        _animation = GetComponentInChildren<Animation>();

        _animation.clip = anim.idle;
        _animation.Play();
	}

	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        
        Debug.Log("H = " + h.ToString());
        Debug.Log("V = " + v.ToString());
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));


        if (v >= 0.1f) _animation.CrossFade(anim.runForward.name, 0.3f);
        if (v <= -0.1f) _animation.CrossFade(anim.runBackward.name, 0.3f);
        if (h >= 0.1f) _animation.CrossFade(anim.runLeft.name, 0.3f);
        if (h <= -0.1f) _animation.CrossFade(anim.runRight.name, 0.3f);
    }
}
