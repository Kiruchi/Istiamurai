using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = (value > 0 ? value : 0);
            gameLogic.updateScore();
        }
    }

    private int lives = 3;
    public int Lives
    {
        get { return lives; }
        set
        {
            lives = (value > 0 ? value : 0);
            gameLogic.updateLives();
        }
    }

    public GameLogic gameLogic;

    void Awake()
    {
        _instance = this;
    }

}
