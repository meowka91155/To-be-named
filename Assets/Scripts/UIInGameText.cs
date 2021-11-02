using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIInGameText : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject txtBook1Library;
    public GameObject book1LibraryTrigger;
    public GameObject txtBook2Library;
    public GameObject txtTeacherThanksLibBook1;

    // Update is called once per frame
    void Update()
    {
        txtBook1Library.gameObject.SetActive(GameState.Player.CurrentRoom == GameRooms.Lobby &&
            (GameState.InteractableObjects.Count > 0));

        txtBook2Library.gameObject.SetActive(GameState.Player.CurrentRoom == GameRooms.Lobby &&
            (GameState.InteractableObjects.Count == 0));

    }
}
