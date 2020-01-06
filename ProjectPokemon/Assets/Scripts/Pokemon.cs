using System;
using UnityEngine;
/*
 *  An individual Pokemon with its own specific stats, different from a base version of its species.
 */

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Project Pokemon/Pokemon/Individual", order = 1)]
public class Pokemon : ScriptableObject
{
    public BasePokemon species;
    public string nickname;
    //IV's
    //EV's
    public int currHP, maxHP;
    public int attack, defence, specialAttack, specialDefence, speed;
    public Move move1, move2, move3, move4;
    public int currHappiness;
}
