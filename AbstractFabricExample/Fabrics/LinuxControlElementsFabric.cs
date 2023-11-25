using AbstractFabricExample.ControlElements;
using AbstractFabricExample.ControlElements.FakeImplementations.Linux;

namespace AbstractFabricExample.Fabrics
{
    public class LinuxControlElementsFabric : ControlElementsAbstractFabric
    {
        public override ComboBox<T> CreateComboBox<T>()
        {
            return new LinuxComboBox<T>();
        }

        public override Form CreateForm()
        {
            return new LinuxForm();
        }

        public override TextLabel CreateTextLabel()
        {
            return new LinuxTextLabel();
        }
    }
}
