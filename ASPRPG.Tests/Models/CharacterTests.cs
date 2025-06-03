using ASPRPG.Models;
using Xunit;

namespace ASPRPG.Tests.Models
{
    public class CharacterTests
    {
        [Fact]
        public void AttackEnemy_ReducesEnemyHealth()
        {
            var character = new Character { Attack = 5 };
            var enemy = new Enemy { Health = 10 };

            character.AttackEnemy(enemy);

            Assert.Equal(5, enemy.Health);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void TakeDamage_NonPositive_NoEffect(int damage)
        {
            var character = new Character { Health = 10 };

            character.TakeDamage(damage);

            Assert.Equal(10, character.Health);
        }
    }
}
