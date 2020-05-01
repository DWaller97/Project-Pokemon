using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.UI{
public class MenuManager : MonoBehaviour
{
        private Stack<Menu> menus, persistentMenus;
        private Stack<SelectableMenu> selectableMenus;
        public static MenuManager instance;
        [Header("Battle")]
        public SelectableMenu battleMenu;
        public Menu allyStats, enemyStats;
        public SelectableMenu moveMenu;
        private void Awake() {
            instance = this;
            menus = new Stack<Menu>();
            persistentMenus = new Stack<Menu>();
            selectableMenus = new Stack<SelectableMenu>();
            switch(GameManager.GetGameState()){
                case GameManager.GameState.Battle:
                    OpenSelectableMenu(battleMenu);
                    OpenPersistentMenu(allyStats);
                    OpenPersistentMenu(enemyStats);
                    break;
            }

        }

        private void Update() {
            foreach(SelectableMenu menu in menus){
                if(menu.selectable){
                    if(menu.gameObject.activeInHierarchy){ //Get rid of inactive gameobjects in the future to prevent input from closed menus.
                        if(Input.GetKeyDown(KeyCode.Return)){
                            menu.OnEnterKeyPressed();
                        }
                        if(Input.GetKeyDown(KeyCode.UpArrow)){
                            menu.OnUpKeyPressed();
                        }
                        if(Input.GetKeyDown(KeyCode.DownArrow)){
                            menu.OnDownKeyPressed();
                        }
                    }
                }
            }
        }
        private void OnDestroy() {
            instance = null;
        }
        public void OpenMenu(Menu menu){
            Menu newMenuInstance = Instantiate(menu, transform);
            newMenuInstance.gameObject.SetActive(true);
            if(menus.Count > 0)
                menus.Peek().gameObject.SetActive(false);
            menus.Push(newMenuInstance);
        }

        public void OpenPersistentMenu(Menu menu){
            Menu newMenuInstance = Instantiate(menu, transform);
            newMenuInstance.gameObject.SetActive(true);
            persistentMenus.Push(newMenuInstance);
        }

        public void OpenSelectableMenu(SelectableMenu menu){ //Almost a duplicate of OpenMenu
            SelectableMenu newMenuInstance = Instantiate(menu, transform);
            newMenuInstance.gameObject.SetActive(true);
            if(selectableMenus.Count > 0)
                selectableMenus.Peek().gameObject.SetActive(false);
            selectableMenus.Push(newMenuInstance);
        }
        public void CloseMenu(Menu menu){
            Destroy(menu.gameObject);
        }
    }
}
