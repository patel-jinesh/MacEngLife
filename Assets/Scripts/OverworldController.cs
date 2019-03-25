using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldController : MonoBehaviour {
    float speed = 0.1f;

    // Start is called before the first frame update
    void Start() {
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
        TaskUI obj = Instantiate(new TaskUI()) as TaskUI;
    }
}
