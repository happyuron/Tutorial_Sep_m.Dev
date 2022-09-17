using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;
using mDEV.Characters;

namespace mDEV.Cards
{
    public class Card : MonoBehaviour
    {
        public enum StatusType { ATTACK, DEFENSE, HEAL };

        public StatusType cardType;

        public int value;

        public int cost;

        public Character owner;

        public CardInfo cardInfo;

        public RectTransform rectTr;

        private Vector3 defaultPos;


        protected virtual void Awake()
        {
            rectTr = GetComponent<RectTransform>();
        }

        public virtual void Effect()
        {
            owner.curMp -= cost;
            Debug.Log("Card");
        }
    }
}
