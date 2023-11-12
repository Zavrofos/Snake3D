namespace Snake
{
    public class SnakeModel
    {
        private int InitialCountPartOfBody;
        public SnakeHeadModel Head;
        public BodySnakeModel Body;

        public SnakeModel(int initialCountPartOfBody)
        {
            InitialCountPartOfBody = initialCountPartOfBody;
            Head = new SnakeHeadModel();
            Body = new BodySnakeModel();
        }
    }
}