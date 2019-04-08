using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour {
    public OverworldController ovc;
    public CharacterSelectionUI ui;
    public CharacterInfo ci;
    public GameObject tmpltCharacter;

    // Start is called before the first frame update
    void Start() {
        ui.OnCharacterChosen += chooseCharacter;
        tmpltCharacter.SetActive(false);

        ci = new CharacterInfo();
        GameObject cl = GameObject.Find("CharacterList");

        for (int idx = 0; idx < ci.getAll().Count; idx++) {
            int index = idx;
            Model model = ci.getModel(idx);
            GameObject go = Instantiate(tmpltCharacter) as GameObject;
            go.SetActive(true);
            Text[] t = go.GetComponentsInChildren<Text>();
            Image[] i = go.GetComponentsInChildren<Image>();
            t[0].text = model.name;
            t[1].text = model.description + "\n" + model.experienceMultiplier.ToString() + "\n" + model.intelligenceMultiplier.ToString() + "\n" + model.healthMultiplier.ToString() + "\n" + model.baseExperience.ToString() + "\n" + model.baseIntelligence.ToString() + "\n" + model.baseHealth.ToString();
            Texture2D tex = Resources.Load<Texture2D>("CharacterImages/" + model.name) as Texture2D;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 32, 64), new Vector2(0.5f, 0.5f));
            i[1].sprite = sprite;
            go.transform.SetParent(tmpltCharacter.transform.parent);
            go.GetComponent<Button>().enabled = true;
            go.GetComponent<Button>().onClick.AddListener(() => ui.Select(index));
        }
    }

    public void chooseCharacter(int id) {
        Model m = ci.getModel(id);
        ovc.setStats(m.baseExperience, m.baseIntelligence, m.baseHealth);
        ovc.setMultipliers(m.experienceMultiplier, m.intelligenceMultiplier, m.healthMultiplier);
        Debug.Log("Copie");
        File.WriteAllBytes("Assets/Resources/CharacterImages/player.png",File.ReadAllBytes("Assets/Resources/CharacterImages/" + m.name + ".png"));
        Texture2D tex = Resources.Load<Texture2D>("CharacterImages/" + m.name) as Texture2D;
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 32, 64), new Vector2(0.5f, 0.5f));
        ovc.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        OnClose?.Invoke();
    }

    public void display() {
        ui.display();
    }

    public delegate void GUI();
    public event GUI OnClose;
}
