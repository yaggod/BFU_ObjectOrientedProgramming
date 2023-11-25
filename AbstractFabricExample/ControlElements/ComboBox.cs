namespace AbstractFabricExample.ControlElements
{
    public abstract class ComboBox<T> : ControlElement
    {
        public List<T> Items
        {
            get;
            set;
        } = new();

        public T this[int index]
        {
            get => Items.ElementAt(index);
            set => Items.Insert(index, value);
        }

    }
}
