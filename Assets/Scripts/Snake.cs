using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    bool ate = false;
    public MinigameController mg;


    public bool isDied = false;
    public bool end = false;
    public int count = 0;

    public GameObject tailPrefab;

    Vector2 dir = Vector2.right;

    List<Transform> tail = new List<Transform>();

    void Start() {
        mg = TaskController.mg;
        InvokeRepeating("Move", 0.1f, 0.1f);
    }


    void Update() {
        if (!isDied) {
            // Move in a new Direction
            if (Input.GetKey(KeyCode.RightArrow))
                dir = Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow))
                dir = -Vector2.up;
            else if (Input.GetKey(KeyCode.LeftArrow))
                dir = -Vector2.right;
            else if (Input.GetKey(KeyCode.UpArrow))
                dir = Vector2.up;
        } else {
            if (count >= 5) {
                mg.SetResult('c');
            } else {
                mg.SetResult('f');
            }
        }
    }

    void Move() {
        if (!isDied) {

            Vector2 v = transform.position;


            transform.Translate(dir);


            if (ate) {

                GameObject g = (GameObject)Instantiate(tailPrefab,
                                  v,
                                  Quaternion.identity);
                tail.Insert(0, g.transform);


                ate = false;
            } else if (tail.Count > 0) {
                tail.Last().position = v;

                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (count < 6) {
            // Food?
            if (coll.name.StartsWith("Food")) {
                ate = true;
                count++;
                Destroy(coll.gameObject);
            } else {
                isDied = true;
            }
        } else {
            isDied = true;
            end = true;
        }
        // Food?
    }
}
