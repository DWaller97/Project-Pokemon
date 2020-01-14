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
        maxHP = (int)(((/*IV*/ 2 * species.baseHP /* + (IV / 4 )*/) * level / 100) + 10 + level);
        currHP = maxHP;
        attack = (int)(((/*IV + */ 2 * species.baseAtk /* + (IV / 4) */) * level / 100) + 5); /* * Nature*/
        defence = (int)(((/*IV + */ 2 * species.baseDef /* + (IV / 4) */) * level / 100) + 5); /* * Nature*/
        specialAttack = (int)(((/*IV + */ 2 * species.baseSpAtk /* + (IV / 4) */) * level / 100) + 5); /* * Nature*/
        specialDefence = (int)(((/*IV + */ 2 * species.baseSpDef /* + (IV / 4) */) * level / 100) + 5); /* * Nature*/
        speed = (int)(((/*IV + */ 2 * species.baseSpd /* + (IV / 4) */) * level / 100) + 5); /* * Nature*/
    }
    public BasePokemon species;
    public string nickname;
    //IV's
    //EV's
    public int level = 50;
    public int currHP, maxHP;
    public int attack, defence, specialAttack, specialDefence, speed;
    public Move move1, move2, move3, move4;
    public int currHappiness;
}
