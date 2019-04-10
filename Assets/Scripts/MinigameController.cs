using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour {
    public char result = '\0';
    private Scene s;

    public void SetResult(char r) {
        this.result = r;
        _ = SceneManager.UnloadSceneAsync(s.buildIndex);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Overworld"));
        OnClose?.Invoke();
    }

    public void playMinigame(Task t) {
        if (t.difficulty == 1) {
            SceneManager.LoadScene("TicTacToe", LoadSceneMode.Additive);
            s = SceneManager.GetSceneByName("TicTacToe");
        } else if (t.difficulty == 2) {
            AsyncOperation a = SceneManager.LoadSceneAsync("Snake", LoadSceneMode.Additive);
            s = SceneManager.GetSceneByName("Snake");
            a.completed += (obj) => SceneManager.SetActiveScene(s);
        } else {
            SceneManager.LoadScene("Pong", LoadSceneMode.Additive);
            s = SceneManager.GetSceneByName("Pong");
        }
    }

    public delegate void GUI();
    public event GUI OnClose;
}
