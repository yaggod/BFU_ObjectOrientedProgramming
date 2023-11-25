using AbstractFabricExample.ControlElements;
using AbstractFabricExample.Fabrics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AbstractFabricExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowsControlElementsFabric fabric = new();

            Form form = InitializeForm(fabric);
            form.BeginRendering();
            Console.ReadLine();
        }

        public static Form InitializeForm(ControlElementsAbstractFabric fabric)
        {
            Form form = fabric.CreateForm();

            TextLabel label1 = fabric.CreateTextLabel();
            label1.Text = "ExampleApplication";
            label1.Position = new Point(10, 10);

            TextLabel label2 = fabric.CreateTextLabel();
            label2.Text = "Available options:";
            label2.Position = new Point(10, 40);

            ComboBox<string> comboBox = fabric.CreateComboBox<string>();
            comboBox.Items = new List<string>()
            {
                "string1",
                "string2",
                "string3"
            };
            comboBox.Position = new Point(10, 60);

            form.ControlElements.Add(label1);
            form.ControlElements.Add(label2);
            form.ControlElements.Add(comboBox);


            return form;
        }
    }
}