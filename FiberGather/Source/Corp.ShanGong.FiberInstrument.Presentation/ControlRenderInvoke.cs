using System.Windows.Forms;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    public class ControlRenderInvoke
    {
        public delegate void ControlRenderCallback();

        public static void SafeInvoke(Control control, ControlRenderCallback handler)
        {
            if (control.InvokeRequired)
            {
                while (!control.IsHandleCreated)
                {
                    if (control.Disposing || control.IsDisposed)
                    {
                        return;
                    }
                }
                var result = control.BeginInvoke(new InvokeMethodDelegate(SafeInvoke), control, handler);
                control.EndInvoke(result); //获取委托执行结果的返回值
                return;
            }
            var result2 = control.BeginInvoke(handler);
            control.EndInvoke(result2);
        }

        private delegate void InvokeMethodDelegate(Control control, ControlRenderCallback handler);
    }
}