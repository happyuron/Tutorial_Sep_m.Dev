using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mDEV.Cards
{
    public class RecoverMp : Card
    {
        public override void Effect()
        {
            base.Effect();
            owner.curMp += cardInfo.value;
        }
    }
}
