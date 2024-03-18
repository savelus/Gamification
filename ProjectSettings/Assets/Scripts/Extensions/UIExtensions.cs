using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Extensions {
    public static class UIExtensions {
        public static void AddSingleListener(this Button button, UnityAction callback) {
            if (button == null) throw new NullReferenceException("Button is null");
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(callback);
        }
    }
}