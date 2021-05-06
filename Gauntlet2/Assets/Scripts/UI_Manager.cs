using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private Text p1_Score_UI;
    private Text p2_Score_UI;
    private Text p3_Score_UI;
    private Text p4_Score_UI;


    void Update_UI()
    {
        p1_Score_UI.text = GameManager.Instance.p1_Score.ToString();
        p2_Score_UI.text = GameManager.Instance.p2_Score.ToString();
        p3_Score_UI.text = GameManager.Instance.p3_Score.ToString();
        p4_Score_UI.text = GameManager.Instance.p4_Score.ToString();
    }
}
