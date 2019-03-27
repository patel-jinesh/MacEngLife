using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldController : MonoBehaviour {
    float speed = 0.1f;

    public TaskController taskController;

    private Vector3 initial;

    // Start is called before the first frame update
    void Start() {
        taskController.ui.OnClose += TaskUIClosed;
        initial = this.transform.position;
    }

    private void TaskUIClosed() {
        speed = 0.1f;
        this.transform.position = initial;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 position = this.transform.position;
            position.x -= speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 position = this.transform.position;
            position.x += speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 position = this.transform.position;
            position.y += speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 position = this.transform.position;
            position.y -= speed;
            this.transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        taskController.ui.display();
        speed = 0;
    }
}
