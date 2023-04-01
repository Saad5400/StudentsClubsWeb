namespace StudentsClubsWeb.Utilities
{
    public class SD
    {
        public static class Role
        {
            public const string Admin = "Admin";
        }
        public static class Policy
        {
            public const string Admin = "Admin";
        }
        public static class TagGroup
        {
            public const string City = "City";
            public const string School = "School";
            public const string Club = "Club";
            public const string User = "User";
            public const string Post = "Post";
            public const string Public = "Public";

        }

        public static class NavActive
        {
            public const string Home = nameof(NavActive) + nameof(Home);
            public const string Profile = nameof(NavActive) + nameof(Profile);
            public const string Clubs = nameof(NavActive) + nameof(Clubs);
            public const string MyClubs = nameof(NavActive) + nameof(MyClubs);
            public const string NewClub = nameof(NavActive) + nameof(NewClub);
            public const string Activee = "activee";
        }
    }
}
