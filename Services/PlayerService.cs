using quiz_project.Models;

namespace quiz_project.Services
{
    public class PlayerService
    {
        public List<Player> Players = new();
        public Player CurrentPlayer;


        public bool AddPlayer(Player player)
        {
            if (Players.Any(x => x.Name.ToLower() == player.Name.ToLower()))
                return false;

            Players.Add(player);

            CurrentPlayer = player; // important line

            return true;
        }

        public List<Player> GetLeaderboard()
        {
            return Players.OrderByDescending(x => x.Points).ToList();
        }
        public void UpdateScore(int score)
        {
            if (CurrentPlayer != null)
            {
                CurrentPlayer.Points = score;
            }
        }

        public string GetReward(int points)
        {
            if (points >= 100) return "Gold Trophy";
            if (points >= 50) return "Silver Medal";
            if (points >= 20) return "Bronze Badge";

            return "Participation Badge";
        }
        public List<Question> Questions = new()
{
    new Question
    {
        Text = "What is a budget?",
        Option1 = "A spending plan",
        Option2 = "A type of loan",
        Option3 = "Bank account",
        Option4 = "Insurance",
        CorrectAnswer = 1
    },

    new Question
    {
        Text = "Which is a safe investment?",
        Option1 = "Lottery",
        Option2 = "Savings Account",
        Option3 = "Gambling",
        Option4 = "Betting",
        CorrectAnswer = 2
    },

    new Question
    {
        Text = "Emergency fund should cover?",
        Option1 = "1 day expenses",
        Option2 = "1 week expenses",
        Option3 = "3–6 months expenses",
        Option4 = "1 year shopping",
        CorrectAnswer = 3
    }
};
    }
}
