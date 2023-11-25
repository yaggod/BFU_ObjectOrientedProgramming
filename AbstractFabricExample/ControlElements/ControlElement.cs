using System.Drawing;

namespace AbstractFabricExample.ControlElements
{
    public abstract class ControlElement
    {
        public Point Position
        {
            get;
            set;
        }

        public abstract void Render();
    }
}
