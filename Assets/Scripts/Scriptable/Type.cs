using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Type", menuName = "Project Pokemon/Type", order = 1)]
public class Type : ScriptableObject
{
    public Texture2D icon;
    public List<Type> strengths, weaknesses, resistances, noEffectOn, notAffectedBy;
}
