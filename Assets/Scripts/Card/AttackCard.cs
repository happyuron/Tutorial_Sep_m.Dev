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
            GameManager.Instance.UpdateScore(value);
        }
    }
}
