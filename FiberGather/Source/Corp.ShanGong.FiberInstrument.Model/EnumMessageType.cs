namespace Corp.ShanGong.FiberInstrument.Model
{
    public enum EnumMessageType
    {
        /// <summary>
        ///     读序列号
        /// </summary>
        ReadSn,

        /// <summary>
        ///     设定扫描起点
        /// </summary>
        SetScanStart,

        /// <summary>
        ///     设定扫描步长
        /// </summary>
        SetScanStep,

        /// <summary>
        ///     设定扫描终点
        /// </summary>
        SetScanEnd,

        /// <summary>
        ///     读取原始AD数据步长
        /// </summary>
        ReadAdOrignal,

        /// <summary>
        ///     设置工作模式
        /// </summary>
        SetWorkingWay
    }
}