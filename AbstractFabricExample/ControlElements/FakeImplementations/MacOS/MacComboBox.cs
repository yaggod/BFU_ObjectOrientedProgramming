namespace AbstractFabricExample.ControlElements.FakeImplementations.MacOS
{
    public class MacComboBox<T> : ComboBox<T>
    {
        public override void Render()
        {
            Console.Write("Rendering macComboBox:");
            Console.WriteLine(String.Join("", Items.Select(item => "\n\t" + item)));

        }
    }
}

