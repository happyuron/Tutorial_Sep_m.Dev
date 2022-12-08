using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mDEV.Characters;
using mDEV.Extensions;

namespace mDEV.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private AudioSource source;
        [SerializeField] private AudioClip cardFlipSFX;
        public delegate void PlayerDeadDel(int index);

        public PlayerDeadDel deadDel;
        [SerializeField] public int PlayerIndex { get; private set; }

        [field: SerializeField] public int MaxMP { get; private set; }

        public GameObject CardResource { get; private set; }

        [SerializeField] public int recoverMp;

        [field: SerializeField] public Character[] Players { get; private set; }

        [field: SerializeField] public int MaxScore { get; private set; }

        public int Score { get; private set; }

        public int cardCount;





        [field: SerializeField] public Character curPlayingCharacter { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            CardResource = Resources.Load<GameObject>("Prefebs/Card");
            if (cardFlipSFX == null)
                cardFlipSFX = Resources.Load<AudioClip>("Sound/CardFlipSFX");
        }


        private void Start()
        {
            Score = MaxScore;
            StartCoroutine(WaitForFuckingStartFuc());
            source = FindObjectOfType<AudioSource>();
            UpdateScore();

        }

        public IEnumerator WaitForFuckingStartFuc()
        {
            yield return new WaitForSeconds(1);
            Players = FindObjectsOfType<Character>();
            PlayerIndex = Random.Range(0, Players.Length);
            curPlayingCharacter = Players[PlayerIndex];
            curPlayingCharacter.StartTurn(recoverMp);
        }

        public void ChangeTurn(Character ordered)
        {
            if (ordered == curPlayingCharacter)
            {
                curPlayingCharacter.EndTurn();
                PlayerIndex = PlayerIndex >= Players.Length - 1 ? 0 : 1 + PlayerIndex;
                curPlayingCharacter = Players[PlayerIndex];
                UpdateScore(1);
                curPlayingCharacter.isPlaying = true;
                curPlayingCharacter.StartTurn(recoverMp);
            }
        }

        public void ChangeTurnDead()
        {
            curPlayingCharacter = Players[PlayerIndex];
            curPlayingCharacter.StartTurn(recoverMp);
            deadDel(PlayerIndex);
        }

        public void UpdateScore(int value)
        {
            Score -= value;
            if (Score <= 0)
            {
                curPlayingCharacter.Dead();
                Score = MaxScore;
            }
            UiManager.Instance.scoreText.text = Score.ToString();
        }

        public void MakeCardFlipSound()
        {
            MakeSound(cardFlipSFX);
        }

        public void MakeSound(AudioClip _clip)
        {
            source.PlayOneShot(_clip);
        }

        public void UpdateScore()
        {
            UiManager.Instance.scoreText.text = Score.ToString();
        }

        public void RemoveCharacter(Character target)
        {

            Players = Players.Remove(target);
            PlayerIndex = PlayerIndex >= Players.Length ? 0 : PlayerIndex;
            if (Players.Length == 1)
            {
                GameEnd(Players[0]);
            }
        }

        public void GameEnd(Character character)
        {
            if (character.GetComponent<Player>())
            {
                UiManager.Instance.Win();
            }
            else
            {
                character.StopAllCoroutines();
            }
        }
        public void Defeated()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                Players[i].GetComponent<AI>().StopEveryCoroutines();
            }
            UiManager.Instance.Defeated();
        }

    }
}
