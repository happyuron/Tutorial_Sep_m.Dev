using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;

namespace mDEV.Ui
{
    public class CardUi : MonoBehaviour
    {
        public RectTransform rectTr;

        public Vector3 DefaultPos { get; private set; }

        public Card card;
        private void Awake()
        {
            rectTr = GetComponent<RectTransform>();
        }

        public void SetDafaultPos(Vector3 newPos)
        {
            DefaultPos = newPos;
        }

        public void SetPos(Vector3 pos)
        {
            transform.position = pos;
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void ShowMyCard()
        {
            card.Effect();
            SetActive(false);
        }

    }
}
