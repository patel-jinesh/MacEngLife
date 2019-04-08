using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatsController : MonoBehaviour {
    private PlayerStatsInfo info;

    public StatsController() {
        info = new PlayerStatsInfo();

        if (!File.Exists("Assets/Scripts/player.txt"))
            return;

        string[] data = File.ReadAllLines("Assets/Scripts/player.txt");
        info.intelligenceMultiplier = float.Parse(data[0]);
        info.experienceMultiplier = float.Parse(data[1]);
        info.healthMultiplier = float.Parse(data[2]);
        info.intelligence = int.Parse(data[3]);
        info.experience = int.Parse(data[4]);
        info.health = int.Parse(data[5]);
    }

    public void setStats(int intel, int xp, int health) {
        info.intelligence = intel;
        info.experience = xp;
        info.health = health;

        string[] data = new string[6];
        data[0] = info.intelligenceMultiplier.ToString();
        data[1] = info.experienceMultiplier.ToString();
        data[2] = info.healthMultiplier.ToString();
        data[3] = info.intelligence.ToString();
        data[4] = info.experience.ToString();
        data[5] = info.health.ToString();
        File.WriteAllLines("Assets/Scripts/player.txt", data);
    }

    public void updateStats(float mul, int intel, int xp, int health) {
        info.intelligence += (int)(info.intelligenceMultiplier * mul * intel);
        info.experience += (int)(info.experienceMultiplier * mul * xp);
        info.health += (int)(info.healthMultiplier * mul * health);

        string[] data = new string[6];
        data[0] = info.intelligenceMultiplier.ToString();
        data[1] = info.experienceMultiplier.ToString();
        data[2] = info.healthMultiplier.ToString();
        data[3] = info.intelligence.ToString();
        data[4] = info.experience.ToString();
        data[5] = info.health.ToString();
        File.WriteAllLines("Assets/Scripts/player.txt", data);
    }

    public void setMultipliers(float intel, float xp, float health) {
        info.intelligenceMultiplier = intel;
        info.experienceMultiplier = xp;
        info.healthMultiplier = health;

        string[] data = new string[6];
        data[0] = info.intelligenceMultiplier.ToString();
        data[1] = info.experienceMultiplier.ToString();
        data[2] = info.healthMultiplier.ToString();
        data[3] = info.intelligence.ToString();
        data[4] = info.experience.ToString();
        data[5] = info.health.ToString();
        File.WriteAllLines("Assets/Scripts/player.txt", data);
    }

    public PlayerStatsInfo getStats() {
        return info;
    }
}
