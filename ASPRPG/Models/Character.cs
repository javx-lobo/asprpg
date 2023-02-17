namespace ASPRPG.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public string? Icon { get; set; }
        public long XP { get; set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void AttackEnemy(Enemy enemy)
        {
            enemy.TakeDamage(Attack);
        }

    }
}
