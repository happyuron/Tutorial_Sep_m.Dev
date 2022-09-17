using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace mDEV.Characters
{
    public class AI : Character
    {
        protected override void Start()
        {
            base.Start();
            myCards = GetComponentsInChildren<Cards.Card>();
            for (int i = 0; i < myCards.Length; i++)
            {
                myCards[i].owner = this;
            }
        }
        public override void StartTurn(int recoverMp)
        {
            base.StartTurn(recoverMp);
            StartCoroutine(WaitASecond());
            Debug.Log("AI turn" + gameObject.name);
        }

        private IEnumerator WaitASecond()
        {
            yield return new WaitForSeconds(1);
            ChangeTurn();
        }


    }
}
