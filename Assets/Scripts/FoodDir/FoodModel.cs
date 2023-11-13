namespace FoodDir
{
    public class FoodModel
    {
        public readonly int Id;
        public StateFood CurrentStateFood;

        public FoodModel(int id)
        {
            CurrentStateFood = StateFood.Idle;
            Id = id;
        }
    }
}