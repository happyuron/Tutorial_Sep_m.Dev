using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace mDEV.Ui
{
    public class ManaBar : MonoBehaviour
    {
        private Slider mpBar;

        private TextMeshProUGUI text;

        private void Awake()
        {
            mpBar = GetComponent<Slider>();
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetMpBar(int value, int max)
        {
            float tmp = (float)value / max;
            mpBar.value = tmp;
            text.text = value.ToString() + " / " + max.ToString();
        }
    }
}
