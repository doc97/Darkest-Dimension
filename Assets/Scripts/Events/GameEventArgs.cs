using System;

namespace DarkestDimension {

    [Serializable]
    public struct GameEventArgsParam {
        public GameEventType type;
        public string message;
    }

    public class GameEventArgs : EventArgs {

        public GameEventType Type { get; }
        public string Message { get; }

        public GameEventArgs(string message) : this(GameEventType.Generic, message) { }
        public GameEventArgs(GameEventType type) : this(type, "") { }
        public GameEventArgs(GameEventArgsParam param) : this(param.type, param.message) { }

        public GameEventArgs(GameEventType type, string message) {
            Type = type;
            Message = message;
        }
    }

}