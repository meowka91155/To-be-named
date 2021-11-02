using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menus : MonoBehaviour
{

    
    public GameObject PauseMenu;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.transform.localPosition = new Vector3(1000, 10, 0);
    }

    // Update is called once per frame
    

    void Update()
    {
        
        
        switch(GameState.Player.CurrentMenu)
        {
            case UIMenus.None:
                //LoadButton.transform.position = new Vector3(1000, 0, 0);
                PauseMenu.transform.localPosition = new Vector3(1000, 10, 0);
                break;
            case UIMenus.MainMenu:

                break;
            case UIMenus.PauseMenu:
                
                PauseMenu.transform.localPosition = new Vector3(0, 0, 0);
                
                
                break; 
        }
    }
}
