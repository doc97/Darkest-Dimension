using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestDimension {
    public class StatusValidation : MonoBehaviour {

        [SerializeField]
        private Color status;

        private List<Func<bool>> conditions = new List<Func<bool>>();

        public void UpdateStatus() {
            status = Color.green;
            foreach (Func<bool> condition in conditions) {
                if (!condition.Invoke()) {
                    status = Color.red;
                    return;
                }
            }
        }

        public void AddCondition(Func<bool> condition) {
            conditions.Add(condition);
        }

        public void ClearConditions() {
            conditions.Clear();
        }
    }
}