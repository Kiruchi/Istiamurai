using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GameObject menu;
    public GameObject score;
    public GameObject rayPlane;
    public GameObject emitters;

    private bool inGame;
    private bool isShowing;

	// Use this for initialization
	void Start () {
        inGame = false;
        isShowing = true;
        menu.SetActive(isShowing);
        score.SetActive(!isShowing);
        rayPlane.SetActive(false);
        emitters.SetActive(false);
	}

    public void click_play() {
        Debug.Log("Click play");
        inGame = true;
        isShowing = false;
        menu.SetActive(isShowing);
        score.SetActive(!isShowing);
        rayPlane.SetActive(true);
        emitters.SetActive(true);
        // Play
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            score.SetActive(!isShowing);
            rayPlane.SetActive(!isShowing);
            emitters.SetActive(!isShowing);
        }
    }


}
