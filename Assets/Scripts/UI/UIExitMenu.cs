using UnityEngine;

namespace UI
{
    public class UIExitMenu : MonoBehaviour
    {
        private void Start()
        {
            RectTransform rectTransform = transform as RectTransform;
            var position = rectTransform.transform.position;
            position.y  = rectTransform.position.y + rectTransform.rect.height * 3;
            rectTransform.transform.position = position;

        }

        public void ExitGame()
        {
            Application.Quit();
        }

    }
}