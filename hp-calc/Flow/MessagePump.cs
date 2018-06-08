using System;
using System.Collections.Generic;

namespace hp_calc.Flow
{
    public class MessagePump
    {
        private struct MessagePumpSubscriber
        {
            public string name;
            public string action;
            public Action<string, string> callback;

            public MessagePumpSubscriber(string name, string action, Action<string, string> callback)
            {
                this.name = name;
                this.action = action;
                this.callback = callback;
            }
        }

        private IList<MessagePumpSubscriber> subscribers = new List<MessagePumpSubscriber>();

        public void DispatchMessage(string type, string action)
        {

        }

        public void Subscriber(string name, string action, Action<string, string> callback)
        {

        }

    }
}
