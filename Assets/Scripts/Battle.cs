using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battle : MonoBehaviour
{
    UI ui;
    MessageUI.BattleMessage battleMessage = new MessageUI.BattleMessage();
    public Pokemon testPokemon, testPokemonEnemy;
    Pokemon yourPokemon, enemyPokemon;
    bool attacking = false, yourTurn = true, runningTurn = false;

    

    void Start()
    {
        ui = UI.GetInstance();
        ui.battleUIClass.CacheUIValues(testPokemon, testPokemonEnemy);
        testPokemonEnemy.ResetHealth();
        ui.battleUIClass.CacheUIValues(testPokemon, testPokemonEnemy);
        StartCoroutine(BattleRoutine());
    }

    IEnumerator BattleRoutine(){
        while(GameManager.GetGameState() == GameManager.GameState.Battle){
            ui.battleUIClass.CacheUIValues(testPokemon, testPokemonEnemy);
            if(!yourTurn){
                if(!runningTurn)
                    StartCoroutine(AITurn());
            }else{
                if(!runningTurn)
                    StartCoroutine(YourTurn());
            }
            yield return null;
        }
        yield break;
    }

    IEnumerator AITurn(){
        runningTurn = true;
        if(ui.battleUI.activeInHierarchy){
            //TODO: Only make the menu dissappear
            ui.SetUIInactive();
            ui.messageUI.SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);
        Attack(testPokemonEnemy, testPokemon, testPokemonEnemy.move1);
        yourTurn = true;
        runningTurn = false;
    }

    IEnumerator YourTurn(){
        runningTurn = true;
        if(!ui.battleUI.activeInHierarchy){
            ui.SetUIInactive();
            ui.battleUI.SetActive(true);
        }
        while(true){ //Just run until the player makes a decision
            if(Input.GetKeyDown(KeyCode.Return)){
                if(ui.GetCurrentButton().name == "Fight Button"){
                    ui.SetUIInactive();
                    ui.moveUI.SetActive(true);
                    while(true){
                        break;
                    }
                    break;
                }
            }
            yield return null;
        }
        yield break;

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
        bool STAB = (attacker.species.type1 == move.type || attacker.species.type2 == move.type);
        float typeEffectiveness = TypeModifier(move.type, target);
        switch (typeEffectiveness)
        {
            case 0.0f:
                battleMessage.attackEffectiveness = BattleManager.AttackEffectiveness.NoEffect;
                break;
            case 0.25f:
                battleMessage.attackEffectiveness = BattleManager.AttackEffectiveness.NotVeryEffective;
                break;
            case 0.5f:
                battleMessage.attackEffectiveness = BattleManager.AttackEffectiveness.NotVeryEffective;
                break;
            case 1.0f:
                battleMessage.attackEffectiveness = BattleManager.AttackEffectiveness.Normal;
                break;
            case 2.0f:
                battleMessage.attackEffectiveness = BattleManager.AttackEffectiveness.SuperEffective;
                break;
            case 4.0f:
                battleMessage.attackEffectiveness = BattleManager.AttackEffectiveness.SuperEffective;
                break;
            default:
                battleMessage.attackEffectiveness = BattleManager.AttackEffectiveness.Normal;
                break;
        }
        bool crit = false;
        battleMessage.wasMoveCritical = crit;
        battleMessage.moveUsed = move.name;
        battleMessage.attackerName = attacker.nickname == "" ? attacker.species.name : attacker.nickname;
        battleMessage.targetName = target.nickname == "" ? target.species.name : target.nickname;
        battleMessage.didMoveHit = true;
        float modifier = (/* targets modifier */ 1 /* weather modifier */ * 1 /* Gen 2 badge modifier */ * 1 /* Critical modifier */ * 1 
                        /* Random between 0.85 and 1.00 */ * Random.Range(0.85f, 1.0f)  /* STAB */ * (STAB ? 1.5f : 1.0f)
                         * typeEffectiveness /* Burn status effect */ /*(move.category == Move.Category.Physical && attacker.)*/ * 1.0f /* Other interactions */ * 1.0f);
        Debug.Log($"Damage modifier: {modifier.ToString()}");
        int damage = Mathf.FloorToInt((((2 * attacker.level / 5 + 2) * (attacker.species.type1 == move.type || attacker.species.type2 == move.type ? 1.5f : 1.0f / 50) + 2) * modifier));
        Debug.Log($"Total damage dealt: {damage.ToString()} ");
        ui.messageUIClass.DisplayBattleMessage(battleMessage);
        target.TakeDamage(damage);
    }




}
