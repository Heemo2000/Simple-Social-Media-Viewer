using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App
{
    public class LikeButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text likeCount;
        [SerializeField] private Color toggleColor;
        [SerializeField] private Color unToggleColor;


        private bool isToggle;
        private Image image;
        private Button button;
        private void Toggle()
        {
            isToggle = !isToggle;
            int count = Int32.Parse(likeCount.text);

            if(isToggle)
            {
                count++;
            }
            else
            {
                count--;
            }

            likeCount.text = count.ToString();

            if(isToggle)
            {
                image.color = toggleColor;
            }
            else
            {
                image.color = unToggleColor;
            }
        }

        private void Awake()
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();
        }

        private void Start()
        {
            button.onClick.AddListener(Toggle);
        }
    }
}
