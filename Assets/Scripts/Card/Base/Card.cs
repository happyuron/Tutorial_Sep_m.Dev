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

        public CardInfo cardInfo;

        public RectTransform rectTr;

        public bool canUse = true;

        protected virtual void Awake()
        {
            rectTr = GetComponent<RectTransform>();
        }

        public virtual bool Effect()
        {
            if (cardInfo.cost <= GameManager.Instance.curPlayingCharacter.CurMp && canUse)
            {
                GameManager.Instance.curPlayingCharacter.SetLastCard(this);
                GameManager.Instance.curPlayingCharacter.CurMp -= cardInfo.cost;
                return true;
            }
            return false;
        }
    }
}
