using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New Leveled Move", menuName = "Project Pokemon/Pokemon/Moves/New Move", order = 1)]
public class Move : ScriptableObject
{
    public Type type;
    public int damage;
    public float hitChance;
    public float chanceOfPoison, chanceOfFreeze, chanceOfSleep, chanceOfConfusion, chanceOfBadPoison, chanceOfInfatuation;
    public float criticalChanceIncrease;

}
