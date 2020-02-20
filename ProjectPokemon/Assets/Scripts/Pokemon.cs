using System;
using UnityEngine;
/*
 *  An individual Pokemon with its own specific stats, different from a base version of its species.
 */

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Project Pokemon/Pokemon/Individual", order = 1)]
public class Pokemon : ScriptableObject
{

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    

    void OnValidate()
    {
        totalEV = hpEV + atkEV + defEV + spAtkEV + spDefEV + spdEV;
        maxHP = (int)((((2 * species.baseHP + hpIV + (hpEV / 4 )) * level) / 100) + level + 10);
        currHP = maxHP;
        attack = (int)(((((2 * species.baseAtk + atkIV + (atkEV / 4)) * level) / 100) + 5));  /* * Nature*/
        defence = (int)(((((2 * species.baseDef + defIV + (defEV / 4)) * level) / 100) + 5)); /* * Nature*/
        specialAttack = (int)(((((2 * species.baseSpAtk + spAtkIV + (spAtkEV / 4)) * level) / 100) + 5)); /* * Nature*/
        specialDefence = (int)(((((2 * species.baseSpDef + spDefIV + (spDefEV / 4)) * level) / 100) + 5)); /* * Nature*/
        speed = (int)(((((2 * species.baseSpd + spdIV + (spdEV / 4)) * level) / 100) + 5)); /* * Nature*/
        AddNatureToStat();

    }

    void AddNatureToStat(){

        if(nature.statToIncrease == nature.statToDecrease)
            return;

        if(nature.statToIncrease == Nature.Stats.Atk){
            attack = (int)(attack * 1.1f);
        }
        if(nature.statToIncrease == Nature.Stats.Def){
            defence = (int)(defence  * 1.1f);
        }
        if(nature.statToIncrease == Nature.Stats.SpAtk){
            specialAttack = (int)(specialAttack * 1.1f);
        }
        if(nature.statToIncrease == Nature.Stats.SpDef){
            specialDefence = (int)(specialDefence * 1.1f);
        }
        if(nature.statToIncrease == Nature.Stats.Spd){
            speed = (int)(speed * 1.1f);
        }

        if(nature.statToDecrease == Nature.Stats.Atk){
            attack = (int)(attack * 0.9f);
        }
        if(nature.statToDecrease == Nature.Stats.Def){
            defence = (int)(defence * 0.9f);
        }
        if(nature.statToDecrease == Nature.Stats.SpAtk){
            specialAttack = (int)(specialAttack * 0.9f);
        }
        if(nature.statToDecrease == Nature.Stats.SpDef){
            specialDefence = (int)(specialDefence * 0.9f);
        }
        if(nature.statToDecrease == Nature.Stats.Spd){
            speed = (int)(speed * 0.9f);
        }

    }
    

    public string nickname;
    public BasePokemon species;
    public Nature nature;
    public int currHappiness;
    [Space]
    [Header("Moves")]
    public Move move1;
    public Move move2, move3, move4;
    
    [Space]
    [Header("Individual Values")]
    [Range(0, 31)]
    public int hpIV;
    [Range(0, 31)]
    public int atkIV, defIV, spAtkIV, spDefIV, spdIV;

    public static int totalEV;

    [Space]
    [Header("Effort Values (Max: 510)")]
    [Range(0, 255)]
    public int hpEV;
    [Range(0, 255)]
    public int atkEV, defEV, spAtkEV, spDefEV, spdEV;
    [Space]
    [Range(1, 100)]
    public int level = 50;
    [Space]
    [Header("Final Stats")]
    public int maxHP;
    public int currHP, attack, defence, specialAttack, specialDefence, speed;
    //Make a generate button for random stats
}
