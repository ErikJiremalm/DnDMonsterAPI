namespace DnDMonsterAPI.Services.MonsterServices
{
    public interface IMonsterServices
    {
        Task<List<Monster>> GetAllMonsters();
        Task<Monster?> GetAMonster(int id);
        Task<List<Monster>> AddAMonster(Monster newMonster);
        Task<List<Monster>?> UpdateAMonster(int id, Monster request);
        Task<List<Monster>?> DeleteAMonster(int id);
    }
}
