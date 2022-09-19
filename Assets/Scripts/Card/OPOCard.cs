using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Characters;
using mDEV.Manager;

namespace mDEV.Cards
{
    public class OPOCard : Card
    {
        Character orderedChar;
        public override void Effect()
        {
            base.Effect();
            StopAllCoroutines();
            StartCoroutine(OnePlusOne());
            orderedChar = GameManager.Instance.curPlayingCharacter;
        }

        public IEnumerator OnePlusOne()
        {
            canUse = false;
            while (true)
            {
                yield return null;
                if (orderedChar.LastCard.cardType == StatusType.ATTACK)
                {
                    orderedChar.LastCard.GetComponent<AttackCard>().Attack(orderedChar.LastCard.cardInfo.value);
                    canUse = true;
                    break;
                }


            }
        }
    }
}
