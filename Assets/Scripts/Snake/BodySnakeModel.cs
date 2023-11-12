using System.Collections.Generic;

namespace Snake
{
    public class BodySnakeModel
    {
        public readonly List<PartOfBodyModel> PartsOfBody;

        public BodySnakeModel()
        {
            PartsOfBody = new List<PartOfBodyModel>();
        }
    }
}