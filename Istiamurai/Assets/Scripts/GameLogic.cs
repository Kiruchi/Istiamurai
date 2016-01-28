using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GameObject menu;
    public Text score;
    public GameObject rayPlane;
    public GameObject emitters;

    private bool inGame;
    private bool isShowing;

	// Use this for initialization
	void Start () {
        inGame = false;
        isShowing = true;
        menu.SetActive(isShowing);
        score.gameObject.SetActive(!isShowing);
        rayPlane.SetActive(false);
        emitters.SetActive(false);
	}

    public void click_play() {
        Debug.Log("Click play");
        inGame = true;
        isShowing = false;
        menu.SetActive(isShowing);
        score.gameObject.SetActive(!isShowing);
        rayPlane.SetActive(true);
        emitters.SetActive(true);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            score.gameObject.SetActive(!isShowing);
            rayPlane.SetActive(!isShowing);
            emitters.SetActive(!isShowing);
            Time.timeScale = (isShowing ? 0 : 1);
        }
    }

    public void updateScore()
    {
        score.text = "Score : " + GameManager.Instance.Score;
    }

}
