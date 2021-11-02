using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorBaseMovement : MonoBehaviour
{

    bool isAtDoor = false;
    public bool ShowBox = false;
    public int JanitorTextForward = 0;

    /// <summary>
    /// talking to player for different scenarios
    /// 1 = before teacher room 2
    /// </summary>
    public int talkingToPlayer = 0;
    public string janitorText = "";
    public GameObject Chalkboard;
    public int forwardtext = 0;
    public int forwardPlayerText = 1;

    public GameObject Player;
    private bool enter;

    // Start is called before the first frame update
    void Start()
    {
        


    }
    
    void OnGUI()
    {
        if (ShowBox)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            GUI.Box(new Rect(screenPos.x - 200, Screen.height - screenPos.y, 350, 50), janitorText);
        }
    }

    IEnumerator Your_Timer()
    {
        Debug.Log("Your enter Coroutine at" + Time.time);

        forwardtext = 0;
        enter = true;
        while (enter == true)
        {
            switch (forwardtext)
            {
                
                case 0:

                    janitorText = "sure, let me look at that";
                    forwardtext = 1;
                    break;
                case 1:
                    yield return new WaitForSeconds(0.5f);
                    transform.localPosition = new Vector3(4.64f, 19.27f, 0);
                    forwardtext = 2;
                    break;
                case 2:
                    yield return new WaitForSeconds(0.5f);
                    janitorText = "All fixed";
                    Chalkboard.transform.localRotation = new Quaternion(0f, 0f, 0f, 45);
                    forwardtext = 3;
                    break;
                case 3:
                    yield return new WaitForSeconds(0.5f);
                    janitorText = "I have to go work on the water fountain";
                    forwardtext = 4;
                    break;
                case 4:
                    yield return new WaitForSeconds(1f);
                    janitorText = "Goodbye";
                    forwardtext = 5;
                    break;
                case 5:
                    yield return new WaitForSeconds(0.5f);
                    GameState.Player.StoryLine = storyline.janitorDoneRepair;
                    Debug.Log("end");
                    forwardtext = 6;
                    
                    
                    break;
                default:
                    enter = false;

                    break;

            }
        }
    }
    // Update is called once per frame  
    void Update()
    {
        ///Janitor Following Player
        ///simple
        var playerDirection = GameState.Player.CurrentDirection;
        var JanitorFollow = GameState.Player.JanitorFollow;
        GameState.Player.Position = new float[] { this.transform.position.x, this.transform.position.y, 0 };
        switch (JanitorFollow)
        {
            
            case Janitor.yes:
                switch (GameState.Player.CurrentDirection)
                {
                    case CharacterDirection.Down:
                        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.5f);

                        //this.transform.position = Player.transform.position;

                        break;
                    case CharacterDirection.Up:
                        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 1.8f);
                        //transform.position = new Vector3(0, 10, -10);
                        break;
                    case CharacterDirection.Left:
                        this.transform.position = new Vector3(Player.transform.position.x + 1.5f, Player.transform.position.y);

                        //this.transform.position = Player.transform.position;

                        break;
                    case CharacterDirection.Right:
                        this.transform.position = new Vector3(Player.transform.position.x - 1.5f, Player.transform.position.y);
                        //transform.position = new Vector3(0, 10, -10);
                        break;
                    default:
                        //this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y);
                        break;
                }
                break;
        }

        if (GameState.Player.StoryLine == storyline.janitorRepair)
        {
            ShowBox = true;
            
            if (enter == false)
            {
                StartCoroutine(Your_Timer());
            }
                
            
        }
        else if(GameState.Player.StoryLine == storyline.janitorDoneRepair)
        {
            this.transform.position = new Vector3(200, 200, 0);
        }

        if (talkingToPlayer == 1)
        {
            
            if (Input.GetKeyDown("f"))
            {
                switch (forwardPlayerText)
                {
                    case 0:
                        janitorText = "no-one should see this";
                        Debug.LogError(janitorText);
                        break;
                    case 1:
                        janitorText = "Can I help you?"; 
                        Debug.Log(janitorText);
                        forwardPlayerText = 2;
                        break;
                    case 2:
                        janitorText = "Oh the teacher needs me?";
                        forwardPlayerText = 3;
                        break;
                    case 3:
                        janitorText = "Lead the way";
                        GameState.Player.JanitorFollow = Janitor.yes;
                        ShowBox = false;
                        forwardPlayerText = 4;
                        break;
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        Debug.Log("NPC hitting " + collision.gameObject.tag);
        if (isAtDoor)
            return;

        //What is the NPC hitting??
        switch (collision.gameObject.name)
        {

            case "TeacherSprite":
                Debug.Log("wait for teacher");

                break;

            case "Adam":
                switch (GameState.Player.StoryLine)
                {
                    //Beginning of the game
                    //Janitor brought to repair
                    //chalkboard
                    case storyline.Janitor:
                        ShowBox = true;
                        forwardtext = 1;
                        talkingToPlayer = 1;

                        ///still need this
                        ///GameState.Player.JanitorFollow = Janitor.yes;

                        break;
                }


                break;


                ///none of this is actually used in game
                ///just don't want to delete it in case
                ///it breaks something
            case "doorLobbyRoom1":
                //isAtDoor = true; //set the bool checking if Janitor is at a door

                transform.position = new Vector3((float)-1.48, (float)8.31, 0); //set Janitor location
                GameState.Player.JanitorCurrentRoom = GameRooms.Room1; //set current room of Janitor

                break;

            case "doorRoom1Lobby":
                isAtDoor = true;

                transform.position = new Vector3((float)-1.48, (float)2.42, 0);

                GameState.Player.JanitorCurrentRoom = GameRooms.Lobby;

                break;

            case "doorRoom2Room1":
                isAtDoor = true;

                transform.position = new Vector3((float)4.54, (float)10.33, 0);

                GameState.Player.JanitorCurrentRoom = GameRooms.Room1;
                break;


            case "bookshelf4":
                //isAtDoor = true;

                //transform.position = new Vector3((float)-1.48, (float)2.42, 0);
                GameState.Player.JanitorCurrentRoom = GameRooms.Lobby2;
                break;

            case "Collision Library camera":
                //isAtDoor = true;

                //transform.position = new Vector3((float)-1.48, (float)2.42, 0);
                GameState.Player.JanitorCurrentRoom = GameRooms.Lobby;
                break;

            case "doorRoom1Room2":

                isAtDoor = true;

                transform.position = new Vector3((float)4.54, (float)16.18, 0);
                GameState.Player.JanitorCurrentRoom = GameRooms.Room2;



                break;

            case "TriggerHallway2":

                isAtDoor = true;

                transform.position = new Vector3((float)-17.4, (float)10.3, 0);
                GameState.Player.JanitorCurrentRoom = GameRooms.Room1_2;

                break;
            case "TriggerHallway1":

                isAtDoor = true;

                transform.position = new Vector3((float)-6.5, (float)10.3, 0);
                GameState.Player.JanitorCurrentRoom = GameRooms.Room1;

                break;
            case "libraryDesk1":



                break;


        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShowBox = false;
    }
}
