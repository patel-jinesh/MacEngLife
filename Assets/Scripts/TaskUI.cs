using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour {
    public void Start() {
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

    public IEnumerator displayDone() {
        Image i = this.gameObject.GetComponent<Image>();
        i.color = Color.green;
        yield return new WaitForSeconds(1f); // waits 1 seconds
        i.color = Color.white; // will make the update method pick up 
    }

    public IEnumerator displayIncomplete() {
        Image i = this.gameObject.GetComponent<Image>();
        i.color = Color.red;
        yield return new WaitForSeconds(1f); // waits 1 seconds
        i.color = Color.white; // will make the update method pick up 
    }
}
