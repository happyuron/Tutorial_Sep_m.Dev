using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;

namespace mDEV.Cards
{
    public class Card : MonoBehaviour
    {
        public int cost;

        public CardInfo cardInfo;

        public RectTransform rectTr;

        private Vector3 defaultPos;


        protected virtual void Awake()
        {
            rectTr = GetComponent<RectTransform>();
        }

        public virtual void Effect()
        {

        }

        public void SetDafaultPos(Vector3 newPos)
        {
            defaultPos = newPos;
        }

    }
}
