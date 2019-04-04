using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour {
    private int index;

    public CharacterSelectionUI() {
        index = -1;
    } 

    public void Start() {
        //this.gameObject.SetActive(false);
    }

    public void close() {
        this.gameObject.SetActive(false);
        OnCharacterChosen?.Invoke(index);
    }

    public void display() {
        this.gameObject.SetActive(true);
    }

    public void Select(int index) {
        this.index = index;
        GameObject cl = GameObject.Find("CharacterList");

        Texture2D texregular = Resources.Load<Texture2D>("Controls/itemvert") as Texture2D;
        Texture2D texselected = Resources.Load<Texture2D>("Controls/itemvertsel") as Texture2D;
        Sprite regular = Sprite.Create(texregular, new Rect(0, 0, 154, 404), new Vector2(0.5f, 0.5f));
        Sprite selected = Sprite.Create(texselected, new Rect(0, 0, 154, 404), new Vector2(0.5f, 0.5f));
        

        foreach (Button b in cl.GetComponentsInChildren<Button>())
            b.image.sprite = regular;

        cl.GetComponentsInChildren<Button>()[index].image.sprite = selected;
    }

    public delegate void CharacterChosen(int id);
    public event CharacterChosen OnCharacterChosen;
}
