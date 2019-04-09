using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;

    private GameController gameController;


    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
        Object[] o = FindObjectsOfType(typeof(GridSpace));
        List<GridSpace> l = new List<GridSpace>();
        foreach(Object ob in o) {
            GridSpace g = ob as GridSpace;
            if (g.button.interactable)
                l.Add(g);
        }

        if (l.Count <= 0)
            return;

        GridSpace c = l[Random.Range(0, l.Count)];
        c.buttonText.text = gameController.GetPlayerSide();
        c.button.interactable = false;
        gameController.EndTurn();
    }

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }
}
