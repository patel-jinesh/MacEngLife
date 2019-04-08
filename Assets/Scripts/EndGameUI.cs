using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
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
}
