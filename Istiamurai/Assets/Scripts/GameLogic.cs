using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GameObject menu;
    public GameObject score;
    private bool inGame;
    private bool isShowing;

	// Use this for initialization
	void Start () {
        inGame = false;
        isShowing = true;
        menu.SetActive(isShowing);
        score.SetActive(!isShowing);
	}

    void click_play() {
        Debug.Log("Click play");
        inGame = true;
        isShowing = false;
        menu.SetActive(isShowing);
        score.SetActive(!isShowing);
        // Play
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            score.SetActive(!isShowing);
        }
    }
}
