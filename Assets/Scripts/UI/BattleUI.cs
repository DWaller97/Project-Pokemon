using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleUI : MonoBehaviour
{
        //Battle UI references
    public TMPro.TextMeshProUGUI allyPokemonNameText, enemyPokemonNameText, allyLevelText, enemyLevelText, allyHealthText;
    public Slider allyHealthSlider, enemyHealthSlider, expSlider;
    int allyLvl, allyHP, allyMaxHP, enemyLvl, enemyHP, enemyMaxHP, exp; 
    string allyPokemonNickname, enemyPokemonNickname;


    public void CacheUIValues(Pokemon allyPokemon, Pokemon enemyPokemon){
        allyLvl = allyPokemon.level;
        allyHP = allyPokemon.currHP;
        allyMaxHP = allyPokemon.maxHP;
        allyPokemonNickname = allyPokemon.nickname == "" ? allyPokemon.species.name : allyPokemon.nickname;
        //Exp
        enemyLvl = enemyPokemon.level;
        enemyHP = enemyPokemon.currHP;
        enemyMaxHP = enemyPokemon.maxHP;
        enemyPokemonNickname = enemyPokemon.nickname == "" ? enemyPokemon.species.name : enemyPokemon.nickname;
        UpdateUI();
    }

    public void UpdateUI(){
        allyPokemonNameText.text = allyPokemonNickname;
        enemyPokemonNameText.text = enemyPokemonNickname;
        allyLevelText.text = $"Lv. {allyLvl}";
        enemyLevelText.text = $"Lv. {enemyLvl}";
        allyHealthText.text = $"{allyHP}/{allyMaxHP}";
        allyHealthSlider.value = ((float)allyHP / (float)allyMaxHP);
        enemyHealthSlider.value = ((float)enemyHP / (float)enemyMaxHP);
        //Exp
    }



}
