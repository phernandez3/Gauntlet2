using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { menu, createLevel, gameplay, pause, gameOver}

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
    public UI_Manager myUI;
    //private AudioManager myAudio;

    // Determine what players are in play. If the play is not in play remove references to their UI/system.
    public bool p1_isPlaying;
    public bool p2_isPlaying;
    public bool p3_isPlaying;
    public bool p4_isPlaying;

    public int p1_score;
    public int p2_score;
    public int p3_score;
    public int p4_score;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
