using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using mDEV.Ui;


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
                        tmp.transform.position = data.position;
                        clickedCard = tmp;
                    }
                    break;
                }
            }
        }

        public void UiLButtonUp(InputAction.CallbackContext txt)
        {
            LButtonClick = false;
            clickedCard.transform.position = clickedCard.DefaultPos;
        }

        public void UiLButton()
        {
            data.position = Input.mousePosition;
            clickedCard.transform.position = data.position;
        }


        private void Update()
        {
            // if (LButtonClick)
            //     UiLButton();
        }
    }
}
