using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;
using mDEV.Extensions;
using mDEV.Cards;

namespace mDEV.Characters
{
    public class Character : MonoBehaviour
    {
        public Card[] myCards;
        public int maxMp { get; private set; }
        public int curMp;

        public bool isPlaying;

        protected virtual void Start()
        {
            maxMp = GameManager.Instance.MaxMP;
            curMp = maxMp;

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