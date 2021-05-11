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

    private Image p1_HP_UI;
    private Image p2_HP_UI;
    private Image p3_HP_UI;
    private Image p4_HP_UI;

    private Image p1_item_UI;
    private Image p2_item_UI;
    private Image p3_item_UI;
    private Image p4_item_UI;

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
    }
    public void TurnOffUI()
    {
        announcement_UI.enabled = false;
    }
    void Update_Announcement()
    {

    }

    void Update_Roster()
    {

    }
    void Update_Score()
    {

        p1_score_UI.text = GameManager.Instance.p1_score.ToString();
        p2_score_UI.text = GameManager.Instance.p2_score.ToString();
        p3_score_UI.text = GameManager.Instance.p3_score.ToString();
        p4_score_UI.text = GameManager.Instance.p4_score.ToString();
    }

    void Update_HP()
    {
        
    }

    void Update_Item()
    {

    }
}
