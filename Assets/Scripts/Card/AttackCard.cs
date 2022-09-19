using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;

namespace mDEV.Cards
{
    public class AttackCard : Card
    {
        public override void Effect()
        {

            base.Effect();
            Attack(cardInfo.value);
        }

        public void Attack(int value)
        {
            GameManager.Instance.UpdateScore(value);

        }
    }
}
