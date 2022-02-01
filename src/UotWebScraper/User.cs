namespace UotWebScraper
{
    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Citations { get; set; }

        public int HIndex { get; set; }

        public int I10Index { get; set; }

        public User()
        {

        }

        public override string ToString()
        {
            return $"{Name},{Surname},{Citations},{HIndex},{I10Index}";
        }
    }
}
