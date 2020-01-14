using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trainer", menuName = "Project Pokemon/New Trainer", order = 1)]
public class Trainer : ScriptableObject
{
    public enum TrainerTitle{
        AceTrainer,
        DragonTamer,
        GymLeader,
        Hiker,
        PokemonTrainer
    };
    public TrainerTitle trainerTitle;
    public string trainerName;

    string GetTrainerNameString(TrainerTitle title){
        switch(title){
                case TrainerTitle.AceTrainer:
                return $"Ace Trainer {trainerName}";
                case TrainerTitle.DragonTamer:
                return $"Dragon Tamer {trainerName}";
                case TrainerTitle.GymLeader:
                return $"Gym Leader {trainerName}";
                case TrainerTitle.PokemonTrainer:
                return $"Pokemon Trainer {trainerName}";
                default:
                return trainerName;
        }
    }
    public List<Pokemon> pokemon;
    public int cashReward;
    //Items
    //Difficulty
    //Dialogue

}
