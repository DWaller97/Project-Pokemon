using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Nature", menuName = "Project Pokemon/Pokemon/Natures", order = 1)]
public class Nature : ScriptableObject
{
    public enum Stats{
        Atk,
        Def,
        SpAtk,
        SpDef,
        Spd
    }

    public Stats statToIncrease, statToDecrease;

    

}
