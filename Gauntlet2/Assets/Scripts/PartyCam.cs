using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCam : MonoBehaviour
{
    static public PartyCam S; // Follow cam singleton.

    public GameObject poi; // Point of interest

    public float camY; // Initial Z pos of the camera.

    public float easing = 0.05f;

    public float minZoom;
    public float maxZoom;

    private void Awake()
    {
        S = this;
        camY = this.transform.position.y;
    }

    private void FixedUpdate()
    {
        float totalX = 0f;
        float totalZ = 0f;
        int players = 0;
        //FollowCam.S.poi = this.gameObject;
        foreach (GameObject foundPlayer in FindObjectsOfType(typeof(GameObject)))
        {
            if (foundPlayer.GetComponent<BasePlayer>() != null)
            {
                players++;
                totalX += foundPlayer.transform.position.x;
                totalZ += foundPlayer.transform.position.z;
            }
        }
        print("poi pos = " + (totalX / players) + "," + (totalZ / players));
        Vector3 averagePosition = new Vector3(totalX / players, poi.transform.position.y, totalZ / players);
        poi.transform.position = averagePosition;

        Vector3 destination;
        if (poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = poi.transform.position;
        }

        destination = Vector3.Lerp(transform.position, destination, easing); // Lerp = Linear intERPolation.

        // Retain destination.z of camZ.
        destination.y = camY;

        // Set the camera to the destination.
        transform.position = destination;

        // Set orthographicSize of cam to keep the ground in view.
        //this.GetComponent<Camera>().orthographicSize = destination.y + 10f;

        float breadth = 5f;

        if (players > 1)
        {
            // Keep all players in view?
            List<GameObject> objs = new List<GameObject>();
            foreach (GameObject foundPlayer in FindObjectsOfType(typeof(GameObject)))
            {
                if (foundPlayer.GetComponent<BasePlayer>() != null)
                {
                    objs.Add(foundPlayer);
                }
            }

            if (players == 2)
            {
                breadth = Vector3.Distance(objs[0].transform.position, objs[1].transform.position);
            }
            else
            {
                // get two furthest players

                breadth = Vector3.Distance(objs[0].transform.position, objs[1].transform.position);
                for (int i = 0; i < players; i++)
                {
                    // logic for calculating breadth between 3 or 4 players.
                }

            }


        }
        this.GetComponent<Camera>().orthographicSize = Mathf.Clamp((breadth / players) + 3f, minZoom, maxZoom);


    }
}
