namespace ConsoleApp8
{
    internal class Program
    {
        public static object percentageAction { get; private set; }

        static void Main(string[] args)
        {
            List<VideoGame> videoGames = File.ReadAllLines("videogames.csv")
                .Skip(1) // Skip header row if present
                .Select(line => line.Split(','))
                .Select(data => new VideoGame
                {
                    Title = data[0],
                    Publisher = data[1],
                    Genre = data[2]
                })
                .ToList();
            videoGames.Sort();
            string chosenPublisher = "Nintendo";
            List<VideoGame> nintendoGames = videoGames.Where(vg => vg.Publisher == chosenPublisher)
                .OrderBy(vg => vg.Title)
                .ToList();
            foreach (var game in nintendoGames)
            {
                Console.WriteLine(game);
            }
            double percentageNintendo = (double)nintendoGames.Count / videoGames.Count * 100;
            Console.WriteLine($"Out of {videoGames.Count} games, {nintendoGames.Count} are developed by {chosenPublisher}, which is {percentageNintendo:F2}%");
            string chosenGenre = "Action";
            List<VideoGame> Action = videoGames.Where(vg => vg.Genre == chosenGenre)
                .OrderBy(vg => vg.Title)
                .ToList();
            foreach (var game in Action)
            {
                Console.WriteLine(game);
            }
            double percentageRolePlaying = (double)Action.Count / videoGames.Count * 100;
            Console.WriteLine($"Out of {videoGames.Count} games, {Action.Count} are {chosenGenre} games, which is {percentageAction:F2}%");

            static void PublisherData(List<VideoGame> games, string publisher)
            {
                // Similar code as step 4 with 'chosenPublisher' replaced by 'publisher'
            }

            static void GenreData(List<VideoGame> games, string genre)
            {
                // Similar code as step 5 with 'chosenGenre' replaced by 'genre'
            }

        }
        public class VideoGame : IComparable<VideoGame>
        {
            public string Title { get; set; }
            public string Publisher { get; set; }
            public string Genre { get; set; }

            public int CompareTo(VideoGame other)
            {
                // Implement comparison logic based on title
                return Title.CompareTo(other.Title);
            }

            public override string ToString()
            {
                return $"{Title}, {Publisher}, {Genre}";
            }

        }
    }
}
  

   