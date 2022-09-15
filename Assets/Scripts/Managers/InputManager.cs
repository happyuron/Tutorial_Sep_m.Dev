using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using mDEV.Ui;


namespace mDEV.Manager
{
    public class InputManager : Singleton<InputManager>
    {
        public GraphicRaycaster[] raycaster;

        public void UiLButtonDown()
        {
            PointerEventData data = new PointerEventData(null);
            data.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            for (int i = 0; i < raycaster.Length; i++)
            {
                raycaster[i].Raycast(data, results);
                if (results.Count > 0)
                {
                    if (results[0].gameObject.GetComponent<CardUi>())
                    {
                        CardUi tmp = results[0].gameObject.GetComponent<CardUi>();
                        tmp.transform.position = data.position;
                    }
                    break;
                }
            }
        }

        private void Update()
        {
            UiLButtonDown();
        }
    }
}
