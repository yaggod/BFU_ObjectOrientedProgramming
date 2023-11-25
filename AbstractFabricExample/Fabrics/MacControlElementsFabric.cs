using AbstractFabricExample.ControlElements;
using AbstractFabricExample.ControlElements.FakeImplementations.MacOS;

namespace AbstractFabricExample.Fabrics
{
    class MacControlElementsFabric : ControlElementsAbstractFabric
    {
        public override ComboBox<T> CreateComboBox<T>()
        {
            return new MacComboBox<T>();
        }

        public override Form CreateForm()
        {
            return new MacForm();
        }

        public override TextLabel CreateTextLabel()
        {
            return new MacTextLabel();
        }
    }
}
