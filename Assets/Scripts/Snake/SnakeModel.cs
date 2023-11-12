using Snake.Body;
using Snake.Head;

namespace Snake
{
    public class SnakeModel
    {
        public readonly int InitialCountPartOfBody;
        public SnakeHeadModel Head;
        public BodySnakeModel Body;

        public SnakeModel(int initialCountPartOfBody, int gapBetweenPositionsOfBodyParts)
        {
            InitialCountPartOfBody = initialCountPartOfBody;
            Head = new SnakeHeadModel();
            Body = new BodySnakeModel(gapBetweenPositionsOfBodyParts);
        }
    }
}