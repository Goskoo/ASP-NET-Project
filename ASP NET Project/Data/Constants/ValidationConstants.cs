namespace ASP_NET_Project.Data.Constants
{
    public static class ValidationConstants
    {
        // Mineral Constants
        public const int MineralNameMaxLength = 50;
        public const int MineralNameMinLength = 2;
        public const int ColorsMaxLength = 100;
        public const int ColorsMinLength = 2;
        public const int LusterMaxLength = 50;
        public const int LusterMinLength = 2;
        public const int MohsScaleMaxLength = 20;
        public const int CrystalHabitMaxLength = 200;
        public const int CleavageMaxLength = 100;
        public const int FractureMaxLength = 50;
        public const int StreakMaxLength = 50;
        public const int DescriptionMaxLength = 1000;
        public const int CollectingTipsMaxLength = 500;
        public const int TipsMaxLength = 500;

        // Location Constants
        public const int RegionNameMaxLength = 100;
        public const int RegionNameMinLength = 2;
        public const int CountryMaxLength = 50;
        public const int CountryMinLength = 2;
        public const int MiningHistoryNotesMaxLength = 1000;

        // Museum Constants
        public const int MuseumNameMaxLength = 100;
        public const int MuseumNameMinLength = 2;
        public const int CityMaxLength = 170;
        public const int CityMinLength = 1;
        public const int DescriptionMaxLengthMuseum = 1000;
    }
}