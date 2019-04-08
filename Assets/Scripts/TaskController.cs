using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour {
    public TaskUI ui;
    public TaskInfo ti;
    public GameObject tmpltTask;
    public GameObject list;

    // Start is called before the first frame update
    void Start() {
        tmpltTask.SetActive(false);

        ti = new TaskInfo();
        GameObject tl = GameObject.Find("TasksList");

        foreach (Task task in ti.getAll()) {
            GameObject go = Instantiate(tmpltTask) as GameObject;
            go.SetActive(true);
            Text[] t = go.GetComponentsInChildren<Text>();
            t[0].text = task.name;
            t[1].text = task.description;
            go.transform.SetParent(tmpltTask.transform.parent);
            go.GetComponent<Button>().enabled = false;

            if (task.completed) {
                go.GetComponent<Button>().enabled = false;
                Texture2D tex = Resources.Load<Texture2D>("Controls/itemcomp") as Texture2D;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 857, 92), new Vector2(0.5f, 0.5f));
                go.GetComponent<Image>().sprite = sprite;
            } else {
                go.GetComponent<Button>().enabled = true;
                go.GetComponent<Button>().onClick.AddListener(() => { /*Minigame stuff*/ });
            }
        }

        ui.OnClose += () => { OnClose?.Invoke(); };
    }

    public void display() {
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
