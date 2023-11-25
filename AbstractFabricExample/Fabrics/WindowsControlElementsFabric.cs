using AbstractFabricExample.ControlElements;
using AbstractFabricExample.ControlElements.FakeImplementations.Windows;

namespace AbstractFabricExample.Fabrics
{
    public class WindowsControlElementsFabric : ControlElementsAbstractFabric
    {
        public override ComboBox<T> CreateComboBox<T>()
        {
            return new WindowsComboBox<T>();
        }

        public override Form CreateForm()
        {
            return new WindowsForm();
        }

        public override TextLabel CreateTextLabel()
        {
            return new WindowsTextLabel();
        }
    }
}
