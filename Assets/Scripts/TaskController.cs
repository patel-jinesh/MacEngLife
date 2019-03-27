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
            Text t = go.GetComponentInChildren<Text>();
            t.text = task.name;
            go.transform.SetParent(tmpltTask.transform.parent);
            Vector3 pos = go.transform.position;
            pos.x = 0;
            go.transform.position = pos;
            go.GetComponent<Button>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
