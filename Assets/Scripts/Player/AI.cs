using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;
using mDEV.Manager;


namespace mDEV.Characters
{
    public class AI : Character
    {
        [field: SerializeField] public float WaitingTime;

        private bool[] SearchTable { get; set; }

        private Stack<int> CardRoot = new Stack<int>();

        private Stack<int> CardRootTmp = new Stack<int>();

        private int totalAttackDamage;
        protected override void Awake()
        {
            base.Awake();
        }


        protected override void Start()
        {
            base.Start();
            SearchTable = new bool[myCards.Length];
            for (int i = 0; i < GameManager.Instance.cardCount; i++)
            {
                myCards[i] = DataManager.Instance.GetRandomCard();
            }

        }
        public override void StartTurn(int recoverMp)
        {
            base.StartTurn(recoverMp);
            ComplexAI();
        }

        public override void EndTurn()
        {
            base.EndTurn();
            StopAllCoroutines();
            totalAttackDamage = 0;
            CardRoot.Clear();
        }

        public void ComplexAI()
        {
            SetWeights();
            StartCoroutine(PlayAI(WaitingTime));
        }

        public void SimpleAI()
        {
            SetSimpleAI();
            StartCoroutine(PlayAI(WaitingTime));
        }

        private void SetSimpleAI()
        {
            Card.StatusType tmp = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < myCards.Length; i++)
                {
                    if (myCards[i].cardType == tmp)
                    {
                        CardRoot.Push(i);
                    }
                }
                Debug.Log(CardRoot.Count);
                tmp++;
            }
        }

        public IEnumerator PlayAI(float time)
        {
            int tmp = 0;
            int count = CardRoot.Count;
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(time / 2);
                tmp = CardRoot.Pop();
                if (tmp < myCards.Length)
                {
                    if (CurMp >= myCards[tmp].cardInfo.cost)
                    {
                        Debug.Log(gameObject.name + " " + myCards[tmp].gameObject.name);
                        myCards[tmp].Effect();
                    }
                }
            }
            yield return new WaitForSeconds(time / 2);
            ChangeTurn();
        }

        public override void Dead()
        {
            base.Dead();
            StopAllCoroutines();
        }

        public void SetWeights()
        {
            FindHugeDamage(CurMp, 0, 0);
        }

        public int FindHugeDamage(int mp, int count, int rootDamage)
        {
            if (count >= myCards.Length)
                return 0;
            bool isChanged = false;
            int index = 0;
            int damage = 0;
            for (int j = 0; j < myCards.Length; j++)
            {
                if (myCards[j].cardInfo.cost <= mp && !SearchTable[j])
                {
                    isChanged = true;
                    CardRootTmp.Push(j);
                    index = j;
                    SearchTable[index] = true;
                    damage = myCards[index].cardType == Card.StatusType.ATTACK ? myCards[j].cardInfo.value : 0 + rootDamage;
                    FindHugeDamage(mp - myCards[index].cardInfo.cost, count + 1, damage);
                    if (damage > totalAttackDamage)
                    {
                        totalAttackDamage = damage;
                        CardRoot.Clear();
                        for (int i = 0; i < CardRootTmp.Count; i++)
                        {
                            CardRoot.Push(CardRootTmp.ToArray()[i]);
                        }
                    }
                    SearchTable[index] = false;
                    CardRootTmp.Pop();
                }
            }
            if (myCards[index].cardType == Card.StatusType.ATTACK && isChanged)
                return damage;
            else
                return 0;
        }



    }
}
