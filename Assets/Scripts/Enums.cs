using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{

    public enum GameRooms
    {
        Lobby = 1,
        Lobby2 = 2,
        Room1 = 4,
        Room1_2 = 8,
        Room2 = 16,

    }
    public enum GameRoomsTriggers
    {
        Book1Library = 1,
    }

    public enum CharacterDirection
    {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
    }
    public enum BookLocation
    {
        Desk,
        Character,
    }

    public enum Janitor
    {
        yes = 1,
        no = 2,
    }

    public enum storyline : int
    {
        Book = 1,
        Janitor = 2,
        currentlyAfterJanitor = 4,
        janitorRepair = 5,
        janitorDoneRepair = 6,
        janitorLeave = 7,
    }

    public enum CharacterKeys
    {
        Player = 0,
        Teacher = 1,
        Janitor = 2,
    }

    public enum ItemKeys
    {
        Book1 = 1,
        Book2 = 2,
    }

    public enum InteractableObjectKeys
    {
        Desk01 = 100,
        Desk02 = 200,
    }

    public enum UIMenus
    {
        None = 0,
        MainMenu = 1,
        PlayMenu = 2,

        PauseMenu = 300,
    }

}
