using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpawnFood : MonoBehaviour {
 
    public GameObject foodPrefab;

  
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;


    void Start () {
        foodPrefab.SetActive(false);
        InvokeRepeating("Spawn", 3, 4);
    }


    void Spawn() {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);
        
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity).SetActive(true); 
    }
}