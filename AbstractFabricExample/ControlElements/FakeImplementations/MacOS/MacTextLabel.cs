namespace AbstractFabricExample.ControlElements.FakeImplementations.MacOS
{
    public class MacTextLabel : TextLabel
    {
        public override void Render()
        {
            Console.WriteLine("Rendering macTextLabel: " + Text);
        }

    }
}
