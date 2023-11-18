using EventSystem.EventArgs;
using EventSystem.Interfaces;

namespace EventSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestCollectionChangedEvent();
            Console.WriteLine("\n\n\n");
            TestPropertyChangeEvents();
        }

        private static void TestPropertyChangeEvents()
        {
            ExamplePropertyChanger propertyChanger = new();

            (propertyChanger as INotifyPropertyChanging<string>).AddHandler(PropertyChangingHandler);
            (propertyChanger as INotifyPropertyChanged<string>).AddHandler(PropertyChangedHandler);


            propertyChanger.StringProperty = "34567293";
            propertyChanger.StringProperty = "; drop table users";
            propertyChanger.StringProperty = "sfvbasfghj";
            propertyChanger.StringProperty = "abcdef";

        }

        private static void PropertyChangingHandler(object sender, PropertyChangingEventArgs<string> eventArgs)
        {
            Console.WriteLine($"Tried to set value \"{eventArgs.Item}\"");
            if (eventArgs.Item == "; drop table users")
            {
                Console.WriteLine("\tAborted operation");
                eventArgs.ShouldChange = false;
            }
        }

        private static void PropertyChangedHandler(object sender, PropertyChangedEventArgs<string> eventArgs)
        {
            Console.WriteLine($"Value set to \"{eventArgs.Item}\"");
        }


        private static void TestCollectionChangedEvent()
        {
            ExampleCollection<string> collection = new();

            collection.AddHandler(CollectionChangedHandler<string>);

            

            collection.Add("34567293");
            collection.Add("sfvbasfghj");
            collection.Add("abcdef");
            collection.Remove(collection.Last());
            Console.WriteLine("Result:\t" + String.Join(' ', collection));
        }
        private static void CollectionChangedHandler<T>(object sender, CollectionChangedEventArgs<T> eventArgs)
        {
            Console.WriteLine($"{eventArgs.Type} \"{eventArgs.Item}\" to the collection");
        }
    }
}