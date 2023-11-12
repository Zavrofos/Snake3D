namespace Snake
{
    public class SnakeModel
    {
        private int InitialCountPartOfBody;
        public HeadSnakeModel Head;
        public BodySnakeModel Body;

        public SnakeModel(int initialCountPartOfBody)
        {
            InitialCountPartOfBody = initialCountPartOfBody;
        }
    }
}