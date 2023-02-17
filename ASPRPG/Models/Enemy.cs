namespace ASPRPG.Models
{
    public class Enemy
    {
  
        public int Id { get; set; }

        public string? Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public string? Icon { get; set; }

        public void TakeDamage(int damage) 
        {
            Health -= damage;
        }

        public void AttackEnemy(Character enemy)
        {
            enemy.TakeDamage(Attack);
        }
    }
}
