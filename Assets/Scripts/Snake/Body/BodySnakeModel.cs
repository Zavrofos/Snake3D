using System;

namespace Snake.Body
{
    public class BodySnakeModel
    {
        public readonly int GapBetweenPositionsOfBodyParts;
        public event Action CreatedPartOfBody;

        public BodySnakeModel(int gapBetweenPositionsOfBodyParts)
        {
            GapBetweenPositionsOfBodyParts = gapBetweenPositionsOfBodyParts;
        }

        public void CreatePartOfBody()
        {
            CreatedPartOfBody?.Invoke();
        }
    }
}