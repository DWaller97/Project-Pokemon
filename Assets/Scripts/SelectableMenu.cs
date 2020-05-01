using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI{
    public class SelectableMenu : Menu
    {
        public Dictionary<string, Button>  selectableOptions;
        private int selectedIndex = 0, maxIndex = 0;
        

        protected override void Awake(){
            selectable = true;
            base.Awake();
            selectableOptions = new Dictionary<string, Button>();
        }

        public virtual void OnEnterKeyPressed(){
        }   

        public virtual void OnUpKeyPressed(){

        }

        public virtual void OnDownKeyPressed(){
        }
        
    }
}