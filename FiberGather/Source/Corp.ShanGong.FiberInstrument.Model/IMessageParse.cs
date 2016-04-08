namespace Corp.ShanGong.FiberInstrument.Model
{
    internal interface IMessageParse
    {
        void Parse(byte[] message);
    }
}