using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChestScreen
{
    public class ChestM : MonoBehaviour
    {
        [SerializeField] private Button checkBoxButton;
        [SerializeField] private Image checkBoxImage;
        [SerializeField] private TextMeshProUGUI text;

        private Color _completeColor;
        private Color _unCompleteColor;

        private UnityAction<ChestM> _chestStateChanged;

        public bool ChestComplete { get; private set; }

        public void InitializeChest(Color checkBoxColor,
            Color checkBoxCompleteColor,
            string chestText,
            UnityAction<ChestM> chestStateChanged,
            bool complete = false)
        {

            _unCompleteColor = checkBoxColor;
            _completeColor = checkBoxCompleteColor;
            text.text = chestText;
            _chestStateChanged = chestStateChanged;
            checkBoxButton.AddSingleListener(ChestStateChanged);

            ShowChest();
        }


        private void ChestStateChanged()
        {
            ChestComplete = !ChestComplete;
            _chestStateChanged?.Invoke(this);
        }


        public void UnCompleteChest()
        {
            checkBoxImage.color = _unCompleteColor;
            text.fontStyle = FontStyles.Normal;

            ChestComplete = false;
        }

        public void CompleteChest()
        {
            checkBoxImage.color = _completeColor;
            text.fontStyle = FontStyles.Strikethrough;

            ChestComplete = true;
        }

        public void HideChest() => gameObject.SetActive(false);
        public void ShowChest() => gameObject.SetActive(true);
    }
}
