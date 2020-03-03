using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battle : MonoBehaviour
{

    public GameObject fightUI;
    BattleUI battleUI;
    public Pokemon testPokemon, testPokemonEnemy;
    Pokemon yourPokemon, enemyPokemon;
    bool attacking = false, yourTurn = true;

    void ShowHUD(bool show){
        fightUI.SetActive(show);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        battleUI = fightUI.GetComponent<BattleUI>();
        battleUI.CacheUIValues(testPokemon, testPokemonEnemy);
        testPokemonEnemy.ResetHealth();
        battleUI.CacheUIValues(testPokemon, testPokemonEnemy);
    }
    void Update()
    {
        if(!yourTurn){
            ShowHUD(false);
            AITurn();
        }
        else{
            ShowHUD(true);
            YourTurn();
        }
    }

    void AITurn(){
        Attack(testPokemonEnemy, testPokemon, testPokemonEnemy.move1);
        yourTurn = true;
    }

    void YourTurn(){
        if(Input.GetKeyDown(KeyCode.Return)){
            if(battleUI.GetCurrentButton().name == "Fight Button"){
                Attack(testPokemon, testPokemonEnemy, testPokemon.move1);
                yourTurn = false;
            }
        }
    }
    
    float TypeModifier(Type attackingType, Pokemon defendingPokemon){
        float effectiveness = 1.0f;
        bool dualType = (defendingPokemon.species.type2 != null);
        if(attackingType.noEffectOn.Count > 0){
            foreach(Type type in attackingType.noEffectOn){
                if(type == defendingPokemon.species.type1){
                    return 0;
                }
                if(dualType){
                    if(type == defendingPokemon.species.type2){
                        return 0;
                    }
                }
            }
        }

        foreach(Type strengths in attackingType.strengths){
            if(strengths == defendingPokemon.species.type1){
                effectiveness *= 2.0f;
            }
            if(dualType){
                if(strengths == defendingPokemon.species.type2){
                    effectiveness *= 2.0f;
                }
            }
        }



        foreach(Type type in defendingPokemon.species.type1.resistances){
            if(type == attackingType){
                effectiveness *= 0.5f;
                break;
            }
        }
        if(dualType){
            foreach(Type type in defendingPokemon.species.type2.resistances){
                if(type == attackingType){
                    effectiveness *= 0.5f;
                    break;
                }
            }
        }

        return effectiveness;
    }
    void Attack(Pokemon attacker, Pokemon target, Move move){
        float modifier = (/* targets modifier */ 1 /* weather modifier */ * 1 /* Gen 2 badge modifier */ * 1 /* Critical modifier */ * 1 
                        /* Random between 0.85 and 1.00 */ * Random.Range(0.85f, 1.0f)  /* STAB */ * (attacker.species.type1 == move.type || attacker.species.type2 == move.type ? 1.5f : 1.0f)
                         * TypeModifier(move.type, target) /* Burn status effect */ /*(move.category == Move.Category.Physical && attacker.)*/ * 1.0f /* Other interactions */ * 1.0f);
        Debug.Log($"Damage modifier: {modifier.ToString()}");
        int damage = Mathf.FloorToInt((((2 * attacker.level / 5 + 2) * (attacker.species.type1 == move.type || attacker.species.type2 == move.type ? 1.5f : 1.0f / 50) + 2) * modifier));
        Debug.Log($"Total damage dealt: {damage.ToString()} ");
        target.TakeDamage(damage);
        battleUI.CacheUIValues(testPokemon, testPokemonEnemy);
    }
}
