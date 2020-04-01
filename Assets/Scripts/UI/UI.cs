using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI ui;
    public BattleUI battleUIClass;
    public MessageUI messageUIClass;
    public MoveUI moveUIClass;

    public GameObject battleUI, messageUI, moveUI;
    public GameObject selector;
    public Transform[] buttonAnchors;
    public GameObject[] displayedButtons;
    public GameObject[] mainButtons;
    public GameObject[] moveButtons;




    int buttonIndex = 0;
    float buttonDelay = 0.2f;

    public static UI GetInstance(){
        return ui;
    }

    public enum BattleState{
        MainMenu,
        MoveMenu,
        BagMenu,
        PokemonMenu
    };

    public BattleState currBattleState = BattleState.MainMenu;
    bool stateChanged = true;
    private void Awake() {
        ui = this;
        battleUIClass = battleUI.GetComponent<BattleUI>();
        messageUIClass = messageUI.GetComponent<MessageUI>();
        moveUIClass = moveUI.GetComponent<MoveUI>();
    }

    void Update()
    {
        buttonDelay -= Time.deltaTime;
        //UpdateMenuState();
        ChangeButtonIndex();
    }

    //TODO: Maybe switch out the buttons based on what state we're in then displaying them.
    void ChangeButtonIndex(){
        float vert = Input.GetAxisRaw("Vertical");
        int indexMovement = (int)vert;
        if((int)indexMovement != 0 && buttonDelay <= 0){
            displayedButtons[buttonIndex].transform.localScale = Vector3.one;
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
        displayedButtons[buttonIndex].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public Button GetCurrentButton(){
        return displayedButtons[buttonIndex].GetComponent<Button>();
    }

   public void SetUIInactive(){
        messageUI.SetActive(false);
        //battleUI.SetActive(false);
        moveUI.SetActive(false);
    }

}
