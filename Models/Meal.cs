namespace MyFitnessApp.Models
{
    public enum Type
    {
        breakfast = 0,
        lunch = 1,
        dinner = 2,
        snacks = 3
    }
    public class Meal
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Type Types { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }

    }
}
