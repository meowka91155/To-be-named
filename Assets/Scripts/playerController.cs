using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets;
using Assets.Objects;

public class playerController : MonoBehaviour
{


    public playerController()
    {

    }



    public float movementSpeed = 4f;

    public Rigidbody2D rb;
    public Animator animator;
    bool isAtDoor = false;
    public string playerText = "";
    public bool ShowBox = false;
    //public GameObject bookUI;
    //public GameObject bookTable1;
    //public GameObject bookTable2;
    //public storyline story =  storyline.Book;

    public PlayerInventoryObject Inventory { get { return GameState.Player.Inventory; } }

    Vector2 movement;


    void Start()
    {
        ///Comment this out on build
        Debug.Log("Testing Only");
        if (!GameState.Characters.ContainsKey(CharacterKeys.Player))
            GameState.Player = new Player("Adam", "Adam");
        ///

        Inventory.inventoryUI = GameObject.FindObjectOfType<UIInventory>();

        //bookUI.gameObject.SetActive(false);
        //bookTable1.gameObject.SetActive(true);
        //bookTable2.gameObject.SetActive(false);


    }

    // Update is called once per frame

    void OnGUI()
    {
        if (ShowBox)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            GUI.Box(new Rect(screenPos.x, Screen.height - screenPos.y, 300, 50), playerText);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        Debug.Log("Player hitting " + collision.gameObject.tag);
        if (isAtDoor)
            return;

        //What is the player hitting??
        switch (collision.gameObject.name)
        {



            case "doorLobbyRoom1":
                isAtDoor = true; //set the bool checking if player is at a door
                //Camera.current.transform.position = new Vector3(0, 10, -10); //set camera location
                transform.position = new Vector3((float)-1.48, (float)8.31, 0); //set player location
                GameState.Player.CurrentRoom = GameRooms.Room1; //set current room of player

                break;

            case "doorRoom1Lobby":
                isAtDoor = true;
                //Camera.current.transform.position = new Vector3(0, 1, -10);
                transform.position = new Vector3((float)-1.48, (float)2.42, 0);

                GameState.Player.CurrentRoom = GameRooms.Lobby;

                break;

            case "doorRoom2Room1":
                isAtDoor = true;
                //Camera.current.transform.position = new Vector3(0, (float)10, -10);
                transform.position = new Vector3((float)4.54, (float)10.33, 0);

                GameState.Player.CurrentRoom = GameRooms.Room1;
                break;


            case "bookshelf4":
                //isAtDoor = true;
                //Camera.current.transform.position = new Vector3(0, (float)-6.38, -10);
                //transform.position = new Vector3((float)-1.48, (float)2.42, 0);
                GameState.Player.CurrentRoom = GameRooms.Lobby2;
                break;

            case "Collision Library camera":
                //isAtDoor = true;
                //Camera.current.transform.position = new Vector3(0, (float)1, -10);
                //transform.position = new Vector3((float)-1.48, (float)2.42, 0);
                GameState.Player.CurrentRoom = GameRooms.Lobby;
                break;

            case "doorRoom1Room2":

                isAtDoor = true;
                //Camera.current.transform.position = new Vector3(0, (float)18.34, -10);
                transform.position = new Vector3((float)4.54, (float)16.18, 0);
                GameState.Player.CurrentRoom = GameRooms.Room2;



                break;

            case "TriggerHallway2":

                isAtDoor = true;
                //Camera.current.transform.position = new Vector3(-24, 10, -10);
                transform.position = new Vector3((float)-17.4, (float)10.3, 0);
                GameState.Player.CurrentRoom = GameRooms.Room1_2;

                break;
            case "TriggerHallway1":

                isAtDoor = true;
                //Camera.current.transform.position = new Vector3(0, 10, -10);
                transform.position = new Vector3((float)-6.5, (float)10.3, 0);
                GameState.Player.CurrentRoom = GameRooms.Room1;

                break;
            case "libraryDesk1":
                //if (!Settings.triggersActivated.Contains(GameRoomsTriggers.Book1Library))
                //    Settings.triggersActive.Add(GameRoomsTriggers.Book1Library);


                break;

            case "TeacherSprite":
                Debug.Log("wait for teacher");
                if (GameState.Player.JanitorFollow == Janitor.yes)
                {
                    GameState.Player.StoryLine = storyline.currentlyAfterJanitor;
                    GameState.Player.JanitorFollow = Janitor.no;
                }

                break;
            case "Janitor":
                if (GameState.Player.StoryLine == storyline.Janitor)
                {
                    //GameState.Player.JanitorFollow = Janitor.yes;
                }
                break;

        }


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "doorLobbyRoom1":
            case "doorRoom1Lobby":
            case "doorRoom2Room1":
            case "doorRoom1Room2":
            case "TriggerHallway2":
            case "TriggerHallway1":
                isAtDoor = false;
                break;

            case "libraryDesk1":
                ShowBox = false;

                break;
            case "libraryDesk2":

                break;

            case "bookshelf4":
            case "Collision Library camera":
                break;
        }

    }


    void Update()
    {



        if (Input.GetKeyDown("f"))
        {
            if (GameState.Player.CurrentRoom == GameRooms.Lobby)
            {
                var io1 = (Desk)GameState.InteractableObjects[InteractableObjectKeys.Desk01];
                var io2 = (Desk)GameState.InteractableObjects[InteractableObjectKeys.Desk02];
                var desk1d = Vector2.Distance(io1.GameObject.transform.position, transform.position);
                var desk2d = Vector2.Distance(io2.GameObject.transform.position, transform.position);

                Debug.Log($"You're {desk1d} away from Desk1 and {desk2d} away from desk2");


                if (desk1d < 1)
                {
                    if (io1.Count > 0)
                    {
                        ShowBox = true;
                        playerText = "ooh a book";
                        //bookUI.SetActive(true);
                        Debug.Log("taking books from desk 1");
                        foreach (var item in io1.ItemList)
                        {
                            GameState.Player.Inventory.TakeItem(item, io1);
                            //item.GameObject.SetActive(false);
                        }
                    }
                    else if (GameState.Player.Inventory.Count > 0)
                    {
                        ShowBox = true;
                        //bookUI.SetActive(false);
                        //bookTable1.SetActive(true);
                        playerText = "I'm gonna put this book here";
                        Debug.Log("putting books in desk 1");
                        foreach (var item in GameState.Player.Inventory.ItemList)
                            io1.TakeItem(item, GameState.Player.Inventory);
                    }
                }
                else if (desk2d < 1.6)
                {
                    if (io2.Count > 0)
                    {
                        Debug.Log("taking books from desk 2");
                        //bookUI.SetActive(true);
                        //bookTable2.SetActive(false);
                        foreach (var item in io2.ItemList)
                            GameState.Player.Inventory.TakeItem(item, io2);
                    }
                    else if (GameState.Player.Inventory.Count > 0)
                    {
                        Debug.Log("putting books in desk 2");
                        //bookUI.SetActive(false);
                        //bookTable2.SetActive(true);
                        foreach (var item in GameState.Player.Inventory.ItemList)
                            //GameState.Player.Inventory.GiveItem(item, io2);
                            io2.TakeItem(item, GameState.Player.Inventory);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameState.Player.CurrentMenu == UIMenus.None)
            {
                Debug.Log("Paused");
                GameState.Player.CurrentMenu = UIMenus.PauseMenu;
            }
            else if (GameState.Player.CurrentMenu == UIMenus.PauseMenu)
            {
                Debug.Log("Unpaused");
                GameState.Player.CurrentMenu = UIMenus.None;
            }



        }


        if (GetComponent<sitting>().isSitting == 1)
        {
            movementSpeed = 0f;
            animator.SetFloat("Sitting", 1);
        }
        else movementSpeed = 4f;
        animator.SetFloat("Sitting", 0);

        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0)
        {
            GameState.Player.CurrentDirection = CharacterDirection.Right;
            //Debug.Log("going right");
        }
        else if (movement.x < 0)
        {
            GameState.Player.CurrentDirection = CharacterDirection.Left;
            //Debug.Log("going left");
        }
        else if (movement.y > 0)
        {
            GameState.Player.CurrentDirection = CharacterDirection.Up;
            //Debug.Log("going up");

        }
        else if (movement.y < 0)
        {
            GameState.Player.CurrentDirection = CharacterDirection.Down;
            //Debug.Log("going down");
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        GameState.Player.Position = new float[] { this.transform.position.x, this.transform.position.y, 0 };
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
