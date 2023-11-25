using AbstractFabricExample.ControlElements;

namespace AbstractFabricExample.Fabrics
{
    public abstract class ControlElementsAbstractFabric
    {
        public abstract Form CreateForm();
        public abstract ComboBox<T> CreateComboBox<T>();
        public abstract TextLabel CreateTextLabel();
    }
}
