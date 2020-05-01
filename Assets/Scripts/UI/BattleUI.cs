using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleUI : MonoBehaviour
{
    public GameObject selector;
    public Transform[] buttonAnchors;
    public GameObject[] buttons;
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

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        buttonDelay -= Time.deltaTime;
        ChangeButtonIndex();
    }
    
    int buttonIndex = 0;
    float buttonDelay = 0.2f;
    void ChangeButtonIndex(){
        float vert = Input.GetAxisRaw("Vertical");
        int indexMovement = (int)vert;
        if((int)indexMovement != 0 && buttonDelay <= 0){
            buttons[buttonIndex].transform.localScale = Vector3.one;
            buttonDelay = 0.2f;
            
            if(indexMovement >= 0){
                if(buttonIndex == 0){
                    buttonIndex = 3;
                }
                else
                    buttonIndex--;
            }
            if(indexMovement < 0){
                if(buttonIndex >= 3){
                    buttonIndex = 0;
                }
                else
                    buttonIndex++;
            }
        }
        selector.transform.position = buttonAnchors[buttonIndex].position;
        buttons[buttonIndex].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

    }

    public Button GetCurrentButton(){
        return buttons[buttonIndex].GetComponent<Button>();
    }
}
