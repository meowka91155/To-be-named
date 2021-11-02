using Assets;
using Assets.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teacherRoom2 : MonoBehaviour
{



    public bool ShowBox = false;
    public string teacherText = "Have you seen my book?";
    public bool isAtTeacher = false;
    public GameObject bookUI;
    public int teacherTextForward = 0;
    private Vector3 leftOfChalkboard = new Vector3(-6.77f, 1.551056f, 18.82985f);

    // Start is called before the first frame update
    void Start()
    {
        teacherText = "Have you seen my book?";
    }

    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<playerController>();
        if (Input.GetKeyDown("f"))
        {

            if (teacherTextForward == 1)
            {
                teacherText = "Can you get the janitor for me?";
                teacherTextForward = 2;
            }
            else if (teacherTextForward == 2)
            {
                teacherText = "My chalkboard is falling off the wall";
                teacherTextForward = 3;
            }
            else if (teacherTextForward == 3)
            {
                teacherText = "Thanks";
                teacherTextForward = 4;
                GameState.Player.StoryLine = storyline.Janitor;
            }
            else if (teacherTextForward == 4)
            {
                teacherText = "";
                teacherTextForward = 5;
            }
            else if (GameState.Player.StoryLine == storyline.currentlyAfterJanitor && teacherTextForward == 5)
            {
                teacherText = "Oh good";
                teacherTextForward = 6;
            }
            else if (teacherTextForward == 6)
            {
                teacherText = "Bob, can you fix the board?";
                teacherTextForward = 7;
                
            }
            else if (teacherTextForward == 7)
            {
                teacherText = "";
                GameState.Player.StoryLine = storyline.janitorRepair;
                this.transform.localPosition = new Vector3(-6.56f, 1.551056f, 18.82985f);
                teacherTextForward = 8;
            }


            var Teacher = (NPC)GameState.Characters[Assets.CharacterKeys.Teacher];

            if (Teacher.Inventory.Count > 0)
            {
                ///returning the book to the player

                //Debug.Log("Teacher giving books");
                //foreach (var item in Items.ToArray())
                //    GiveItem(item, player);
                //teacherText = "here's the book";
                //bookUI.gameObject.SetActive(true);

                ///

                if (teacherTextForward == 0)
                {
                    teacherText = "Can I ask you a favor?";
                    teacherTextForward = 1;
                }


            }
            else
            {
                if (isAtTeacher)
                {
                    Debug.Log("I don't have the book, and niether do you!");
                }
                else
                {

                }


                teacherText = "Hey have you seen my book?";

            }
        }






        //we have a reply?
        //take inventory
    }


    void OnGUI()
    {
        if (ShowBox)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            GUI.Box(new Rect(screenPos.x - 200, Screen.height - screenPos.y, 300, 50), teacherText);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ShowBox = true;

        Debug.Log(collision.gameObject.tag);
        //is the player?


        if (GameState.Player.Inventory.Count > 0)
        {
            var Teacher = (NPC)GameState.Characters[Assets.CharacterKeys.Teacher];
            Debug.Log("Teacher taking books");
            bookUI.gameObject.SetActive(false);
            foreach (var item in GameState.Player.Inventory.ItemList)
                Teacher.Inventory.TakeItem(item, GameState.Player.Inventory);
            teacherText = "Thanks for finding my book";
        }



        //show a message?
        //wait for reply?












        //if (player.Items.Contains(Settings.LibraryBook1))
        //{
        //    //show a message
        //    Debug.Log($"The book {Settings.LibraryBook1.Name} has {Settings.LibraryBook1.Pages} and " +
        //        $"weighs {Settings.LibraryBook1.Weight} rocks.");

        //    TakeItem(Settings.LibraryBook1, player);
        //} else
        //{
        //    if (Items.Contains(Settings.LibraryBook1))
        //    {
        //        GiveItem(Settings.LibraryBook1, player);
        //    } else
        //    {
        //        Debug.Log("I don't have the book, and niether do you!");
        //    }
        //}

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ShowBox = false;

    }

}
