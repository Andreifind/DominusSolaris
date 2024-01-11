[System.Serializable]
public class PlayerData
{
    public int level;
    public int points;
    public float energy;
    public int shieldsdown;
    public int lasers;
	public int shields;
	public int laserdown;
    public float overheat;
	public int over;
	public int tax;
    public int exp;
	public int exp1;
    public int targetexp;
    public int speed;
	public int damage;
	public int roketdmg;
	public int laserdamage;
    public int rokets;
    public int roketdown;
	public int crit;
	public int pierce;
    public int wave;
    public int planet;
    public int hp;
    public int killscore;
    public int index;
    public int deaths;
    public int score;
    public int shotsfired;
    public int hitted;
    public bool cancontinue;
    public float taxred;
    public bool cheated;
    public bool isdemo;
    public int highscore;
    
    public PlayerData(Ship player)
    {
        level=player.level;
        points=player.points;
        energy=player.energy;
        shieldsdown=player.shieldsdown;
        lasers=player.lasers;
        shields=player.shields;
        laserdown=player.laserdown;
        overheat=player.overheat;
        over=player.over;
        tax=player.tax;
        exp=player.exp;
        exp1=player.exp1;
        targetexp=player.targetexp;
        speed=player.speed;
        damage=player.damage;
        roketdmg=player.roketdmg;
        laserdamage=player.laserdamage;
        rokets=player.rokets;
        roketdown=player.roketdown;
        crit=player.crit;
        pierce=player.pierce;
        wave = player.wave;
        planet = player.planet;
        hp = player.hp;
        killscore= player.killscore;
        index=player.index;
        deaths=player.deaths;
        score=player.score;
        shotsfired=player.shotsfired;
        hitted=player.hitted;
        cancontinue=player.cancontinue;
        taxred=player.taxred;
        cheated=player.cheated;
        isdemo=player.isdemo;
        if(highscore<player.highscore) highscore=player.highscore;
    }   
}
