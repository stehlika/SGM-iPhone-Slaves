using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequest {

    [SerializeField] public Sprite icon;
    [SerializeField] public string name;
    [SerializeField] public int timeToBuild;
    [SerializeField] public Sprite[] materialsIcons;
    [SerializeField] public ItemType type;

    public ItemRequest(Sprite icon, string name, int timeToBuild, Sprite[] materials)
    {
        this.icon = icon;
        this.name = name;
        this.timeToBuild = timeToBuild;
        materialsIcons = materials;
        this.type = type;
    }
}

public enum ItemType
{
    motherboard,
    display,
    keyboard,
    mouse,
    pcCase,
    cardboard,
    metal
}
