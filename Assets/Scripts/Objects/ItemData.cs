using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Objects
{
    [Serializable]
    abstract public class ItemData
    {
        public ItemData(string unityIDname, decimal weight, string resourceID)
        {
            Name = unityIDname;
            Weight = weight;
            ResourceID = resourceID;
        }


        public string Name { get; set; }
        public decimal Weight { get; set; }

        private string ResourceID;

        public Sprite Icon
        {
            get
            {
              return  GameState.abilityIconsAtlas.SingleOrDefault(q => q.name == ResourceID);
            }
        }

        public GameObject GameObject { get { return UnityEngine.GameObject.Find(Name); } }

        protected List<ItemData> Items { get; set; } = new List<ItemData>();
        public void Add(ItemData item)
        {
            Items.Add(item);
        }
        public bool Contains(ItemData item)
        {
            return Items.Contains(item);
        }
        public IEnumerable<ItemData> ItemList { get { return Items.ToArray(); } }
        public decimal InventoryWeight
        {
            get
            {
                return Items.Sum(q =>
                {
                    //if (q.GetType().Equals(typeof(Assets.Gun)) && ((Assets.Gun)q).PeopleKilled > 0)
                    //    return q.Weight * ((Assets.Gun)q).PeopleKilled;

                    return q.Weight;
                });
            }
        }
        public decimal Count
        {
            get
            {
                return Items.Count();
            }
        }

        public void TakeItem(ItemData item, ItemData from)
        {
            if (from.Contains(item))
            {
                from.GiveItem(item, this);
            }
            else
            {
                //yhou dont have it.
            }
        }
        public abstract void GiveItem(ItemData item, ItemData to);

    }


    [Serializable]
    public class InventoryObject : ItemData
    {
        public InventoryObject(string unityIDname, decimal weight, string resourceID) : base(unityIDname, weight, resourceID) { }

        public override void GiveItem(ItemData item, ItemData to)
        {
            {
                if (base.Contains(item))
                {
                    to.Add(item);
                    base.Items.Remove(item);
                }
                else
                {
                    //yhou dont have it.
                }
            }
        }
    }

    [Serializable]
    public class PlayerInventoryObject : ItemData
    {
        public PlayerInventoryObject(string unityIDname, decimal weight, string resourceID) : base(unityIDname, weight, resourceID)
        {
        }

        [NonSerialized]
        public UIInventory inventoryUI;
        public new void TakeItem(ItemData item, ItemData from)
        {
            base.TakeItem(item, from);
            if (Items.Contains(item))
            {
                inventoryUI.AddNewItem(item);
            }
            else
            {
                //yhou dont have it.
            }
        }

        public override void GiveItem(ItemData item, ItemData to)
        {
            {
                if (base.Contains(item))
                {
                    to.Add(item);
                    base.Items.Remove(item);
                    inventoryUI.RemoveItem(item);
                }
                else
                {
                    //yhou dont have it.
                }
            }
        }
    }

    [Serializable]
    public class Gun : ItemData
    {
        public Gun(string unityIDname, decimal weight, string resourceID) : base(unityIDname, weight, resourceID) { }

        public override void GiveItem(ItemData item, ItemData to)
        {
            {
                if (Items.Contains(item))
                {
                    to.Add(item);
                    Items.Remove(item);
                }
                else
                {
                    //yhou dont have it.
                }
            }
        }
    }

    [Serializable]
    public class Desk : ItemData
    {
        public Desk(string unityIDname, string resourceID) : base(unityIDname, 0, resourceID) { }


        public new void TakeItem(ItemData item, ItemData from)
        {
            base.TakeItem(item, from);
            if (Items.Contains(item))
            {
                var ourDesk = this.GameObject;
                //show on desk
                item.GameObject.transform.position = new Vector3(ourDesk.transform.position.x - 0.15f, ourDesk.transform.position.y + 0.15f, 0);
            }
            else
            {
                //yhou dont have it.
            }
        }
        public override void GiveItem(ItemData item, ItemData to)
        {
            if (Items.Contains(item))
            {
                to.Add(item);
                Items.Remove(item);
                item.GameObject.transform.position = new Vector3(25, 25, 0);
            }
            else
            {
                //yhou dont have it.
            }

        }


    }

    [Serializable]
    public class Book : ItemData
    {
        public Book(string unityIDname, decimal weight, int pages, string resourceID) : base(unityIDname, weight, resourceID)
        {
            Pages = pages;
        }
        public int Pages { get; set; }

        public override void GiveItem(ItemData item, ItemData to)
        {
            if (Items.Contains(item))
            {
                to.Add(item);
                Items.Remove(item);
            }
            else
            {
                //yhou dont have it.
            }
        }
    }
}
