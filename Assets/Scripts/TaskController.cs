using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskController : MonoBehaviour {
    public TaskUI ui;
    public TaskInfo ti;
    public GameObject tmpltTask;
    public GameObject list;
    public static MinigameController mg;

    // Start is called before the first frame update
    void Start() {
        tmpltTask.SetActive(false);

        ti = new TaskInfo();

        ui.OnClose += () => { OnClose?.Invoke(); };
    }

    public void display(string type) {
        foreach (Button btn in list.GetComponentsInChildren<Button>()) {
            Destroy(btn.gameObject);
        }

        List<Task> tasks = ti.getAll();
        for (int i = 0; i < tasks.Count; i++) {
            int index = i;
            Task task = tasks[i];
            if (task.type != type) {
                continue;
            }
            GameObject go = Instantiate(tmpltTask) as GameObject;
            go.SetActive(true);
            Text[] t = go.GetComponentsInChildren<Text>();
           t[0].text = task.description;
            t[1].text = "\nDifficulty : " + task.difficulty.ToString() + ", HP Gain: " + task.health.ToString() + ", INT Gain: " + task.intel.ToString() + ", XP Gain: " + task.xp.ToString();
            go.transform.SetParent(tmpltTask.transform.parent);
            go.GetComponent<Button>().enabled = false;

            if (task.completed) {
                go.GetComponent<Button>().enabled = false;
                Texture2D tex = Resources.Load<Texture2D>("Controls/itemcomp") as Texture2D;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 857, 92), new Vector2(0.5f, 0.5f));
                this.gameObject.GetComponent<OverworldController>().updateStats(task.difficulty, task.xp, task.intel, task.health);
                go.GetComponent<Image>().sprite = sprite;
            } else {
                go.GetComponent<Button>().enabled = true;
                int v = list.GetComponentsInChildren<Button>().Length - 1;
                go.GetComponent<Button>().onClick.AddListener(() => { /*Minigame stuff*/
                    this.gameObject.AddComponent(typeof(MinigameController));
                    mg = this.gameObject.GetComponent<MinigameController>();
                    ui.gameObject.SetActive(false);
                    mg.playMinigame(task);
                    mg.OnClose += () => {
                        ui.gameObject.SetActive(true);
                        if (mg.result == 'c') {
                            StartCoroutine(ui.displayDone());
                            ti.setDone(index);
                            Texture2D tex = Resources.Load<Texture2D>("Controls/itemcomp") as Texture2D;
                            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 857, 92), new Vector2(0.5f, 0.5f));
                            Debug.Log(v);
                            list.GetComponentsInChildren<Button>()[v].gameObject.GetComponent<Image>().sprite = sprite;
                            this.gameObject.GetComponent<OverworldController>().updateStats(task.difficulty, task.xp, task.intel, task.health);
                        } else {
                            StartCoroutine(ui.displayIncomplete());
                        }

                        Destroy(mg);
                    };
                });
            }
        }

        ui.display();
    }

    public void wipe() {
        ti.wipe();

        foreach (Button btn in list.GetComponentsInChildren<Button>()) {
            Destroy(btn.gameObject);
        }

        Start();
    }

    public delegate void GUI();
    public event GUI OnClose;
}
