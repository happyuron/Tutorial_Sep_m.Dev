using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;

namespace mDEV.Characters
{
    public class Player : Character
    {
        protected override void Start()
        {
            base.Start();
            myCards = DataManager.Instance.cardList;
            for (int i = 0; i < myCards.Length; i++)
            {
                myCards[i].owner = this;
            }
        }

        public override void StartTurn(int recoverMp)
        {
            base.StartTurn(recoverMp);
            UiManager.Instance.SetActiveCardUi();
        }
    }
}