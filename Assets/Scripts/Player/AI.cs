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

        private List<int> CardRoot = new List<int>();

        private List<int> CardRootTmp = new List<int>();

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
            SimpleAI();
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
                        CardRoot.Add(i);
                    }
                }
                Debug.Log(CardRoot.Count);
                tmp++;
            }
        }

        public IEnumerator PlayAI(float time)
        {
            for (int i = 0; i < CardRoot.Count; i++)
            {
                yield return new WaitForSeconds(time / 2);
                if (CardRoot[i] < myCards.Length)
                {
                    if (CurMp >= myCards[CardRoot[i]].cardInfo.cost)
                    {
                        Debug.Log(gameObject.name + " " + myCards[CardRoot[i]].gameObject.name);

                        myCards[CardRoot[i]].Effect();

                    }

                }
            }
            ChangeTurn();
        }

        public override void Dead()
        {
            base.Dead();
            StopAllCoroutines();
        }

        public void SetWeights()
        {
            FindHugeDamage(CurMp, 0);
        }

        public int FindHugeDamage(int mp, int count)
        {
            bool isChanged = false;
            int index = 0;
            for (int j = 0; j < myCards.Length; j++)
            {
                if (myCards[j].cardInfo.cost <= mp && !SearchTable[j])
                {
                    isChanged = true;
                    CardRootTmp.Add(j);
                    index = j;
                    SearchTable[j] = true;
                    int tmp = FindHugeDamage(mp - myCards[j].cardInfo.cost, count + 1);
                    tmp += myCards[j].cardType == Card.StatusType.ATTACK ? myCards[j].cardInfo.value : 0;
                    if (tmp > totalAttackDamage)
                    {
                        CardRoot.Clear();
                        for (int i = 0; i < CardRootTmp.Count; i++)
                        {
                            CardRoot[i] = CardRootTmp[i];
                        }
                    }
                    CardRootTmp.RemoveAt(CardRootTmp.Count - 1);
                }
            }
            if (myCards[index].cardType == Card.StatusType.ATTACK && isChanged)
                return myCards[index].cardInfo.value;
            else
                return 0;
        }



    }
}
