namespace AbstractFabricExample.ControlElements.FakeImplementations.Windows
{
    public class WindowsComboBox<T> : ComboBox<T>
    {
        public override void Render()
        {
            Console.Write("Rendering windowsComboBox:");
            Console.WriteLine(String.Join("", Items.Select(item => "\n\t" + item)));
        }
    }
}
