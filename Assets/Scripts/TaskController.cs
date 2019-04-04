using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour {
    public TaskUI ui;
    public TaskInfo ti;
    public GameObject tmpltTask;

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
        }
    }
}
