using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Objects
{
    [System.Serializable]
    public class PlayerData : InventoryObject
    {
        public storyline Story { get; set; }

        public float[] Position { get; set; }
        public float[] PositionJanitor { get; set; }

        public GameRooms CurrentRoom { get; set; } //= GameRooms.Lobby;

        public GameRooms janitorCurrentRoom { get; set; } //= GameRooms.Lobby;

        

        public Janitor janitorFollow { get; set; } //= Janitor.no;

        public storyline storyLine { get; set; }// = storyline.Book;

        

        public PlayerData(string unityIDname):base(unityIDname,1, "Interiors_free_16x16_141")
        {

            Story = storyline.Book;



            PositionJanitor = new float[] { 0, 0, 0 };
            Position = new float[] { 0, 0, 0 };
        }
    }
}