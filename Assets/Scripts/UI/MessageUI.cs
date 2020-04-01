using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textBox;
    public void DisplayMessage(string message){
        textBox.text = message;
    }

    public void DisplayBattleMessage(BattleMessage message){
        string effectMessage = GetEffectivenessString(message.attackEffectiveness);
        if(effectMessage == ""){
            effectMessage = "!";
        }
        else{
            effectMessage.Insert(0, ",\n");
        }
        textBox.text = $"{message.attackerName} used {message.moveUsed}{effectMessage}";
    }

    public string GetEffectivenessString(BattleManager.AttackEffectiveness effectiveness){
        switch(effectiveness){
            case BattleManager.AttackEffectiveness.NoEffect:
                return "It had no effect!";
            case BattleManager.AttackEffectiveness.NotVeryEffective:
                return "It was not very effective....";
            case BattleManager.AttackEffectiveness.SuperEffective:
                return "It was super effective!";
            default:
                return "";
        }
    }
    public struct BattleMessage{
        
        public string attackerName, targetName;
        public string moveUsed;
        public bool didMoveHit, wasMoveCritical;
        public BattleManager.AttackEffectiveness attackEffectiveness;

    }


    //TODO: Make a coroutine with text delayed rather than just appear.
}
