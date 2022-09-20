using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;
using mDEV.Extensions;
using mDEV.Cards;
using mDEV.Ui;

namespace mDEV.Characters
{
    public class Character : MonoBehaviour
    {
        private SpriteRenderer sprite;
        public ManaBar myMpBar;
        public Card[] myCards;

        public SpriteRenderer lastCardSprite;

        [field: SerializeField] public Card LastCard { get; private set; }
        public int MaxMp { get; private set; }

        private int curMp;
        public int CurMp
        {
            get
            {
                return curMp;
            }
            set
            {
                curMp = value;
                if (myMpBar != null)
                {
                    myMpBar.SetMpBar(curMp, MaxMp);
                }
            }
        }

        public bool isPlaying;

        protected virtual void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        protected virtual void Start()
        {
            sprite.color = new Color(1, 1, 1, .5f);
            myCards = new Card[GameManager.Instance.cardCount];
            MaxMp = GameManager.Instance.MaxMP;
            CurMp = MaxMp;

        }

        public void SetLastCard(Card lastCard)
        {
            LastCard = lastCard;
            lastCardSprite.sprite = LastCard.cardInfo.cardSprite;
        }



        public void ChangeTurn()
        {
            GameManager.Instance.ChangeTurn(this);
        }

        public virtual void StartTurn(int recoverMp)
        {
            sprite.color = new Color(1, 1, 1, 1);
            CurMp += recoverMp;
            if (MaxMp < CurMp)
                CurMp = MaxMp;

        }

        public virtual void EndTurn()
        {
            sprite.color = new Color(1, 1, 1, .5f);
            lastCardSprite.sprite = null;
            isPlaying = false;
        }

        public virtual void Dead()
        {
            GameManager.Instance.RemoveCharacter(this);
            GameManager.Instance.ChangeTurnDead();
            myMpBar.gameObject.SetActive(false);

        }


    }
}