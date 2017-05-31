using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyLevel : MonoBehaviour {

    public GameObject[] floorTiles;
    public GameObject wallTile;
    public GameObject doorTile;
	public GameObject lurkerTile;
    public GameObject playerObject;
    private Transform boardHolder;
    public static int board_x = 3, board_y = 3;
    public int player_x = 1, player_y = 1;
    public int door_x = 2, door_y = 2;
    public float tileSize = 0.64f;
    public bool doorOpen = false;

    float getLeftBound()
    {
        return - (board_x - 1) / 2f * tileSize;
    }

    float getRightBound()
    {
        return (board_x - 1) / 2f * tileSize;
    }

    float getUpperBound()
    {
        return (board_y - 1) / 2f * tileSize;
    }

    float getLowerBound()
    {
        return - (board_y - 1) / 2f * tileSize;
    }

    // Use this for initialization
    void Start () {
        // Pave floors
        float left = getLeftBound();
        float right = getRightBound();
        float top = getUpperBound();
        float bottom = getLowerBound();

        int width = (int) ((right - left) / tileSize) + 1;
        int height = (int) ((top - bottom) / tileSize) + 1;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                float pos_x = left + j * tileSize;
                float pos_y = bottom + i * tileSize;
                
                if ((i + j) % 2 != 0)
                {
                    GameObject newFloor = Instantiate(floorTiles[1], new Vector3(pos_x, pos_y, 0f), Quaternion.identity, boardHolder);
                }
                else
                {
                    GameObject newFloor = Instantiate(floorTiles[0], new Vector3(pos_x, pos_y, 0f), Quaternion.identity, boardHolder);
                }

            }
        }

        // Build walls
        float leftWall = left - tileSize;
        float rightWall = right + tileSize;
        float topWall = top + tileSize;
        float bottomWall = bottom - tileSize;

        for (int i=0; i < height + 1; i++)
        {
            // Build left wall
            GameObject newWall = Instantiate(wallTile, new Vector3(leftWall, bottomWall + i * tileSize, 0f), 
                Quaternion.identity, boardHolder);
        }
        for (int i=0; i < width + 1; i++)
        {
            GameObject newWall = Instantiate(wallTile, new Vector3(leftWall + i * tileSize, topWall, 0f), 
                Quaternion.identity, boardHolder);
        }
        for (int i=1; i < height + 2; i++)
        {
            GameObject newWall = Instantiate(wallTile, new Vector3(rightWall, bottomWall + i * tileSize, 0f), 
                Quaternion.identity, boardHolder);
        }
        for (int i=1; i < width + 2; i++)
        {
            GameObject newWall = Instantiate(wallTile, new Vector3(leftWall + i * tileSize, bottomWall, 0f), 
                Quaternion.identity, boardHolder);
        }
        // Trap the player in it
        GameObject player = Instantiate(playerObject, new Vector3(getLeftBound() + player_x * tileSize, 
            getLowerBound() + player_y * tileSize, 0f), Quaternion.identity, boardHolder);
	    
		// Create lurker
		GameObject lurker = Instantiate(lurkerTile, new Vector3(getLeftBound() + lurker_x * tileSize, getUpperBound() + lurker_y * tileSize, 0f), Quaternion.identity, boardHolder);
	    
        print(player_x);
        print(player_y);
        print(getLeftBound() + player_x * tileSize);
        print(getLowerBound() + player_y * tileSize);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
