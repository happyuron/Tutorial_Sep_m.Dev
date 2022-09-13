using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;
using mDEV.Extensions;

namespace mDEV.Characters
{
    public class Character : MonoBehaviour
    {
        public int maxMp { get; private set; }
        public int curMp;

        public bool isPlaying;

        protected virtual void Start()
        {
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

        public void Dead()
        {
            GameManager.Instance.RemoveCharacter(this);

        }


    }
}