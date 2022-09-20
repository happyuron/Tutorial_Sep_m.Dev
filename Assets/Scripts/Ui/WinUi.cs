using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace mDEV
{
    public class WinUi : MonoBehaviour
    {
        public void Continue()
        {
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
