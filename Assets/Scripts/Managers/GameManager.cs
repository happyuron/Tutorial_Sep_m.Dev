using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Characters;

namespace mDEV.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public Character[] players;

        public Character curPlayingCharacter { get; private set; }

        private void Start()
        {
            players = FindObjectsOfType<Character>();
            curPlayingCharacter = players[Random.Range(0, players.Length)];
        }

        public void ChangeTurn()
        {

        }

    }
}
