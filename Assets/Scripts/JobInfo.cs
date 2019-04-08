using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JobInfo {
    private List<Job> jobs;

    private const string path = "Assets/Scripts/jobs.txt";

    public JobInfo() {
        jobs = new List<Job>();

        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines) {
            string[] data = line.Split('|');

            Job job = new Job();
            job.name = data[0];
            job.description = data[1];
            job.type = data[2];
            job.completed = data[3] == "c";
            job.isEndGameJob = data[4] == "y";
            job.criteria = int.Parse(data[5]);

            jobs.Add(job);
        }
    }

    public List<Job> getAll() {
        return jobs;
    }

    public Job getJob(int id) {
        return jobs[id];
    }

    public void setDone(int id) {
        jobs[id].completed = true;

        string[] lines = File.ReadAllLines(path);
        lines[id] = lines[id].Replace("|nc|", "|c|");
        File.WriteAllLines(path, lines);
    }
}
