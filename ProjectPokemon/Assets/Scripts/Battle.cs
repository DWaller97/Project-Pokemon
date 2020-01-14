using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battle : MonoBehaviour
{

    GameObject fightUI;

    Pokemon yourPokemon, enemyPokemon;
    bool attacking = false, yourTurn = false;

    void ShowHUD(bool show){
        fightUI.SetActive(show);
    }


    void Update()
    {



        if(!yourTurn){
            ShowHUD(true);
            AITurn();
        }
        else{
            ShowHUD(false);
            YourTurn();
        }
    }

    IEnumerator AITurn(){
        return null;
    }

    IEnumerator YourTurn(){
        return null;
    }
}
