using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OverworldController : MonoBehaviour {
    float speed = 0.1f;

    public TaskController taskController;
    public CharacterSelectionController characterSelectionController;
    public StatsController statsController;

    private Vector3 initial;

    // Start is called before the first frame update
    void Start() {
        taskController.OnClose += UIClosed;
        characterSelectionController.OnClose += UIClosed;
        initial = this.transform.position;

        if (!File.Exists("Assets/Scripts/player.txt")) {
            characterSelectionController.ui.display();
            speed = 0;
        }
    }

    private void UIClosed() {
        speed = 0.1f;
        this.transform.position = initial;
    }

    public void setMultipliers(float xp, float intel, float health) {
        statsController.setMultipliers(xp, intel, health);
    }

    public void setStats(int xp, int intel, int health) {
        statsController.setStats(xp, intel, health);
    }

    public void updateStats(float mul, int xp, int intel, int health) {
        statsController.updateStats(mul, xp, intel, health);
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
