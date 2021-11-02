using Assets;
using Assets.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;





public static class GameState
{
    //   public static PlayerData playerData { get; set; } = new PlayerData();


  public static  Sprite[] abilityIconsAtlas = Resources.LoadAll<Sprite>("Interiors_free_16x16");
    public static Player Player { get; set; }


    public static CharacterDirection CurrentDirection { get; set; } //= CharacterDirection.Down;

    public static BookLocation BookLocation { get; set; }
    //public static Assets.Objects.NPC Teacher { get; set; } = new Assets.Objects.NPC();

    //public static Assets.Objects.NPC Janitor { get; set; } = new Assets.Objects.NPC();
    //public static Assets.Objects.Desk LibraryDesk01 { get; set; } = new Assets.Objects.Desk("LibraryDesk1");

    public static Dictionary<CharacterKeys, CharacterData> Characters { get; private set; }
     = new Dictionary<CharacterKeys, Assets.Objects.CharacterData>();
    public static Dictionary<InteractableObjectKeys, Assets.Objects.ItemData> InteractableObjects { get; private set; }
     = new Dictionary<InteractableObjectKeys, ItemData>();
    public static Dictionary<ItemKeys, Assets.Objects.ItemData> GameInventory { get; private set; }
     = new Dictionary<ItemKeys, ItemData>();

    //public static List<GameRoomsTriggers> triggersActive { get; private set; } = new List<GameRoomsTriggers>();

    //public static List<GameRoomsTriggers> triggersActivated { get; private set; } = new List<GameRoomsTriggers>();

    //public static List<Inventory> currentInventory { get; private set; } = new List<Inventory>();

    //public static List<Inventory> pendingInventory { get; private set; } = new List<Inventory>();
    //public static List<Inventory> oldInventory { get; private set; } = new List<Inventory>();


    //public static List<Assets.ItemBase> PlayerInventory { get; set; } = new List<Assets.ItemBase>();




    //public static Assets.Desk LibraryDesk1 { get; private set; }
    //    = new Assets.Desk("libraryDesk1", new List<Assets.Book>() { new Assets.Book("Book", 1, 2) });

    //public static Assets.Desk LibraryDesk2 { get; private set; } = new Assets.Desk("libraryDesk2");





    public static void SavePlayer()
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath;
            object data = new object[] { 
                GameState.Player, 
                GameState.Characters, 
                GameState.InteractableObjects, 
                GameState.GameInventory };

            using (FileStream stream = new FileStream(path + "/savedata.gotmilk", FileMode.Create))
            {
                formatter.Serialize(stream, data);
                stream.Close();
                stream.Dispose();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.ToString());
            throw;
        }



    }

    public static void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savedata.gotmilk";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                object[] data = (object[])formatter.Deserialize(stream);
                stream.Close();
                stream.Dispose();
                Player = (Player)data[0];
                Characters = (Dictionary<CharacterKeys, Assets.Objects.CharacterData>)data[1];
                InteractableObjects = (Dictionary<InteractableObjectKeys, Assets.Objects.ItemData>)data[2];
                GameInventory = (Dictionary<ItemKeys, Assets.Objects.ItemData>)data[3];


            }


            //return data;

        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            //return null;
        }
    }




}
