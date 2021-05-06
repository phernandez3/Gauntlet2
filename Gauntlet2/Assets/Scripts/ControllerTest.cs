using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTest : MonoBehaviour
{
    // Player-controller stuff
    public int controllerSlot;
    public bool clickToUpdate;
    private bool isSetUp;

    public string MoveX;
    public string MoveY;
    public string FireX;
    public string FireY;
    public string Bomb;

    public Text MoveXText;
    public Text MoveYText;
    public Text FireXText;
    public Text FireYText;
    public Text BombText;

    public void AssignControllerSlot(int slotNumber)
    {
        MoveX = "MoveX" + slotNumber;
        MoveY = "MoveY" + slotNumber;
        FireX = "FireX" + slotNumber;
        FireY = "FireY" + slotNumber;
        Bomb = "Bomb" + slotNumber;
    }

    private void Update()
    {
        if (clickToUpdate)
        {
            clickToUpdate = false;
            isSetUp = true;
            AssignControllerSlot(controllerSlot);
        }

        if (isSetUp)
        {
            MoveXText.text = MoveX + ":" + Input.GetAxis(MoveX);
            MoveYText.text = MoveY + ":" + Input.GetAxis(MoveY);
            FireXText.text = FireX + ":" + Input.GetAxis(FireX);
            FireYText.text = FireY + ":" + Input.GetAxis(FireY);
            BombText.text = Bomb + ":" + Input.GetAxis(Bomb);
        }
    }

}
