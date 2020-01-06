using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Leveled Move", menuName = "Project Pokemon/Pokemon/Moves/New Move", order = 1)]
public class NewMove : ScriptableObject
{
    public Move move;
    public int level;
}
