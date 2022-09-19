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

        private int[] CardRoot { get; set; }

        private List<int> CardRootTmp = new List<int>();

        private int totalAttackDamage;


        private List<Card> aiCardTable = new List<Card>();


        public delegate void voidList();

        public delegate voidList TodoList();

        protected override void Awake()
        {
            base.Awake();
        }


        protected override void Start()
        {
            base.Start();
            SearchTable = new bool[myCards.Length];
            CardRoot = new int[myCards.Length];
            for (int i = 0; i < GameManager.Instance.cardCount; i++)
            {
                myCards[i] = DataManager.Instance.GetRandomCard();
            }

        }
        public override void StartTurn(int recoverMp)
        {
            base.StartTurn(recoverMp);
            Debug.Log("AI turn" + gameObject.name);
            ComplexAI();
        }

        public override void EndTurn()
        {
            base.EndTurn();
            totalAttackDamage = 0;
        }

        public void ComplexAI()
        {
            SetWeights();
            StartCoroutine(PlayComplexAI(WaitingTime));
        }

        public void SimpleAI()
        {
            StartCoroutine(WaitingForSeconds(WaitingTime));
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
                if (CardRoot[i] < myCards.Length && curMp >= myCards[i].cardInfo.cost)
                {
                    Debug.Log(gameObject.name + " " + myCards[CardRoot[i]].gameObject.name);

                    myCards[CardRoot[i]].Effect();

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
            Debug.Log(gameObject.name + myCards.Length);
            FindHugeDamage(curMp, 0);
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
                        CardRoot = new int[CardRootTmp.Count];
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
