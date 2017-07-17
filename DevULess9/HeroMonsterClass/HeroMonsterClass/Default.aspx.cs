using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClass
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            hero.Name = "Gregarious";
            hero.Health = 95;
            hero.DamageMaximum = 30;

            Character monster = new Character();
            monster.Name = "Dark Lord";
            monster.Health = 85;
            monster.DamageMaximum = 25;

            Dice battleDie = new Dice();

            int damage = 0;

            AttackBonus(hero, monster);

            if (hero.AttackBonus)
            {
                resultLabel.Text += hero.Name + " won the attack bonus, and gets a free opening shot.<br />";
                damage = hero.Attack(battleDie);
                monster.Defend(damage);
                DisplayResults(hero, monster, damage);
            }
            else if (monster.AttackBonus)
            {
                resultLabel.Text += monster.Name + " won the attack bonus, and gets a free opening shot.<br />";
                damage = monster.Attack(battleDie);
                hero.Defend(damage);
                DisplayResults(monster, hero, damage);
            }

            while((hero.Health>0) && (monster.Health>0))
            { //Battle side one
                damage = hero.Attack(battleDie);
                monster.Defend(damage);
                DisplayResults(hero, monster, damage);

                /*if (monster.Health <= 0) break;  
                 * potential additional code to break
                 * out of loop as soon as monster dies */

                //Battle side two
                damage = monster.Attack(battleDie);
                hero.Defend(damage);
                DisplayResults(monster, hero, damage);

                DisplayStats(hero);
                DisplayStats(monster);

                resultLabel.Text += "<hr>";
            }

            determineWinner(hero, monster);

        }

        private void AttackBonus(Character hero, Character monster)
        {
            Dice rollOffDie = new Dice();
            rollOffDie.Sides = 6;

            int heroRoll = rollOffDie.Roll();
            int monsterRoll = rollOffDie.Roll();

            if (heroRoll > monsterRoll)
                hero.AttackBonus = true;
             else if (monsterRoll > heroRoll)
                monster.AttackBonus = true;
            else
            {
                hero.AttackBonus = false;
                monster.AttackBonus = false;
            }
            
        }

        private void DisplayResults(Character attack, Character defend, int damage)
        {
            string result = String.Format("{0} has attacked {1} and inflicted {2} points of damage.<br />{1}'s new health level is {3}.<br />",
                attack.Name, defend.Name, damage, defend.Health);
            resultLabel.Text += result;
        }

        private void DisplayStats(Character character)
        {
            resultLabel.Text += String.Format("Name: {0} -- Health: {1} -- Maximum Damage: {2} -- Attack Bonus: {3} <br />",
                character.Name, character.Health, character.DamageMaximum, character.AttackBonus);
        }

        private void determineWinner(Character hero, Character monster)
        {
            if ((hero.Health <= 0) && (monster.Health <= 0))
                resultLabel.Text += String.Format("There is no winner. Both {0} and {1} have died from the battle.", hero.Name, monster.Name);
            else if (monster.Health <= 0)
                resultLabel.Text += String.Format("{0} wins the battle! {1} has been vanquished!", hero.Name, monster.Name);
            else if (hero.Health <= 0)
                resultLabel.Text += String.Format("{0} has been defeated and killed by {1}.", hero.Name, monster.Name);
            else /*exception handling*/
                resultLabel.Text += "Something has gone wrong and the battle cannot be completed.";
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice die)
        {
            /* Random random = new Random();
             * int damage = random.Next(1,this.DamageMaximum); */

            die.Sides = this.DamageMaximum;
            int damage = die.Roll();
            return damage;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        Random random = new Random();
        public int Sides { get; set; }

        public int Roll()
        {
            int result = random.Next(1, this.Sides);
            return result;
        }

    }
}