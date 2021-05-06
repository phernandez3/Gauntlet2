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


    [SerializeField] private GameState myGameState;
    private UI_Manager myUI;
    //private AudioManager myAudio;

    // Determine what players are in play. If the play is not in play remove references to their UI/system.
    private bool p1_isPlaying;
    private bool p2_isPlaying;
    private bool p3_isPlaying;
    private bool p4_isPlaying;

    public int p1_Score;
    public int p2_Score;
    public int p3_Score;
    public int p4_Score;


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
