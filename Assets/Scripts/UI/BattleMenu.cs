using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Scripts.UI{


    public class BattleMenu : SelectableMenu
    {
        public GameObject cursorObject;
        protected override void Awake(){
            base.Awake();
        }

        private void Start() {
        }
        public override void OnUpKeyPressed(){
            base.OnUpKeyPressed();
            cursorObject.transform.position = buttons[selectedIndex].transform.position + new Vector3(-205.79f, -15f, 0);
        }

        public override void OnDownKeyPressed(){
            base.OnDownKeyPressed();
            cursorObject.transform.position = buttons[selectedIndex].transform.position + new Vector3(-205.79f, -15, 0);


            
        }

    }

}