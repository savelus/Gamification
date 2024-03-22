using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChestScreen
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private Button checkBoxButton;
        [SerializeField] private Image checkBoxImage;
        [SerializeField] private TextMeshProUGUI text;

        [SerializeField] private Sprite _closedChestSprite;
        [SerializeField] private Sprite _openChestSprite;

        private Color _completeColor;
        private Color _unCompleteColor;

        private UnityAction<Chest> _chestStateChanged;

        public bool IsActive { get; set; }
        public bool ChestComplete { get; private set; }
        public int ChestId;

        public void InitializeChest(Color checkBoxColor,
            Color checkBoxCompleteColor,
            string chestText,
            UnityAction<Chest> chestStateChanged,
            int chestId,
            bool isActive = false,
            bool complete = false)
        {

            _unCompleteColor = checkBoxColor;
            _completeColor = checkBoxCompleteColor;
            text.text = chestText;
            _chestStateChanged = chestStateChanged;
            ChestId = chestId;
            checkBoxButton.AddSingleListener(ChestStateChanged);

            ShowChest();
        }


        private void ChestStateChanged()
        {
            if (!ChestComplete)
            {
                IsActive = !IsActive;
                Debug.Log($"Button active {ChestComplete}");
                _chestStateChanged?.Invoke(this);
            }
        }


        public void UnCompleteChest()
        {
            checkBoxImage.color = _unCompleteColor;
            checkBoxImage.sprite = _closedChestSprite;
            text.fontStyle = FontStyles.Normal;

            ChestComplete = false;
        }


        public void CompleteChest()
        {
            checkBoxImage.color = _completeColor;
            checkBoxImage.sprite = _openChestSprite;
            text.fontStyle = FontStyles.Strikethrough;

            ChestComplete = true;
        }


        public void HideChest() => gameObject.SetActive(false);
        public void ShowChest() => gameObject.SetActive(true);
    }
}
