namespace AbstractFabricExample.ControlElements.FakeImplementations.Windows
{
    public class WindowsForm : Form
    {
        public override void RenderThis()
        {
            Console.WriteLine("Rendering windowsForm");
        }
    }
}
