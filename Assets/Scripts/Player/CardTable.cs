using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;
using mDEV.Manager;

namespace mDEV.Characters
{
    public class CardTable : MonoBehaviour
    {
        Card[] cards;

        private void Awake()
        {
        }

        private void Start()
        {
            cards = DataManager.Instance.cardList;
        }
    }
}
