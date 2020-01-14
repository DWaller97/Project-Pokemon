using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * A Pokemon with information about a species' default information
 */

[CreateAssetMenu(fileName = "New Pokemon Species", menuName = "Project Pokemon/Pokemon/Species", order = 1)]
public class BasePokemon : ScriptableObject
{
    public Type type1, type2;
    public enum GrowthRate
    {
        Fast,
        Medium,
        Slow
    }

    public string relativePathToPrefab;
    public string name;
    public int id;
    public int baseHP, baseAtk, baseDef, baseSpAtk, baseSpDef, baseSpd;
    public int baseHappiness;
    public GrowthRate growthRate;

    public Evolution evolution;

    public List<NewMove> learnedMoves;
}