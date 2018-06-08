﻿using System;
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

        private static IList<MessagePumpSubscriber> subscribers = new List<MessagePumpSubscriber>();

        public static void DispatchMessage(string name, string action)
        {
            foreach (MessagePumpSubscriber subscriber in subscribers)
            {
                if(subscriber.name == name && subscriber.action == action)
                {
                    subscriber.callback(name, action);
                }
            }
        }

        public static void Subscribe(string name, string action, Action<string, string> callback)
        {
            MessagePumpSubscriber newSubscriber = new MessagePumpSubscriber(name, action, callback);
            subscribers.Add(newSubscriber);
        }

    }
}
