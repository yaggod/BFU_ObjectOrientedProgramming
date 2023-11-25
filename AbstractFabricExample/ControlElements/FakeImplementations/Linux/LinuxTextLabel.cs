namespace AbstractFabricExample.ControlElements.FakeImplementations.Linux
{
    public class LinuxTextLabel : TextLabel
    {
        public override void Render()
        {
            Console.WriteLine("Rendering linuxTextLabel: " + Text);
        }
    }
}
