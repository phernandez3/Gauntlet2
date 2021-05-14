using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private Text announcement_UI;

    private Text p1_isPlaying_UI;
    private Text p2_isPlaying_UI;
    private Text p3_isPlaying_UI;
    private Text p4_isPlaying_UI;

    private Text p1_score_UI;
    private Text p2_score_UI;
    private Text p3_score_UI;
    private Text p4_score_UI;

    private Text p1_HP_UI;
    private Text p2_HP_UI;
    private Text p3_HP_UI;
    private Text p4_HP_UI;

    private Text wizard_UI;
    private Text warrior_UI;
    private Text valkyrie_UI;
    private Text elf_UI;

    private Text p1_bombs_UI;
    private Text p2_bombs_UI;
    private Text p3_bombs_UI;
    private Text p4_bombs_UI;

    private Text p1_keys_UI;
    private Text p2_keys_UI;
    private Text p3_keys_UI;
    private Text p4_keys_UI;

    private List<Image> p1_item_Images = new List<Image>();
    private List<Image> p2_item_Images = new List<Image>();
    private List<Image> p3_item_Images = new List<Image>();
    private List<Image> p4_item_Images = new List<Image>();


    public void Awake()
    {
        p1_isPlaying_UI = GameObject.Find("p1_isPlaying").GetComponent<Text>();
        p2_isPlaying_UI = GameObject.Find("p2_isPlaying").GetComponent<Text>();
        p3_isPlaying_UI = GameObject.Find("p3_isPlaying").GetComponent<Text>();
        p4_isPlaying_UI = GameObject.Find("p4_isPlaying").GetComponent<Text>();

        p1_score_UI = GameObject.Find("p1_score#").GetComponent<Text>();
        p2_score_UI = GameObject.Find("p2_score#").GetComponent<Text>();
        p3_score_UI = GameObject.Find("p3_score#").GetComponent<Text>();
        p4_score_UI = GameObject.Find("p4_score#").GetComponent<Text>();

        p1_HP_UI = GameObject.Find("p1_HP#").GetComponent<Text>();
        p2_HP_UI = GameObject.Find("p2_HP#").GetComponent<Text>();
        p3_HP_UI = GameObject.Find("p3_HP#").GetComponent<Text>();
        p4_HP_UI = GameObject.Find("p4_HP#").GetComponent<Text>();

        
    }
    public void TurnOffGameUI()
    {

        p1_score_UI.enabled = false;
        p2_score_UI.enabled = false;
        p3_score_UI.enabled = false;
        p4_score_UI.enabled = false;

        p1_HP_UI.enabled = false;
        p2_HP_UI.enabled = false;
        p3_HP_UI.enabled = false;
        p4_HP_UI.enabled = false;
    }

    public void TurnOnGameUI()
    {
        announcement_UI.enabled = true;
    }

    void Update_Announcement()
    {

    }

    void Update_Roster()
    {
        if (GameManager.Instance.myPlayers[0].isPlaying)
        {
            p1_isPlaying_UI.enabled = false;
        }
        else
        {
            p1_isPlaying_UI.enabled = true;
        }

        if (GameManager.Instance.myPlayers[1].isPlaying)
        {
            p2_isPlaying_UI.enabled = false;
        }
        else
        {
            p2_isPlaying_UI.enabled = true;
        }

        if (GameManager.Instance.myPlayers[2].isPlaying)
        {
            p3_isPlaying_UI.enabled = false;
        }
        else
        {
            p3_isPlaying_UI.enabled = true;
        }

        if (GameManager.Instance.myPlayers[3].isPlaying)
        {
            p4_isPlaying_UI.enabled = false;
        }
        else
        {
            p4_isPlaying_UI.enabled = true;
        }
    }
    void Update_Score()
    {

        p1_score_UI.text = "Score: " + GameManager.Instance.myPlayers[0].score.ToString();
        p2_score_UI.text = "Score: " + GameManager.Instance.myPlayers[1].score.ToString();
        p3_score_UI.text = "Score: " + GameManager.Instance.myPlayers[2].score.ToString();
        p4_score_UI.text = "Score: " + GameManager.Instance.myPlayers[3].score.ToString();
    }

    void Update_HP()
    {
        p1_HP_UI.text = "HP: " + GameManager.Instance.myPlayers[0].healthPoints.ToString();
        p2_HP_UI.text = "HP: " + GameManager.Instance.myPlayers[1].healthPoints.ToString();
        p3_HP_UI.text = "HP: " + GameManager.Instance.myPlayers[2].healthPoints.ToString();
        p4_HP_UI.text = "HP: " + GameManager.Instance.myPlayers[3].healthPoints.ToString();
    }

    void Update_Items()
    {
        p1_bombs_UI.text = GameManager.Instance.myPlayers[0].bombs.ToString();

        p2_bombs_UI.text = GameManager.Instance.myPlayers[1].bombs.ToString();
        p3_bombs_UI.text = GameManager.Instance.myPlayers[2].bombs.ToString();
        p4_bombs_UI.text = GameManager.Instance.myPlayers[3].bombs.ToString();

        

        p1_keys_UI.text = GameManager.Instance.myPlayers[0].keys.ToString();
        p2_keys_UI.text = GameManager.Instance.myPlayers[1].keys.ToString();
        p3_keys_UI.text = GameManager.Instance.myPlayers[2].keys.ToString();
        p4_keys_UI.text = GameManager.Instance.myPlayers[3].keys.ToString();
    }

    void ClassSelectUI()
    {

    }
}
