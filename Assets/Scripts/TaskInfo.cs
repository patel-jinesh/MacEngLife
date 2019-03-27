using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TaskInfo {
    private List<Task> tasks;

    private const string path = "Assets/Scripts/tasks.txt";

    public TaskInfo() {
        tasks = new List<Task>();

        string[] lines = File.ReadAllLines(path);

        foreach(string line in lines) {
            string[] data = line.Split('|');

            Task task = new Task();
            task.name = data[0];
            task.description = data[1];
            task.type = data[2];
            task.completed = data[3] == "c";
            task.difficulty = int.Parse(data[4]);

            tasks.Add(task);
        }
    }

    public List<Task> getAll() {
        return tasks;
    }

    public Task getTask(int id) {
        return tasks[id];
    }

    public void setDone(int id) {
        tasks[id].completed = true;

        string[] lines = File.ReadAllLines(path);
        lines[id] = lines[id].Replace("|nc|", "|c|");
        File.WriteAllLines(path, lines);
    }
}
