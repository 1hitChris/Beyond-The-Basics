using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewStats", menuName ="Character/Stats", order = 1)]
public class CharacterStat_SO : ScriptableObject
{
    [System.Serializable]
    public class CharLevelUps
    {
        public int maxHealth;
        public int maxMana;
        public int maxWealth;
        public int baseDamage;
        public float baseResistance;
        public float maxEncumberance;
    }
    #region Fields

    public bool setManually = false;
    public bool saveDataOnClose = false;

    public ItemPickUp weapon { get; private set; }
    public ItemPickUp headArmor { get; private set; }
    public ItemPickUp chestArmor { get; private set; }
    public ItemPickUp handArmor { get; private set; }
    public ItemPickUp legArmor { get; private set; }
    public ItemPickUp footArmor { get; private set; }
    public ItemPickUp misc1 { get; private set; }
    public ItemPickUp misc2 { get; private set; }

    public int maxHealth = 0;
    public int currentHealth = 0;

    public int maxMana = 0;
    public int currentMana = 0;

    public int maxWealth = 0;
    public int currentWealth = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public float baseResistance = 0f;
    public float currentResistance = 0f;

    public float maxEncumbrance = 0f;
    public float currentEncumbrance = 0f;

    public int charExperience = 0;
    public int charLevel = 0;

    public CharLevelUps[] charLevelUps;

    #endregion

    #region Stat Increasers
    public void ApplyHealth(int healthAmount)
    {
        if (currentHealth + healthAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void ApplyMana(int manaAmount)
    {
        if ((currentMana + manaAmount) > maxMana )
        {
            currentMana = maxMana;
        }
        else
        {
            currentMana += manaAmount;
        }
    }

    public void GiveWealth(int wealthAmount)
    {
        if ((currentWealth + wealthAmount) > maxWealth)
        {
            currentWealth = maxWealth;
        }
        else
        {
            currentWealth += wealthAmount;
        }
    }
    public void EquipWeapon(ItemPickUp weaponPickUp, CharacterInventory charInventory, GameObject weaponSlot)
    {
        weapon = weaponPickUp;
        currentDamage = baseDamage + weapon.itemDefinition.itemAmount;
    }

    public void EquipArmor(ItemPickUp armorPickUp, CharacterInventory charInventory)
    {
        switch (armorPickUp.itemDefinition.itemArmorSubType)
        {
            case ItemArmorSubType.None:
                break;
            case ItemArmorSubType.Head:
                headArmor = armorPickUp;
                currentResistance += armorPickUp.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Chest:
                chestArmor = armorPickUp;
                currentResistance += armorPickUp.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Glove:
                handArmor = armorPickUp;
                currentResistance += armorPickUp.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Leg:
                legArmor = armorPickUp;
                currentResistance += armorPickUp.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Boots:
                footArmor = armorPickUp;
                currentResistance += armorPickUp.itemDefinition.itemAmount;
                break;
            default:
                break;
        }
    }

    #endregion

    #region Stat Decreasers
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //Write method for character death
            //Death();
        }
    }

    public void TakeMana(int amount)
    {
        currentMana -= amount;

        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public void LoseWealth(int amount)
    {
        currentWealth -= amount;

        if (currentWealth < 0)
        {
            currentWealth = 0;
        }
    }

    public void LoseExperience(int amount)
    {
        charExperience -= amount;

        if (charExperience < 0)
        {
            charLevel -= 1;
        }
    }

    public bool UnEquipWeapon(ItemPickUp weaponPickUp, CharacterInventory charInventory, GameObject weaponSlot)
    {
        bool previousWeaponSame = false;

        if (weapon != null)
        {
            if (weapon == weaponPickUp)
            {
                previousWeaponSame = true;
            }

            DestroyObject(weaponSlot.transform.GetChild(0).gameObject);
            weapon = null;
            currentDamage = baseDamage;
        }
        return previousWeaponSame;
    }

    public bool UnEquipArmor(ItemPickUp armorPickUp, CharacterInventory charInventory)
    {
        bool previousArmorSame = false;

        switch (armorPickUp.itemDefinition.itemArmorSubType)
        {
            case ItemArmorSubType.None:
                break;
            case ItemArmorSubType.Head:
                if (headArmor != null)
                {
                    if (headArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }

                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    headArmor = null;
                }
                break;
            case ItemArmorSubType.Chest:
                if (chestArmor != null)
                {
                    if (chestArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }

                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    chestArmor = null;
                }
                break;
            case ItemArmorSubType.Glove:
                if (handArmor != null)
                {
                    if (handArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }

                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    handArmor = null;
                }
                break;
            case ItemArmorSubType.Leg:
                if (legArmor != null)
                {
                    if (legArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }

                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    legArmor = null;
                }
                break;
            case ItemArmorSubType.Boots:
                if (footArmor != null)
                {
                    if (footArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }

                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    footArmor = null;
                }
                break;
            default:
                break;
        }

        return previousArmorSame;
    }

    #endregion

    #region Character Level Up and Death
    private void Death()
    {
        Debug.Log("You're Dead");
        //Call to Game Manager for Death State to Trigger Respawn
        //Display the Death animation/particle effects
    }

    private void LevelUp()
    {
        charLevel += 1;
        //Display level up visualization

        maxHealth = charLevelUps[charLevel - 1].maxHealth;
        maxMana = charLevelUps[charLevel - 1].maxMana;
        maxWealth = charLevelUps[charLevel - 1].maxWealth;
        baseDamage = charLevelUps[charLevel - 1].baseDamage;
        baseResistance = charLevelUps[charLevel - 1].baseResistance;
        maxEncumbrance = charLevelUps[charLevel - 1].maxEncumberance;
    }

    #endregion

    #region SaveCharacterData

    public void SaveCharacterData()
    {
       /* saveDataOnClose = true;
        EditorUtility.SetDirty(this);*/
    }

    #endregion
}
