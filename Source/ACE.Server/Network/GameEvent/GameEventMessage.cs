
using ACE.Server.Network.GameMessages;

namespace ACE.Server.Network.GameEvent
{
    public abstract class GameEventMessage : GameMessage
    {
        public GameEventType EventType { get; private set; }

        protected Session Session { get; private set; }

        protected GameEventMessage(GameEventType eventType, GameMessageGroup group, Session session) : base(GameMessageOpcode.GameEvent, group)
        {
            EventType = eventType;
            Session = session;

            Writer.WriteGuid(session.Player.Guid);
            //var debugMessage = $"GameEventSequence Update - {eventType} - GameEventSequence was {session.GameEventSequence}";
            Writer.Write(session.GameEventSequence++);
            //Console.WriteLine(debugMessage + $" and is now {session.GameEventSequence}");
            Writer.Write((uint)EventType);
        }
    }
}
