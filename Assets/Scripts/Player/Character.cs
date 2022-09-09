using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;

namespace mDEV.Characters
{
    public class Character : MonoBehaviour
    {
        public bool isPlaying;
        [field: SerializeField] public int maxMp { get; private set; }
        public int curMp;

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

        }

        public void Dead()
        {

        }



    }
}