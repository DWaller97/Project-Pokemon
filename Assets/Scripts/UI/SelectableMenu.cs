using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI{
    public class SelectableMenu : Menu
    {
        public Dictionary<string, Button>  selectableOptions;
        public List<Button> buttons;
        protected int selectedIndex = 0, maxIndex = 0;
        

        protected override void Awake(){
            maxIndex = buttons.Count;
            selectable = true;
            base.Awake();
        }

        public virtual void OnEnterKeyPressed(){
            buttons[selectedIndex].Select();
        }   

        public virtual void OnUpKeyPressed(){
            if(selectedIndex - 1 >= 0)
                selectedIndex--;
            else
                selectedIndex = maxIndex - 1;
        }

        public virtual void OnDownKeyPressed(){
            if(selectedIndex + 1 < maxIndex)
                selectedIndex++;
            else
                selectedIndex = 0;
        }
        
    }
}