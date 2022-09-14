using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;

namespace mDEV.Manager
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] private RectTransform parentGameObject;


        private void Start()
        {
            MakeCardUi(DataManager.Instance.cardList);
        }

        public void MakeCardUi(Card[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Card tmp = Instantiate(GameManager.Instance.CardResource).GetComponent<Card>();
                tmp.transform.SetParent(parentGameObject.transform);
                CalRectWide(parentGameObject, tmp.rectTr, i, list.Length);
                tmp.SetDafaultPos(tmp.rectTr.localPosition);
            }
        }

        public Vector3 CalRectWide(RectTransform baseTr, RectTransform tr, int count, int length)
        {

            tr.localPosition = new Vector3((float)parentGameObject.rect.width * count / length - (parentGameObject.rect.width / 2) +
                tr.rect.width / 2, 0);

            return tr.localPosition;
        }
    }
}
