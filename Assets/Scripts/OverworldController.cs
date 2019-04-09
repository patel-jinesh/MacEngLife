using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class OverworldController : MonoBehaviour {
    float speed = 0.1f;
    bool endgame = false;

    public TaskController taskController;
    public JobController jobController;
    public CharacterSelectionController characterSelectionController;
    public StatsController statsController;

    public EndGameUI endGameUI;
    public PlayerOverviewUI overviewUI;
    public InstructionsUI instructionsUI;

    public Text overview;
    public Image avatar;

    private Vector3 initial;

    // Start is called before the first frame update
    void Start() {
        taskController.OnClose += UIClosed;
        overviewUI.OnClose += UIClosed;
        instructionsUI.OnClose += UIClosed;
        jobController.OnClose += JobUIClosed;
        characterSelectionController.OnClose += UIClosed;
        initial = this.transform.position;

        if (!File.Exists("Assets/Scripts/player.txt")) {
            characterSelectionController.ui.display();
            speed = 0;
        }
    }

    public void setEndgame() {
        endgame = true;
    }

    private void UIClosed() {
        speed = 0.1f;
        this.transform.position = initial;
    }

    private void JobUIClosed() {
        if (endgame) {
            endGameUI.display();
        } else {
            speed = 0.1f;
            this.transform.position = initial;
        }
    }

    public void openPlayerOverviewUI() {
        speed = 0f;
        PlayerStatsInfo stat = getStats();
        overview.text = "Intelligence: " + stat.intelligence.ToString() + "\nExperience: " + stat.experience.ToString() + "\nHealth: " + stat.health.ToString();
        avatar.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        overviewUI.display();
    }

    public void openInstructionsUI() {
        speed = 0f;
        instructionsUI.display();
    }

    public void wipe() {
        File.Delete("Assets/Scripts/player.txt");

        taskController.wipe();
        jobController.wipe();

        endGameUI.close();
        characterSelectionController.display();
    }

    public void setMultipliers(float xp, float intel, float health) {
        statsController.setMultipliers(intel, xp, health);
    }

    public void setStats(int xp, int intel, int health) {
        statsController.setStats(intel, xp, health);
    }

    public void updateStats(float mul, int xp, int intel, int health) {
        statsController.updateStats(mul, intel, xp, health);
    }

    public PlayerStatsInfo getStats() {
        return statsController.getStats();
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
        if (collision.gameObject.name == "Task") {
            taskController.display(collision.gameObject.tag);
        } else {
            jobController.display();
        }
        speed = 0;
    }
}
