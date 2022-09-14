using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mDEV.Cards
{
    [CreateAssetMenu(menuName = "Card", fileName = "Card")]
    public class CardInfo : ScriptableObject
    {
        public string cardName;

        public string description;

        public int cost;

        public Sprite cardSprite;
    }
}
