using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Objects;

public class MainMenuController : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameState.Characters.ContainsKey(CharacterKeys.Teacher))
            GameState.Player = new Player("Adam", "Adam");

        GameState.Player.CurrentMenu = UIMenus.MainMenu;

        PlayButton.onClick.AddListener(TaskOnClick);
        QuitButton.onClick.AddListener(Quitting);
    }
    void TaskOnClick()
    {
        Debug.Log("play");
        GameState.Player.CurrentMenu = UIMenus.None;
        SceneManager.LoadScene(sceneName: "SampleScene");

    }

    void Quitting()
    {
        Debug.Log("Quitting");
        Application.Quit();

    }
    // Update is called once per frame
    void Update()
    {
    }
}
