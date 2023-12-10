using System;
using System.Collections.Generic;
using _Root._Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Root._Scripts.UI
{
    public class ColorPicker : MonoBehaviour
    {
        public Color[] colors;
        public Button prefabButton;
        public Action<Color> onChangeColor;

        private readonly List<Button> _newButtons = new List<Button>();

        public void Init()
        {
            CreateButtons();
            SetColor(GameDataSingleton.instance.teamColor);
        }
        
        private void CreateButtons()
        {
            foreach (var color in colors)
            {
                Button button = Instantiate(prefabButton, transform);
                _newButtons.Add(button);
                button.gameObject.GetComponent<Image>().color = color;


                button.onClick.AddListener(() =>
                {
                    DoButtonsInteractable();

                    button.interactable = false;
                    onChangeColor?.Invoke(color);
                });
            }
        }

        private void DoButtonsInteractable()
        {
            foreach (var button in _newButtons)
            {
                button.interactable = true;
            }
        }

        private void SetColor(Color newColor)
        {
            DoButtonsInteractable();
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == newColor)
                {
                    _newButtons[i].interactable = false;
                    return;
                }
            }
        }
    }
}