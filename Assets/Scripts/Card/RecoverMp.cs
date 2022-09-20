using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Manager;

namespace mDEV.Cards
{
    public class RecoverMp : Card
    {
        public override bool Effect()
        {
            base.Effect();
            GameManager.Instance.curPlayingCharacter.CurMp += cardInfo.value;
            if (GameManager.Instance.curPlayingCharacter.CurMp > GameManager.Instance.MaxMP)
                GameManager.Instance.curPlayingCharacter.CurMp = GameManager.Instance.MaxMP;
            return true;
        }
    }
}
