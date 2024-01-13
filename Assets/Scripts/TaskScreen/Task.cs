using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TaskScreen {
    public class Task : MonoBehaviour {
        [SerializeField] private Button checkBoxButton;
        [SerializeField] private Image checkBoxImage;
        [SerializeField] private TextMeshProUGUI text;

        private Color _completeColor;
        private Color _unCompleteColor;

        private UnityAction<Task> _taskStateChanged;

        public bool TaskComplete { get; private set; }

        public void InitializeTask(Color checkBoxColor, 
            Color checkBoxCompleteColor, 
            string taskText, 
            UnityAction<Task> taskStateChanged,
            bool complete = false) {
            
            _unCompleteColor = checkBoxColor;
            _completeColor = checkBoxCompleteColor;
            text.text = taskText;
            _taskStateChanged = taskStateChanged;
            checkBoxButton.AddSingleListener(TaskStateChanged);
        
            ShowTask();
        }


        private void TaskStateChanged() {
            TaskComplete = !TaskComplete;
            _taskStateChanged?.Invoke(this);
        }
        
        
        public void UnCompleteTask() {
            checkBoxImage.color = _unCompleteColor;
            text.fontStyle = FontStyles.Normal;

            TaskComplete = false;
        }

        public void CompleteTask() {
            checkBoxImage.color = _completeColor;
            text.fontStyle = FontStyles.Strikethrough;

            TaskComplete = true;
        }

        public void HideTask() => gameObject.SetActive(false);
        public void ShowTask() => gameObject.SetActive(true);
    }
}
