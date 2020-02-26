using System;

namespace DarkestDimension {
    public class EventManager {

        #region Events handlers
        object objectLock = new System.Object();

        private event EventHandler<GameEventArgs> _broadcast;
        public event EventHandler<GameEventArgs> Broadcast {
            add {
                lock (objectLock) {
                    Logger.Log("event", "Subscribe to event 'broadcast'");
                    _broadcast += value;
                }
            }
            remove {
                lock (objectLock) {
                    Logger.Log("event", "Unsubscribe from event 'broadcast'");
                    _broadcast -= value;
                }
            }
        }

        private event EventHandler<GameEventArgs> _generic;
        public event EventHandler<GameEventArgs> Generic {
            add {
                lock (objectLock) {
                    Logger.Log("event", "Subscribe to event 'generic'");
                    _generic += value;
                }
            }
            remove {
                lock (objectLock) {
                    Logger.Log("event", "Unsubscribe from event 'generic'");
                    _generic -= value;
                }
            }
        }

        private event EventHandler<GameEventArgs> _cmdEndTurn;
        public event EventHandler<GameEventArgs> CmdEndTurn {
            add {
                lock (objectLock) {
                    Logger.Log("event", "Subscribe to event 'CmdEndTurn'");
                    _cmdEndTurn += value;
                }
            }
            remove {
                lock (objectLock) {
                    Logger.Log("event", "Unsubscribe from event 'CmdEndTurn'");
                    _cmdEndTurn -= value;
                }
            }
        }

        private event EventHandler<GameEventArgs> _cmdEnterCombat;
        public event EventHandler<GameEventArgs> CmdEnterCombat {
            add {
                lock (objectLock) {
                    Logger.Log("event", "Subscribe to event 'CmdEnterCombat'");
                    _cmdEnterCombat += value;
                }
            }
            remove {
                lock (objectLock) {
                    Logger.Log("event", "Unsubscribe from event 'CmdEnterCombat'");
                    _cmdEnterCombat -= value;
                }
            }
        }
        #endregion

        public void BroadcastGameEvent(object sender, GameEventType type, string message = "") {
            BroadcastGameEvent(sender, new GameEventArgs(type, message));
        }

        public void BroadcastGameEvent(object sender, GameEventArgs args) {
            RaiseGameEvent(_broadcast, sender, args);
        }

        public void RaiseGameEvent(object sender, GameEventType type, string message = "") {
            RaiseGameEvent(sender, new GameEventArgs(type, message));
        }

        public void RaiseGameEvent(object sender, GameEventArgs args) {
            switch (args.Type) {
                case GameEventType.Generic:
                    RaiseGameEvent(_generic, sender, args);
                    break;
                case GameEventType.CmdEndTurn:
                    RaiseGameEvent(_cmdEndTurn, sender, args);
                    break;
                case GameEventType.CmdEnterCombat:
                    RaiseGameEvent(_cmdEnterCombat, sender, args);
                    break;
                default:
                    Logger.Error("event", "No handler registered for event type '{0}'", args.Type);
                    break;
            }
        }

        private void RaiseGameEvent(EventHandler<GameEventArgs> handler, object sender, GameEventArgs args) {
            Logger.Log("event", "Raise event of type '{0}'", args.Type);

            // Make local copy to stay thread-safe
            EventHandler<GameEventArgs> _handler = handler;
            if (_handler != null) {
                _handler(sender, args);
            }
        }
    }
}