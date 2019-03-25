using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldController : MonoBehaviour {
    float speed = 0.1f;

    public LayerMask BlockingLayer;

    private BoxCollider2D _BoxCollider;
    private Rigidbody2D _Rigidbody;
    private Animator _Animator;

    // Start is called before the first frame update
    void Start() {
        this._BoxCollider = this.GetComponent<BoxCollider2D>();
        this._Rigidbody = this.GetComponent<Rigidbody2D>();
        this._Animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 position = this.transform.position;
            Vector3 position2 = Camera.current.transform.position;
            position.x -= speed;
            position2.x -= speed;   
            this.transform.position = position;
            Camera.current.transform.position = position2;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 position = this.transform.position;
            Vector3 position2 = Camera.current.transform.position;
            position.x += speed;
            position2.x += speed;
            this.transform.position = position;
            Camera.current.transform.position = position2;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 position = this.transform.position;
            Vector3 position2 = Camera.current.transform.position;
            position.y += speed;
            position2.y += speed;
            this.transform.position = position;
            Camera.current.transform.position = position2;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 position = this.transform.position;
            Vector3 position2 = Camera.current.transform.position;
            position.y -= speed;
            position2.y -= speed;
            this.transform.position = position;
            Camera.current.transform.position = position2;
        }
    }
}
