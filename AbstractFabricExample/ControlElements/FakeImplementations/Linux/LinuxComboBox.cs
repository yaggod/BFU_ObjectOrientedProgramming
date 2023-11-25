namespace AbstractFabricExample.ControlElements.FakeImplementations.Linux
{
    public class LinuxComboBox<T> : ComboBox<T>
    {
        public override void Render()
        {
            Console.Write("Rendering linuxComboBox:");
            Console.WriteLine(String.Join("", Items.Select(item => "\n\t" + item)));
        }
    }
}
