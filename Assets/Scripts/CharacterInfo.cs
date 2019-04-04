using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharacterInfo {
    private List<Model> models;

    private const string path = "Assets/Scripts/models.txt";

    public CharacterInfo() {
        models = new List<Model>();

        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines) {
            string[] data = line.Split('|');

            Model model = new Model();
            model.name = data[0];
            model.description = data[1];
            model.experienceMultiplier = float.Parse(data[2]);
            model.intelligenceMultiplier = float.Parse(data[3]);
            model.healthMultiplier = float.Parse(data[4]);
            model.baseExperience = int.Parse(data[5]);
            model.baseIntelligence = int.Parse(data[6]);
            model.baseHealth = int.Parse(data[6]);

            models.Add(model);
        }
    }

    public List<Model> getAll() {
        return models;
    }

    public Model getModel(int id) {
        return models[id];
    }
}
