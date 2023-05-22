using Microsoft.EntityFrameworkCore;

namespace DnDMonsterAPI.Services.MonsterServices
{
    public class MonsterServices : IMonsterServices
    {
        private static List<Monster> monsters = new List<Monster> {
                new Monster {
                    id=1,
                    name="goblin",
                    hp=40,
                    ac=18,
                    cr=2,
                    movment_speed=30
                },
                new Monster
                {
                    id=2,
                    name="troll",
                    hp=84,
                    ac=15,
                    cr=4,
                    movment_speed=30
                },
            };
        private readonly DataContext _context;
        public MonsterServices(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Monster>> AddAMonster(Monster newMonster)
        {
            _context.Monsters.Add(newMonster);
            await _context.SaveChangesAsync();
            return await _context.Monsters.ToListAsync();
        }

        public async Task<List<Monster>?> DeleteAMonster(int id)
        {
            var chosenMonster = await _context.Monsters.FindAsync(id);
            if (chosenMonster is null)
                return null;

            _context.Monsters.Remove(chosenMonster);
            await _context.SaveChangesAsync();

            return await _context.Monsters.ToListAsync();
        }

        public async Task<List<Monster>> GetAllMonsters()
        {
            var monsters = await _context.Monsters.ToListAsync();
            return monsters;
        }

        public async Task<Monster?> GetAMonster(int id)
        {
            var chosenMonster = await _context.Monsters.FindAsync(id);
            if (chosenMonster == null)
                return null;
            return chosenMonster;
        }

        public async Task<List<Monster>?> UpdateAMonster(int id, Monster request)
        {
            var chosenMonster = await _context.Monsters.FindAsync(id);
            if (chosenMonster is null)
                return null;
            if (request.name != "string")
                chosenMonster.name = request.name;
            if (request.hp != 0)
                chosenMonster.hp = request.hp;
            if (request.ac != 0)
                chosenMonster.ac = request.ac;
            if (request.cr != 0)
                chosenMonster.cr = request.cr;
            if (request.movment_speed != 0)
                chosenMonster.movment_speed = request.movment_speed;

            await _context.SaveChangesAsync();

            return await _context.Monsters.ToListAsync();
        }
    }
}
