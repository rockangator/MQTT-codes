using System;
using System.Text;

// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace m2m2qtt
{
    class Program {
        public static void Main(string[] args)
        {   
            //creating an instance with the ip of the broker. Default port is 1883.
            MqttClient client = new MqttClient("192.168.43.217");
            //specifying mqtt version default is 3.1.1
            client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
            //connecting using username and password
            byte code = client.Connect(Guid.NewGuid().ToString(), "username", "qwertyuiop");
            //publishing
            ushort msgId = client.Publish("test", // topic
                           Encoding.UTF8.GetBytes("MyMessageBody"), // message body
                           MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // QoS level
                           false); // retained
        }
    }
}

//reference: https://www.hivemq.com/blog/mqtt-client-library-encyclopedia-m2mqtt/