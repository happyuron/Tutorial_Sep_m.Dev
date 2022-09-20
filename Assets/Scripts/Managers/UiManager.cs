using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using mDEV.Cards;
using mDEV.Ui;
using TMPro;

namespace mDEV.Manager
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] private RectTransform parentGameObject;

        public CardUi[] cardUis;

        public Image DefeatUi;

        public Image WinUi;

        public TextMeshProUGUI scoreText;

        protected override void Awake()
        {
            base.Awake();
            cardUis = new CardUi[GameManager.Instance.cardCount];

        }

        public void MakeCardUi(Card[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                CardUi tmp = Instantiate(GameManager.Instance.CardResource).GetComponent<CardUi>();
                tmp.transform.SetParent(parentGameObject.transform);
                CalRectWide(parentGameObject, tmp.rectTr, i, list.Length);
                tmp.SetDafaultPos(tmp.rectTr.position);
                tmp.SetCard(list[i]);
                cardUis[i] = tmp;
            }
        }

        public Vector3 CalRectWide(RectTransform baseTr, RectTransform tr, int count, int length)
        {

            tr.localPosition = new Vector3((float)parentGameObject.rect.width * count / length - (parentGameObject.rect.width / 2) +
                tr.rect.width / 2, 0);

            return tr.localPosition;
        }

        public void SetActiveCardUi()
        {
            for (int i = 0; i < cardUis.Length; i++)
            {
                cardUis[i].SetActive(true);
            }
        }

        public void Defeated()
        {
            DefeatUi.gameObject.SetActive(true);
        }
        public void Win()
        {
            WinUi.gameObject.SetActive(true);

        }
    }
}
