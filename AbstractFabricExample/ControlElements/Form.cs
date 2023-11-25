namespace AbstractFabricExample.ControlElements
{
    public abstract class Form : ControlElement
    {
        public List<ControlElement> ControlElements
        {
            get;
            set;
        } = new();

        

        public override void Render()
        {
            RenderThis();
            RenderContents();
        }

        public abstract void RenderThis();
        protected void RenderContents()
        {
            foreach (var element in ControlElements)
            {
                element.Render();
            }
        }

        public async void BeginRendering()
        {

            while (true)
            {
                Render(); 
                await Task.Delay(2000);
            }
        }
    }
}
