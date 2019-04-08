using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobController : MonoBehaviour
{
    public JobUI ui;
    public JobInfo ji;
    public GameObject tmpltJob;
    public GameObject list;

    // Start is called before the first frame update
    void Start() {
        tmpltJob.SetActive(false);

        ji = new JobInfo();
        GameObject tl = GameObject.Find("JobsList");

        for (int idx = 0; idx < ji.getAll().Count; idx++) {
            int index = idx;
            Job job = ji.getJob(idx);
            GameObject go = Instantiate(tmpltJob) as GameObject;
            go.SetActive(true);
            Text[] t = go.GetComponentsInChildren<Text>();
            t[0].text = job.name;
            t[1].text = job.description;
            go.transform.SetParent(tmpltJob.transform.parent);

            if (job.completed) {
                go.GetComponent<Button>().enabled = false;
                Texture2D tex = Resources.Load<Texture2D>("Controls/itemcomp") as Texture2D;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 857, 92), new Vector2(0.5f, 0.5f));
                go.GetComponent<Image>().sprite = sprite;
            } else {
                go.GetComponent<Button>().enabled = true;
                go.GetComponent<Button>().onClick.AddListener(() => apply(index));
            }
        }

        ui.OnClose += () => { OnClose?.Invoke(); };
    }

    public void wipe() {
        ji.wipe();

        foreach (Button btn in list.GetComponentsInChildren<Button>()) {
            Destroy(btn.gameObject);
        }

        Start();
    }

    public void display() {
        ui.display();
    }

    public void apply(int id) {
        PlayerStatsInfo info = this.gameObject.GetComponent<OverworldController>().getStats();
        Job j = ji.getJob(id);
        if (j.criteria < info.experience + info.intelligence) {
            ji.setDone(id);
            GameObject tl = GameObject.Find("JobsList");
            tl.GetComponentsInChildren<Button>()[id].enabled = false;
            Texture2D tex = Resources.Load<Texture2D>("Controls/itemcomp") as Texture2D;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 857, 92), new Vector2(0.5f, 0.5f));
            tl.GetComponentsInChildren<Button>()[id].gameObject.GetComponent<Image>().sprite = sprite;
            StartCoroutine(ui.displayDone());
            if (j.isEndGameJob) {
                this.gameObject.GetComponent<OverworldController>().setEndgame();
            }
        } else {
            StartCoroutine(ui.displayIncomplete());
        }
    }

    public delegate void GUI();
    public event GUI OnClose;
}
