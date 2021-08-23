namespace TorrentBG.Data
{
    public class DataConstants
    {
        public class Comment
        {
            public const int MinTextLength = 3;
            public const int MaxTextLength = 50;
        }
        public class Contact 
        {
            public const int MinNameLength = 4;
            public const int MaxNameLength = 20;

            public const int MaxMessageLength = 100;

            public const string EmailAddress = "torrentbginfo@gmail.com";
        }

        public class Torrent
        {
            public const int MinTorrentName = 5;
            public const int MaxTorrentName = 30;

            public const int MinTorrentYear = 1900;
            public const int MaxTorrentYear = 2050;
        }
        
        public class Movie
        {
            public const int MinMovieLength = 5;
            public const int MaxMovieLength = 200;

            public const int MinMainActorsText = 6;
            public const int MaxMainActorsText = 100;

            public const int MinDescription = 5;
            public const int MaxDescription = 100;


        }

        public class Series
        {
            public const int MinDescription = 5;
            public const int MaxDescription = 100;

            public const int MinMovieLength = 5;
            public const int MaxMovieLength = 200;

            

            public const int MinMainActorsText = 6;
            public const int MaxMainActorsText = 100;
        }
       
        public class City
        {
            public const int MaxCityLength = 20;
            public const int MinCityLength = 4;
        }

        public class Game
        {
            public const int MaxInstructionsLength = 100;
            public const int MinInstructionsLength = 5;
        }

        public class Developer
        {
            public const int MinDeveloperLength = 2;
            public const int MaxDeveloperLength = 30;
        }

        public class Director
        {
            public const int MinDirectorLength = 5;
            public const int MaxDirectorLength = 30;
        }
       
        public class Category
        {
            public const int MaxCategoryName = 20;
        }

        public class Genre
        {
            public const int MaxGenreName = 20;
        }
       
        public class Uploader
        {
            public const int MaxUploaderName = 30;
        }
       
        public class User
        {
            public const int FullNameMaxLength = 30;
            public const int FullNameMinLength = 5;
            public const int UserNameMaxLength = 20;
            public const int UserNameMinLength = 4;
        }

        


    }
}
