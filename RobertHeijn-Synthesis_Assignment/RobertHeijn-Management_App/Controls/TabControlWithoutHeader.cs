namespace RobertHeijn_Management_App.Controls;

public class TabControlWithoutHeader : TabControl
{
    public TabControlWithoutHeader()
    {
        if (!DesignMode) Multiline = true;
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
        else base.WndProc(ref m);
    }
}