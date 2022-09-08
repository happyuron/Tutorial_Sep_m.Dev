using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mDEV.Characters
{
    public class AI : Character
    {

        public override void StartTurn(int recoverMp)
        {
            base.StartTurn(recoverMp);
            ChangeTurn();
            Debug.Log("AI turn" + gameObject.name);
        }
    }
}
