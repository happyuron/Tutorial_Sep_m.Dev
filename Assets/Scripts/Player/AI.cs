using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;
using mDEV.Manager;


namespace mDEV.Characters
{
    public class AI : Character
    {
        private int totalAttackDamage;

        private float attackWeight;

        private float defenseWeight;

        private float healWeight;

        public delegate void voidList();

        public delegate voidList TodoList();
        protected override void Start()
        {
            base.Start();

            for (int i = 0; i < GameManager.Instance.cardCount; i++)
            {
                myCards[i] = DataManager.Instance.GetRandomCard();
            }

        }
        public override void StartTurn(int recoverMp)
        {
            base.StartTurn(recoverMp);
            StartCoroutine(WaitingForSeconds(.2f));
            Debug.Log("AI turn" + gameObject.name);
            SetWeights();
        }

        public override void EndTurn()
        {
            base.EndTurn();
            totalAttackDamage = 0;
            attackWeight = 0;
            defenseWeight = 0;
            healWeight = 0;
        }

        private IEnumerator WaitingForSeconds(float time)
        {
            yield return new WaitForSeconds(time);
            ChangeTurn();
        }

        public override void Dead()
        {
            base.Dead();
            StopAllCoroutines();
        }

        public void SetWeights()
        {
            for (int i = 0; i < myCards.Length; i++)
            {
                if (myCards[i].cardType == Card.StatusType.ATTACK)
                    totalAttackDamage += myCards[i].cardInfo.value;
            }
            if (GameManager.Instance.Score > GameManager.Instance.MaxScore - totalAttackDamage)
            {

            }
        }



    }
}
