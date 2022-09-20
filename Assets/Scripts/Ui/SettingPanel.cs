using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mDEV
{
    public class SettingPanel : MonoBehaviour
    {
        public Button continueButton;
        public Button quitButton;



        public void Active(bool value)
        {
            gameObject.SetActive(value);

        }
        public void Continue()
        {
            Active(false);
        }

        public void ShowSettingPanel()
        {
            Active(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
