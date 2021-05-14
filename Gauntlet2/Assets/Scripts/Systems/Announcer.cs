using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    public enum AnnouncementType {lowHealth, shotFood, shotPlayer, highScore};

    public string announcementText;

    public bool announcing;

    public int announcementPriority;
    public float announcementLength;
    public float announcementDelayTimer;

    
    public int announcementPlayer;

    public string announcementClass;

    public void StartPlayerAnnouncement(AnnouncementType myAnnouncement, BasePlayer subject)
    {

        if (announcing)
        {
            return;
        }
        else
        {
            
            announcementPlayer = subject.controllerSlot;
            Debug.Log("I am player_" + subject.controllerSlot);
            announcementClass = subject.myClass;
            Debug.Log("I am a_" + subject.myClass);

            switch (myAnnouncement)
            {
                case (AnnouncementType.lowHealth):
                    StartCoroutine(LowHealth());

                    break;
                case (AnnouncementType.shotFood):
                    StartCoroutine(ShotFood());
                    break;
                case (AnnouncementType.shotPlayer):
                    StartCoroutine(ShotPlayer());
                    break;
                case (AnnouncementType.highScore):
                    StartCoroutine(HighScore());
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator LowHealth()
    {
        announcing = true;
        GameManager.Instance.myAudio.Play("Player_" + announcementPlayer);
        announcementLength = 1f;
        yield return new WaitForSeconds(announcementLength);

        GameManager.Instance.myAudio.Play("Player_" + announcementClass);
        announcementLength = 1f;
        yield return new WaitForSeconds(announcementLength);

        int randomChance = Random.Range(1, 4);
        Debug.Log(randomChance);
        GameManager.Instance.myAudio.Play("LowHealth_" + randomChance);
        announcementLength = 2f;
        yield return new WaitForSeconds(announcementLength);

        announcing = false;
    }
    IEnumerator ShotFood()
    {
        announcing = true;
        GameManager.Instance.myAudio.Play("Player_" + announcementPlayer);
        announcementLength = 1f;
        yield return new WaitForSeconds(announcementLength);

        GameManager.Instance.myAudio.Play("Player_" + announcementClass);
        announcementLength = 1f;
        yield return new WaitForSeconds(announcementLength);

        GameManager.Instance.myAudio.Play("Shoot_Food");
        announcementLength = 1.5f;
        yield return new WaitForSeconds(announcementLength);
        announcing = false;
    }

    IEnumerator ShotPlayer()
    {
        announcing = true;
        GameManager.Instance.myAudio.Play("Shoot_Player");
        announcementLength = 1.5f;
        yield return new WaitForSeconds(announcementLength);
        announcing = false;
    }

    IEnumerator HighScore()
    {
        announcing = true;
        GameManager.Instance.myAudio.Play("High_Score");
        announcementLength = 1.5f;
        yield return new WaitForSeconds(announcementLength);
        announcing = false;
    }

}
