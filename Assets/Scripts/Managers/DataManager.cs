using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Cards;

namespace mDEV.Manager
{
    public class DataManager : Singleton<DataManager>
    {
        public Card[] cardList;



        public Card GetRandomCard()
        {
            int id = Random.Range(0, cardList.Length);

            return cardList[id];
        }
    }
}
