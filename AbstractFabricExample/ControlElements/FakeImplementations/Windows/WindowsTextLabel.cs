namespace AbstractFabricExample.ControlElements.FakeImplementations.Windows
{
    public class WindowsTextLabel : TextLabel
    {
        public override void Render()
        {
            Console.WriteLine("Rendering windowsTextLabel: " + Text);
        }

    }
}
