using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobController : MonoBehaviour
{
    public JobUI ui;
    public JobInfo ji;
    public GameObject tmpltJob;

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
            go.GetComponent<Button>().enabled = true;
            go.GetComponent<Button>().onClick.AddListener(() => apply(index));
        }

        ui.OnClose += () => { OnClose?.Invoke(); };
    }

    public void apply(int id) {
        PlayerStatsInfo info = this.gameObject.GetComponent<OverworldController>().getStats();
        if (ji.getJob(id).criteria < info.experience + info.intelligence) {
            GameObject tl = GameObject.Find("JobsList");
            Destroy(tl.GetComponentsInChildren<Button>()[id].gameObject);
            StartCoroutine(ui.displayDone());
        } else {
            StartCoroutine(ui.displayIncomplete());
        }
    }

    public delegate void GUI();
    public event GUI OnClose;
}
