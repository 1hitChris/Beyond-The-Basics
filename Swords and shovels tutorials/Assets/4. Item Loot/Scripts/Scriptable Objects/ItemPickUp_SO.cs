using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeDefinitions {HEALTH, WEALTH, MANA, WEAPON, ARMOR, BUFF, EMPTY }
public enum ItemArmorSubType {None, Head, Chest, Glove, Leg, Boots }

[CreateAssetMenu(fileName = "New Item", menuName = "Spawnable Item/ New Pick Up", order = 1)]
public class ItemPickUp_SO : ScriptableObject
{
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.HEALTH;
    public ItemArmorSubType itemArmorSubType = ItemArmorSubType.None;
    public int itemAmount = 0;
}
