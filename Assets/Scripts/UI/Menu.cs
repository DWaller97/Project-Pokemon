using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.UI{
    public class Menu : MonoBehaviour
    {
        public static Menu instance;
        public bool persistent = false;
        public bool selectable = false;
        protected virtual void Awake() {
            instance = this;
        }

        protected virtual void OnDestroy() {
            instance = null;
        }

        protected virtual void OnEscapeKeyPressed(){
            MenuManager.instance.CloseMenu(this);
        }
    }
}