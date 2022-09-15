using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;

namespace mDEV.Ui
{
    public class CardUi : MonoBehaviour
    {
        public RectTransform rectTr;

        private Vector3 defaultPos;

        public Card card;
        private void Awake()
        {
            rectTr = GetComponent<RectTransform>();
        }

        public void SetDafaultPos(Vector3 newPos)
        {
            defaultPos = newPos;
        }

    }
}
