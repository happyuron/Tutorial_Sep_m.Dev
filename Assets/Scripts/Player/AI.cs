using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;
using mDEV.Manager;


namespace mDEV.Characters
{
    public class AI : Character
    {
        private int damage;

        private bool[] SearchTable { get; set; }

        private int[] CardRoot { get; set; }

        private int[] CardRootTmp { get; set; }

        private int totalAttackDamage;

        private float attackWeight;

        private float defenseWeight;

        private float healWeight;
        private List<Card> aiCardTable = new List<Card>();


        public delegate void voidList();

        public delegate voidList TodoList();
        protected override void Start()
        {
            base.Start();
            SearchTable = new bool[myCards.Length];
            CardRoot = new int[myCards.Length];
            CardRootTmp = new int[myCards.Length];

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
            ComplexAI();
        }

        public override void EndTurn()
        {
            base.EndTurn();
            totalAttackDamage = 0;
            attackWeight = 0;
            defenseWeight = 0;
            healWeight = 0;
        }

        public void ComplexAI()
        {
            SetWeights();
            PlayComplexAI(.2f);
        }

        public void SimpleAI()
        {
            StartCoroutine(WaitingForSeconds(.2f));
        }

        private IEnumerator WaitingForSeconds(float time)
        {
            for (int i = 0; i < myCards.Length; i++)
            {
                yield return new WaitForSeconds(time);
                myCards[i].Effect();
            }
            ChangeTurn();
        }

        public IEnumerator PlayComplexAI(float time)
        {
            for (int i = 0; i < CardRoot.Length; i++)
            {
                yield return new WaitForSeconds(time);
                myCards[CardRoot[i]].Effect();
            }
        }

        public override void Dead()
        {
            base.Dead();
            StopAllCoroutines();
        }

        public void SetWeights()
        {
            FindHugeDamage(myCards.Length - 1, curMp, 0);
        }

        public int FindHugeDamage(int index, int mp, int count)
        {
            if (index <= 0)
            {

                if (myCards[index].cardType == Card.StatusType.ATTACK)
                    return myCards[index].cardInfo.value;
                else
                    return 0;
            }

            while (index > 0)
            {
                if (myCards[index].cardInfo.cost <= mp && !SearchTable[index])
                {
                    CardRootTmp[count] = index;
                    SearchTable[index] = true;
                    int tmp = FindHugeDamage(index - 1, mp - myCards[index].cardInfo.cost, count + 1);
                    if (tmp > totalAttackDamage)
                    {
                        for (int i = 0; i < myCards.Length; i++)
                        {
                            CardRoot[i] = CardRootTmp[i];
                        }
                    }
                }
                SearchTable[index] = false;
                index--;
            }
            if (myCards[index].cardType == Card.StatusType.ATTACK)
                return myCards[index].cardInfo.value;
            else
                return 0;
        }



    }
}
