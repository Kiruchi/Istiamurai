using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GameObject menu;
    public GameObject endGame;
    public Text endGameScore;
    public GameObject scoreWindow;
    public Text score;
    public Text lives;
    public GameObject rayPlane;
    public GameObject emitters;
    public Transform thrownObjects;

    private bool inGame;
    private bool isShowing;

	// Use this for initialization
	void Start () {
        inGame = false;
        isShowing = true;
        menu.SetActive(isShowing);
        scoreWindow.SetActive(!isShowing);
        rayPlane.SetActive(false);
        emitters.SetActive(false);
	}

    public void click_play() {
        inGame = true;
        isShowing = false;
        menu.SetActive(isShowing);
        scoreWindow.SetActive(!isShowing);
        rayPlane.SetActive(true);
        emitters.SetActive(true);
        Time.timeScale = 1;
    }

    public void click_restart()
    {
        GameManager.Instance.Score = 0;
        GameManager.Instance.Lives = 3;
        inGame = true;
        isShowing = false;
        endGame.SetActive(isShowing);
        scoreWindow.SetActive(!isShowing);
        rayPlane.SetActive(true);
        emitters.SetActive(true);
        Time.timeScale = 1;
    }

    public void click_exit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            scoreWindow.SetActive(!isShowing);
            rayPlane.SetActive(!isShowing);
            emitters.SetActive(!isShowing);
            Time.timeScale = (isShowing ? 0 : 1);
        }
    }

    public void updateScore()
    {
        score.text = "Score : " + GameManager.Instance.Score;
    }

    public void updateLives()
    {
        lives.text = "Lives : " + GameManager.Instance.Lives;
        if (GameManager.Instance.Lives == 0)
        {
            for (int i = 0; i < thrownObjects.childCount; i++)
            {
                Destroy(thrownObjects.GetChild(0).gameObject);
            }
            isShowing = true;
            inGame = false;
            menu.SetActive(false);
            scoreWindow.SetActive(false);
            endGame.SetActive(true);
            endGameScore.text = GameManager.Instance.Score.ToString();
            rayPlane.SetActive(false);
            emitters.SetActive(false);
        }
    }

}
