using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestDimension {
    public class StatusValidation : MonoBehaviour {

        [SerializeField]
        private Color status;
        [ReadOnly]
        [SerializeField]
        private string reason;

        private List<Func<bool>> conditions = new List<Func<bool>>();
        private List<string> reasons = new List<string>();

        public void UpdateStatus() {
            status = Color.green;
            for (int i = 0; i < conditions.Count; i++) {
                Func<bool> condition = conditions[i];
                if (!condition.Invoke()) {
                    status = Color.red;
                    reason = reasons[i];
                    return;
                }
            }
            reason = "";
        }

        public void AddCondition(Func<bool> condition, string reason = "") {
            conditions.Add(condition);
            reasons.Add(reason);
        }

        public void ClearConditions() {
            conditions.Clear();
            reasons.Clear();
        }
    }
}