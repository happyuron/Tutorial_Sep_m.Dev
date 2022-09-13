using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;

namespace mDEV.Manager
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] private GameObject parentGameObject;


        private void Start()
        {
            MakeCardUi(DataManager.Instance.cardList);
        }

        public void MakeCardUi(Card[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Card tmp = Instantiate(GameManager.Instance.CardResource).GetComponent<Card>();
                tmp.transform.parent = parentGameObject.transform;

            }
        }
    }
}
