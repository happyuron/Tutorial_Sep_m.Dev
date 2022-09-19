using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using mDEV.Ui;
using mDEV.Characters;


namespace mDEV.Manager
{
    public class InputManager : Singleton<InputManager>
    {

        public GraphicRaycaster[] raycaster;

        private PointerEventData data;

        private CardUi clickedCard;

        private bool LButtonClick;
        private void Start()
        {
            data = new PointerEventData(null);
        }

        public void UiLButtonDown(InputAction.CallbackContext txt)
        {
            if (txt.control.IsPressed())
            {
                data.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                for (int i = 0; i < raycaster.Length; i++)
                {
                    raycaster[i].Raycast(data, results);
                    if (results.Count > 0)
                    {
                        if (results[0].gameObject.GetComponent<CardUi>())
                        {
                            LButtonClick = true;
                            CardUi tmp = results[0].gameObject.GetComponent<CardUi>();
                            tmp.SetPos(data.position);
                            clickedCard = tmp;
                        }
                        break;
                    }
                }
            }
            else
            {
                LButtonClick = false;
                if (clickedCard != null)
                {
                    clickedCard.transform.position = clickedCard.DefaultPos;
                    data.position = Input.mousePosition;
                    List<RaycastResult> results = new List<RaycastResult>();
                    for (int i = 0; i < raycaster.Length; i++)
                    {
                        raycaster[i].Raycast(data, results);
                        if (results.Count > 0)
                        {
                            clickedCard.SetPos(clickedCard.DefaultPos);
                            return;
                        }
                    }
                    if (GameManager.Instance.curPlayingCharacter.GetComponent<Player>() &&
                        clickedCard.card.owner.curMp >= clickedCard.card.cardInfo.cost)
                        clickedCard.ShowMyCard();
                    else
                        clickedCard.SetPos(clickedCard.DefaultPos);
                }
            }
        }

        public void UiLButton()
        {
            data.position = Input.mousePosition;
            clickedCard.transform.position = data.position;
        }


        private void Update()
        {
            if (LButtonClick)
                UiLButton();
        }
    }
}
