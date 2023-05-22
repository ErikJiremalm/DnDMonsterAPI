namespace DnDMonsterAPI.Models
{
    public class Monster
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int? hp{ get; set; }
        public int? ac { get; set; }
        public int? cr { get; set; }
        public int? movment_speed  { get; set; }


    }
}
