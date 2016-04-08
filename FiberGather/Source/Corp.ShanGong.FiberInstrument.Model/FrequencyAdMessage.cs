using System.Linq;

namespace Corp.ShanGong.FiberInstrument.Model
{
    /// <summary>
    ///     调试模式下的报文（频率数据+AD数据）
    /// </summary>
    public class FrequencyAdMessage : IMessageParse
    {
        public static readonly int MESSAGE_LENGTH = FrequencyMessage.MESSAGE_LENGTH + AdMessage.AD_DATA_MESSAGE_LENGTH;

        public FrequencyMessage Message1
        {
            get;
            set;
        }

        public AdMessage Message2
        {
            get;
            set;
        }

        public void Parse(byte[] message)
        {
            Message1 = new FrequencyMessage();
            Message2 = new AdMessage();
            Message1.Parse(message.Take(FrequencyMessage.MESSAGE_LENGTH).ToArray());
            Message2.Parse(message.Skip(FrequencyMessage.MESSAGE_LENGTH).ToArray());
        }
    }
}