using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;
using mDEV.Extensions;
using mDEV.Cards;

namespace mDEV.Characters
{
    public delegate void AttackDelegate(int value);
    public class Character : MonoBehaviour
    {
        public Card[] myCards;

        public AttackDelegate CheckAttack;

        [field: SerializeField] public Card LastCard { get; private set; }
        public int maxMp { get; private set; }
        public int curMp;

        public bool isPlaying;

        protected virtual void Start()
        {
            maxMp = GameManager.Instance.MaxMP;
            curMp = maxMp;
            myCards = new Card[GameManager.Instance.cardCount];
        }

        public void SetLastCard(Card lastCard)
        {
            LastCard = lastCard;
        }


        public void ChangeTurn()
        {
            GameManager.Instance.ChangeTurn(this);
        }

        public virtual void StartTurn(int recoverMp)
        {
            curMp += recoverMp;
            if (maxMp < curMp)
                curMp = maxMp;

        }

        public virtual void EndTurn()
        {
            isPlaying = false;
        }

        public virtual void Dead()
        {
            GameManager.Instance.RemoveCharacter(this);
            GameManager.Instance.ChangeTurnDead();

        }


    }
}