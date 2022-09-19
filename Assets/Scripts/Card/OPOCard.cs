using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Characters;
using mDEV.Manager;
using mDEV.Extensions;

namespace mDEV.Cards
{
    public class OPOCard : Card
    {
        [field: SerializeField] public bool[] CharacterList { get; set; }

        private void Start()
        {
            GameManager.Instance.deadDel += RemoveCharacter;
            CharacterList = new bool[4];
        }

        public void RemoveCharacter(int index)
        {
            for (int i = index; i < GameManager.Instance.Players.Length - 1; i++)
            {
                CharacterList[i] = CharacterList[i + 1];
            }
        }

        public override bool Effect()
        {
            if (!CharacterList[GameManager.Instance.PlayerIndex])
            {
                base.Effect();
                StartCoroutine(OnePlusOne(GameManager.Instance.curPlayingCharacter));
                return true;
            }
            return false;
        }

        public IEnumerator OnePlusOne(Character character)
        {
            CharacterList[GameManager.Instance.PlayerIndex] = true;
            while (true)
            {
                yield return null;
                if (character.LastCard.cardType == StatusType.ATTACK)
                {
                    character.LastCard.GetComponent<AttackCard>().Attack(character.LastCard.cardInfo.value);
                    CharacterList[GameManager.Instance.PlayerIndex] = false;
                    break;
                }


            }
            CharacterList[GameManager.Instance.PlayerIndex] = false;

        }
    }
}
