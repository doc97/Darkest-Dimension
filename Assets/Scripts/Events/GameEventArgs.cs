using System;

namespace DarkestDimension {

    [Serializable]
    public struct GameEventArgsParam {
        public GameEventType type;
        public object data;
    }

    public class GameEventArgs : EventArgs {

        public GameEventType Type { get; }
        public object Data { get; }

        public GameEventArgs(object data) : this(GameEventType.Generic, data) { }
        public GameEventArgs(GameEventType type) : this(type, "") { }
        public GameEventArgs(GameEventArgsParam param) : this(param.type, param.data) { }

        public GameEventArgs(GameEventType type, object data) {
            Type = type;
            Data = data;
        }
    }

}