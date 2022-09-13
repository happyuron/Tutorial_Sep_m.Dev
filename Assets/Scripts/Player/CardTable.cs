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
            cards = new Card[GameManager.Instance.cardMaxCount];
        }
    }
}
