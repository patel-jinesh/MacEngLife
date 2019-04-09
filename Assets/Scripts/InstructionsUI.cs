using UnityEngine;
using System.Collections;

public class InstructionsUI : MonoBehaviour {
    // Use this for initialization
    void Start() {
        this.gameObject.SetActive(false);
    }

    public void close() {
        this.gameObject.SetActive(false);
        OnClose?.Invoke();
    }

    public void display() {
        this.gameObject.SetActive(true);
    }

    public delegate void GUI();
    public event GUI OnClose;
}
