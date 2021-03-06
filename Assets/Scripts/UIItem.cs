using Assets.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public ItemData item;
    private Image spriteImage;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(ItemData item)
    {
        this.item = item;
        if(this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.Icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }
}
