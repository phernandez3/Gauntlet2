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

    private Image p1_items_UI;
    private Image p2_items_UI;
    private Image p3_items_UI;
    private Image p4_items_UI;

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
    public void TurnOffUI()
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

    public void TurnOnUI()
    {
        announcement_UI.enabled = true;
    }

    void Update_Announcement()
    {

    }

    void Update_Roster()
    {
        if (GameManager.Instance.p1_isPlaying)
        {
            p1_isPlaying_UI.enabled = false;
        }
        else
        {
            p1_isPlaying_UI.enabled = true;
        }

        if (GameManager.Instance.p2_isPlaying)
        {
            p2_isPlaying_UI.enabled = false;
        }
        else
        {
            p2_isPlaying_UI.enabled = true;
        }

        if (GameManager.Instance.p3_isPlaying)
        {
            p3_isPlaying_UI.enabled = false;
        }
        else
        {
            p3_isPlaying_UI.enabled = true;
        }

        if (GameManager.Instance.p4_isPlaying)
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
