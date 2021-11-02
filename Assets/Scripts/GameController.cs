using Assets.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(" ** LOADING ** ");
            // Characters = new Dictionary<CharacterKeys, Assets.Objects.CharacterData>();


            if (!GameState.Characters.ContainsKey(CharacterKeys.Janitor))
                GameState.Characters.Add(CharacterKeys.Janitor, new Assets.Objects.NPC("Janitor", CharacterKeys.Janitor, "Janitor"));
            if (!GameState.Characters.ContainsKey(CharacterKeys.Teacher))
                GameState.Characters.Add(CharacterKeys.Teacher, new Assets.Objects.NPC("TriggerTeacher", CharacterKeys.Teacher, "Teacher"));

            //InteractableObjects = new Dictionary<InteractableObjectKeys, Assets.Objects.ItemData>();
            if (!GameState.InteractableObjects.ContainsKey(InteractableObjectKeys.Desk01))
                GameState.InteractableObjects.Add(InteractableObjectKeys.Desk01, new Assets.Objects.Desk("libraryDesk1", "Interiors_free_16x16_43"));
            if (!GameState.InteractableObjects.ContainsKey(InteractableObjectKeys.Desk02))
                GameState.InteractableObjects.Add(InteractableObjectKeys.Desk02, new Assets.Objects.Desk("libraryDesk2", "Interiors_free_16x16_143"));

            // GameInventory = new Dictionary<ItemKeys, Assets.Objects.ItemData>();
            if (!GameState.GameInventory.ContainsKey(ItemKeys.Book1))
            {
                GameState.GameInventory.Add(ItemKeys.Book1, new Assets.Objects.Book("BookTable1", 1, 50, "Interiors_free_16x16_141"));
                GameState.InteractableObjects[InteractableObjectKeys.Desk01].Add(GameState.GameInventory[ItemKeys.Book1]);
            }
            if (!GameState.GameInventory.ContainsKey(ItemKeys.Book2))
                GameState.GameInventory.Add(ItemKeys.Book2, new Assets.Objects.Book("Book02", 9, 590, "Interiors_free_16x16_141"));

 
            GameState.CurrentDirection = CharacterDirection.Down;
            GameState.Player.CurrentRoom = GameRooms.Lobby;

            var teacher = ((NPC)GameState.Characters[CharacterKeys.Teacher]);

            teacher.QuestsAvailable = 4;
            teacher.CurrentQuestNumber = 0;

            ((NPC)GameState.Characters[CharacterKeys.Janitor]).QuestsAvailable = 1;
            ((NPC)GameState.Characters[CharacterKeys.Janitor]).CurrentQuestNumber = 0;

        }
        public void SavePlayer()
        {



            GameState.SavePlayer();
        }
        public void LoadPlayer()
        {
            GameState.LoadPlayer();
            var data = GameState.Player;


            Vector3 position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);
            data.GameObject.transform.position = position;
        }
        public void MainMenu()
        {
            SceneManager.LoadScene(sceneName: "Main Menu");
        }
    }
}
