using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New Leveled Move", menuName = "Project Pokemon/Pokemon/Moves/New Move", order = 1)]
public class Move : ScriptableObject
{

    public enum Category{
        Physical,
        Special,
        Status
    };



    public Type type;
    public Category category = Category.Physical;

    public int damage;
    public float hitChance;
    public int maxPP = 15;

    public float chanceOfPoison, chanceOfFreeze, chanceOfSleep, chanceOfConfusion, chanceOfBadPoison, chanceOfInfatuation;
    public float criticalChanceIncrease;

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    void OnValidate()
    {
        switch(category){
            case Category.Status:
            damage = 0;
            break;
            default:
            break;
        }
    }

}
