using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocation : MonoBehaviour

{
    public int x = 0;
    public int y = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, -10);
        
    }

    // Update is called once per frame
    void Update()
    {
        var playerRoom = GameState.Player.CurrentRoom;
        //Debug.Log(playerRoom.ToString());

        switch (playerRoom)
        {
            case GameRooms.Lobby:
                x = 0;
                y = 1;
                //transform.position = new Vector3(0, 1, -10);
                break;
            case GameRooms.Room1:
                x = 0;
                y = 10;
                //transform.position = new Vector3(0, 10, -10);
                break;
            case GameRooms.Lobby2:
                x = 0;
                y = (int)-6.38;

                break;
            case GameRooms.Room1_2:
                
                x = -24;
                y = 10;
                break;
            case GameRooms.Room2:
                x = 0;
                y = (int)18.34;

                break;
        }

        transform.position = new Vector3(x, y, -10);

    }
}
