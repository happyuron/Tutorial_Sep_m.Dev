using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Characters;

namespace mDEV.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private int playerIndex;

        [SerializeField] public int recoverMp;

        public Character[] players;

        [field: SerializeField] public Character curPlayingCharacter { get; private set; }

        private void Start()
        {
            players = FindObjectsOfType<Character>();
            playerIndex = Random.Range(0, players.Length);
            curPlayingCharacter = players[playerIndex];
            curPlayingCharacter.StartTurn(recoverMp);
        }

        public void ChangeTurn(Character ordered)
        {
            if (ordered == curPlayingCharacter)
            {
                curPlayingCharacter.isPlaying = false;
                curPlayingCharacter.EndTurn();
                playerIndex = playerIndex >= players.Length - 1 ? 0 : 1 + playerIndex;
                curPlayingCharacter = players[playerIndex];
                curPlayingCharacter.isPlaying = true;
                curPlayingCharacter.StartTurn(recoverMp);
            }
        }

    }
}
