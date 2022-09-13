using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Characters;
using TMPro;
using mDEV.Extensions;

namespace mDEV.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private int playerIndex;

        [SerializeField] public int recoverMp;

        [field: SerializeField] public Character[] Players { get; private set; }

        [field: SerializeField] public int MaxScore { get; private set; }

        [field: SerializeField] public int cardMaxCount { get; private set; }

        public int Score { get; private set; }



        public TextMeshProUGUI scoreText;

        [field: SerializeField] public Character curPlayingCharacter { get; private set; }

        private void Start()
        {
            Players = FindObjectsOfType<Character>();
            playerIndex = Random.Range(0, Players.Length);
            curPlayingCharacter = Players[playerIndex];
            curPlayingCharacter.StartTurn(recoverMp);
            UpdateScore();
        }

        public void ChangeTurn(Character ordered)
        {
            if (ordered == curPlayingCharacter)
            {
                curPlayingCharacter.EndTurn();
                playerIndex = playerIndex >= Players.Length - 1 ? 0 : 1 + playerIndex;
                curPlayingCharacter = Players[playerIndex];
                UpdateScore(1);
                curPlayingCharacter.isPlaying = true;
                curPlayingCharacter.StartTurn(recoverMp);
            }
        }

        public void UpdateScore(int value)
        {
            Score += value;
            if (Score >= MaxScore)
            {
                curPlayingCharacter.Dead();
                Score = 0;
            }
            scoreText.text = Score.ToString();
        }

        public void UpdateScore()
        {
            scoreText.text = Score.ToString();
        }

        public void RemoveCharacter(Character target)
        {
            Players = Players.Remove(target);
        }


    }
}
