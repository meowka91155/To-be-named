using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Objects
{
    [Serializable]
    abstract public class CharacterData
    {

        public string Name { get; set; }
        public CharacterKeys Key { get; private set; }
        public InventoryObject Inventory { get; private set; }
        public GameObject GameObject
        {
            get { return Inventory.GameObject; }
        }
        public CharacterData(string unityIDname, CharacterKeys key, string assetID)
        {
            Name = unityIDname;
            Key = key;
            Inventory = new InventoryObject(unityIDname, 1,assetID);
        }
    }

    [Serializable]
    public class Player : CharacterData
    {

        public new PlayerInventoryObject Inventory { get; private set; }

        public storyline Story { get; set; }

        public float[] Position { get; set; }
        public float[] PositionJanitor { get; set; }

        public GameRooms CurrentRoom { get; set; } //= GameRooms.Lobby;

        public GameRooms JanitorCurrentRoom { get; set; } //= GameRooms.Lobby;

        public CharacterDirection CurrentDirection { get; set; } //= CharacterDirection.Down;

        public UIMenus CurrentMenu { get; set; }
        public Janitor JanitorFollow { get; set; } //= Janitor.no;

        public storyline StoryLine { get; set; }// = storyline.Book;

        public Player(string unityIDname, string assetID) : base(unityIDname, CharacterKeys.Player, assetID)
        {

            Story = storyline.Book;


            PositionJanitor = new float[] { 0, 0, 0 };
            Position = new float[] { 0, 0, 0 };
            Inventory = new PlayerInventoryObject(unityIDname, 1, assetID);

        }
    }

    [Serializable]
    public class NPC : CharacterData
    {

        public NPC(string name, CharacterKeys key, string assetID) : base(name, key,assetID)
        {

        }
        public int QuestsAvailable { get; set; } = 1;
        public int CurrentQuestNumber { get; set; } = 0;
    }

}
