using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace App
{
    public class PostSingleUI : MonoBehaviour
    {
        [SerializeField] private Image userImage;
        [SerializeField] private TMP_Text userNameText;
        [SerializeField] private TMP_Text postContentText;
        [SerializeField] private TMP_Text likesCountText;

        public void SetInfo(Sprite userImageSprite, string userName, string postContent, string likesCount)
        {
            userImage.sprite = userImageSprite;
            userNameText.text = userName;
            postContentText.text = postContent;
            likesCountText.text = likesCount;
        }
    }

}
