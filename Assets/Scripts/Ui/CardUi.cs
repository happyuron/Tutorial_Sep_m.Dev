using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;
using UnityEngine.UI;

namespace mDEV.Ui
{
    public class CardUi : MonoBehaviour
    {
        private Image cardImage;
        public RectTransform rectTr;

        public Vector3 DefaultPos { get; private set; }

        public Card card;
        private void Awake()
        {
            rectTr = GetComponent<RectTransform>();
            cardImage = GetComponent<Image>();
        }

        public void SetCard(Card value)
        {
            card = value;
            if (card != null)
            {
                cardImage.sprite = card.cardInfo.cardSprite;
            }
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
            SetActive(!card.Effect());
            SetPos(DefaultPos);
        }

    }
}
