namespace osrs_dps_calc
{
    public partial class Form1 : Form
    {

        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Initializing variables

            double EffectiveStrengthLevel = 0;
            double EffectiveAttackLevel = 0;
            double MaximumHit = 0;
            double AttackRoll = 0;
            double DefenceRoll = 0;
            double AverageDmgPerAttack = 0;
            double AverageDPS = 0;
            double HitChance = 0;
            double AttackSpeed = 0;
            int StabBonus = 0;
            int SlashBonus = 0;
            int CrushBonus = 0;
            int StrengthBonus = 0;


            int MonsterDefence = Convert.ToInt32(txtMonsterDefence.Text);
            double StrengthLevel = Convert.ToInt32(txtStrengthLevel.Text);
            double AttackLevel = Convert.ToInt32(txtAttackLevel.Text);

            StrengthBonus = Convert.ToInt32(txtStrengthBonus.Text);
            StabBonus = Convert.ToInt32(txtStab.Text);
            SlashBonus = Convert.ToInt32(txtSlash.Text);
            CrushBonus = Convert.ToInt32(txtCrush.Text);

            int MonsterStab = Convert.ToInt32(txtMonsterStab.Text);
            int MonsterSlash = Convert.ToInt32(txtMonsterSlash.Text);
            int MonsterCrush = Convert.ToInt32(txtMonsterCrush.Text);
            int MonsterHP = Convert.ToInt32(txtMonsterHp.Text);
            if (MonsterHP == 0)
            {
                MessageBox.Show("Monster HP Can't be 0!");
            }

            double PrayerBoostStrength = 1;
            double PrayerBoostAttack = 1;





            if (cboPiety.Checked)
            {
                PrayerBoostStrength = 1.23;
                PrayerBoostAttack = 1.20;
            }

            if (cboWeapon.Text == "Dragon Scimitar")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 66;
                StabBonus = 8;
                SlashBonus = 67;
                CrushBonus = -2;
                AttackSpeed = 2.4;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
            }
            else if (cboWeapon.Text == "Abyssal Whip")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 82;
                StabBonus = 0;
                SlashBonus = 82;
                CrushBonus = 0;
                AttackSpeed = 2.4;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
            }
            else if (cboWeapon.Text == "Zombie Axe")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 107;
                StabBonus = -3;
                SlashBonus = 105;
                CrushBonus = 90;
                AttackSpeed = 3;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
            }
            else if (cboWeapon.Text == "Ghrazi Rapier")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 89;
                StabBonus = 94;
                SlashBonus = 55;
                CrushBonus = 0;
                AttackSpeed = 2.4;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
            }




            //Calculating effective strength level
            EffectiveStrengthLevel = Math.Floor((StrengthLevel) * PrayerBoostStrength);
            EffectiveStrengthLevel += 9;



            //Calculating max hit
            MaximumHit = EffectiveStrengthLevel * (StrengthBonus + 64);
            MaximumHit += 320;
            MaximumHit = Math.Floor(MaximumHit / 640);



            //Calculating effective attack level
            EffectiveAttackLevel = Math.Floor(AttackLevel * PrayerBoostAttack);
            EffectiveAttackLevel += 9;



            //Calculating effective attack roll
            if (cboStyle.Text == "Stab")
            {
                AttackRoll = Math.Floor(EffectiveAttackLevel * (StabBonus + 64));
            }
            else if (cboStyle.Text == "Slash")
            {
                AttackRoll = Math.Floor(EffectiveAttackLevel * (SlashBonus + 64));
            }
            else if (cboStyle.Text == "Crush")
            {
                AttackRoll = Math.Floor(EffectiveAttackLevel * (CrushBonus + 64));
            }

            else
            {
                MessageBox.Show("Please select an attack style");
            }


            //Calculating defence roll of monster
            if (cboStyle.Text == "Stab")
            {
                DefenceRoll = (MonsterDefence + 9) * (MonsterStab + 64);
            }
            else if (cboStyle.Text == "Slash")
            {
                DefenceRoll = (MonsterDefence + 9) * (MonsterSlash + 64);
            }
            else if (cboStyle.Text == "Crush")
            {
                DefenceRoll = (MonsterDefence + 9) * (MonsterCrush + 64);
            }

            else
            {
                MessageBox.Show("Please select an attack style");
            }

           

            //Hit chance
            if (AttackRoll > DefenceRoll)
            {
                HitChance = 1 - ((DefenceRoll + 2) / (2 * (AttackRoll + 1)));
            }
            else
            {
                HitChance = AttackRoll / (2 * (DefenceRoll + 1));
            }

            AverageDmgPerAttack = HitChance * ((MaximumHit / 2) + (1 / MaximumHit + 1));

            AverageDPS = AverageDmgPerAttack / AttackSpeed;

            txtDps.Text = "DPS:" + AverageDPS.ToString();
            txtAverageTTK.Text = Convert.ToString(MonsterHP / AverageDPS);

            

        }

        private void cboWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {

            double AttackSpeed;
            int StabBonus;
            int SlashBonus;
            int CrushBonus;
            int StrengthBonus = Convert.ToInt32(txtStrengthBonus.Text);


            if (cboWeapon.Text == "Dragon Scimitar")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 66;
                StabBonus = 8;
                SlashBonus = 67;
                CrushBonus = -2;
                AttackSpeed = 2.4;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
                txtStrengthBonus.Text = StrengthBonus.ToString();
            }
            else if (cboWeapon.Text == "Abyssal Whip")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 82;
                StabBonus = 0;
                SlashBonus = 82;
                CrushBonus = 0;
                AttackSpeed = 2.4;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
                txtStrengthBonus.Text = StrengthBonus.ToString();
            }
            else if (cboWeapon.Text == "Zombie Axe")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 107;
                StabBonus = -3;
                SlashBonus = 105;
                CrushBonus = 90;
                AttackSpeed = 3;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
                txtStrengthBonus.Text = StrengthBonus.ToString();
            }
            else if (cboWeapon.Text == "Ghrazi Rapier")
            {
                StrengthBonus = 0;
                StrengthBonus = StrengthBonus + 89;
                StabBonus = 94;
                SlashBonus = 55;
                CrushBonus = 0;
                AttackSpeed = 2.4;

                txtStab.Text = StabBonus.ToString();
                txtSlash.Text = SlashBonus.ToString();
                txtCrush.Text = CrushBonus.ToString();
                txtStrengthBonus.Text = StrengthBonus.ToString();
            }
        }
    }
}
