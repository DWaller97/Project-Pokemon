using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI ui;
    public BattleUI battleUIClass;
    public MessageUI messageUIClass;
    // public MoveUI moveUIClass;

    public GameObject buttonTemplate;

    public GameObject battleUI, 
    mainMenuUI, messageUI, moveUI;
    public GameObject selector;
    public Transform[] buttonAnchors;
    public List<GameObject> displayedButtons = new List<GameObject>();
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
        // moveUIClass = moveUI.GetComponent<MoveUI>();
        MoveButtonObjectsFromState();
    }

    void Update()
    {
        buttonDelay -= Time.deltaTime;
        ChangeButtonIndex();
        ChangeMenuState();
    }

    void ChangeMenuState(){
        if(Input.GetButtonDown("Submit")){
            switch(currBattleState){
                case BattleState.MainMenu:
                    GameObject button = displayedButtons[buttonIndex];
                    if(button.name == "Fight Button"){
                        currBattleState = BattleState.MoveMenu;
                    }else if(button.name == "Pokemon Button"){
                        currBattleState = BattleState.PokemonMenu;
                    }else if(button.name == "Bag Button"){
                        currBattleState = BattleState.BagMenu;
                    }else if(button.name == "Run Button"){
                        Debug.LogWarning("Run doesn't exist yet");
                    }else{
                        return;
                    }
                    break;
                case BattleState.MoveMenu:
                    Move moveUsed;
                    GameManager gm = GameManager.GetGameManager();
                    Pokemon pokemon = gm.playerTrainer.pokemon[0];
                    if(buttonIndex == 0)
                        moveUsed = pokemon.move1;
                    else if(buttonIndex == 1)
                        moveUsed = pokemon.move2;
                    else if(buttonIndex == 2)
                        moveUsed = pokemon.move3;
                    else if(buttonIndex == 3)
                        moveUsed = pokemon.move4;
                    else{
                        Debug.LogError($"Invalid button index: {buttonIndex}");
                        break;
                    }
                    //GameManager.trainer.pokemon[0].TakeDamage()
                break;
            
            }
            
            MoveButtonObjectsFromState();
        }
    }

    void MoveButtonObjectsFromState(){
        switch(currBattleState){
            case BattleState.MainMenu:
                CopyButtonsToArray(mainButtons);
                SetUIInactive();
                mainMenuUI.SetActive(true);
                break;
            case BattleState.BagMenu:
                break;
            case BattleState.MoveMenu:
                CopyButtonsToArray(moveButtons);
                SetUIInactive();
                SetMoveMenu();
                moveUI.SetActive(true);
                break;
            case BattleState.PokemonMenu:
                break;
        }
    }

    void SetMoveMenu(){
        Pokemon pokemon = GameManager.GetGameManager().playerTrainer.pokemon[0];
        displayedButtons[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = pokemon.move1.name;
        displayedButtons[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = pokemon.move2.name;
        displayedButtons[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = pokemon.move3.name;
        displayedButtons[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = pokemon.move4.name;

    }
    public void CopyButtonsToArray(GameObject[] source){
        displayedButtons.Clear();
        displayedButtons.AddRange(source);
        SetUIInactive();
        foreach(GameObject obj in source){
            obj.SetActive(true);
        }
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
        mainMenuUI.SetActive(false);
        messageUI.SetActive(false);
        moveUI.SetActive(false);
    }

}
