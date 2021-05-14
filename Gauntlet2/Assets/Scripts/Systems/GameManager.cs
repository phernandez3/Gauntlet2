using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {menu, createLevel, gameplay, pause, gameOver}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }


    public GameState myGameState;

    public List<BasePlayer> myPlayers = new List<BasePlayer>();

    public UI_Manager myUI;
    public Announcer myAnnouncer;
    public Audio_Manager myAudio;

   
    // Determine what players are in play. If the play is not in play remove references to their UI/system.

    public int total_score;
    public int high_score;


    public int currentLevel;
    public List<GameObject> levelGeometry = new List<GameObject>();



    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        myGameState = GameState.menu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (myGameState)
        {
            case GameState.menu:
                myUI.TurnOffGameUI();

                break;
            case GameState.createLevel:
                break;
            case GameState.gameplay:
                break;
            case GameState.pause:
                break;
            case GameState.gameOver:
                break;
            default:
                break;
        }
    }
}
