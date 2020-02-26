using UnityEngine;

namespace DarkestDimension {

    public static class Logger {

        private static string defaultTag = "other";

        public static void Log(object message) {
            Log(defaultTag, message);
        }

        public static void Log(string tag, object message) {
            Debug.LogFormat("[{0}]: {1}", tag, ObjectToString(message));
        }

        public static void Log(string tag, string format, params object[] args) {
            Debug.LogFormat("[{0}]: {1}", tag, ObjectArrayFormatString(format, args));
        }

        public static void Warning(object message) {
            Warning(defaultTag, message);
        }

        public static void Warning(string tag, object message) {
            Debug.LogWarningFormat("[{0}]: {1}", tag, ObjectToString(message));
        }

        public static void Warning(string tag, string format, params object[] args) {
            Debug.LogWarningFormat("[{0}]: {1}", tag, ObjectArrayFormatString(format, args));
        }

        public static void Error(object message) {
            Error(defaultTag, message);
        }

        public static void Error(string tag, object message) {
            Debug.LogErrorFormat("[{0}]: {1}", tag, ObjectToString(message));
        }

        public static void Error(string tag, string format, params object[] args) {
            Debug.LogErrorFormat("[{0}]: {1}", tag, ObjectArrayFormatString(format, args));
        }

        private static string ObjectToString(object o) {
            return o == null ? "null" : o.ToString();
        }

        private static string ObjectArrayFormatString(string format, params object[] arr) {
            string[] strArr = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++) {
                strArr[i] = ObjectToString(arr[i]);
            }
            return string.Format(format, strArr);
        }

        public static void SetDefaultTag(string tag) {
            defaultTag = tag;
        }
    }

}