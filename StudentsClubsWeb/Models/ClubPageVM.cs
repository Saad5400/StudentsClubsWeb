namespace StudentsClubsWeb.Models
{
    public class ClubPageVM
    {
        // prop for club
        public Club Club { get; set; }
        // prop for enumerable of Join Club Requests
        public IEnumerable<JoinClubRequest> JoinClubRequests { get; set; }
    }
}
