using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;

namespace mDEV.Cards
{
    public class RecoverMp : Card
    {
        public override void Effect()
        {
            base.Effect();
            GameManager.Instance.curPlayingCharacter.curMp += cardInfo.value;
        }
    }
}
