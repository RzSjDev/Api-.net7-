namespace api.net.Models
{
    public class Characters
    {
        public int Id { get; set; }
        public string name { get; set; } = "jack";
        public int Hitpoint { get; set; } = 100;
        public int Defence { get; set; } = 10;
        public int Strength { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public Rpgclass rpgclass { get; set; } = Rpgclass.Knight;

    }
}