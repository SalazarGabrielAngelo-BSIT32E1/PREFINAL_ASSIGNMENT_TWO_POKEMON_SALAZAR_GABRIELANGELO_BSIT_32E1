namespace PokemonAppSalazar.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<PokemonMove> Moves { get; set; }
        public List<AbilityEntry> Abilities { get; set; }
    }

    public class AbilityEntry
    {
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonMove
    {
        public Move Move { get; set; }
        public List<VersionGroupDetail> VersionGroupDetails { get; set; }
    }

    public class Move
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class VersionGroupDetail
    {
        public int LevelLearnedAt { get; set; }
        public MoveLearnMethod MoveLearnMethod { get; set; }
        public VersionGroup VersionGroup { get; set; }
    }

    public class MoveLearnMethod
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class VersionGroup
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
