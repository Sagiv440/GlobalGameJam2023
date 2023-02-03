
public class GlobalConsts
{
    public const float PLAYER_AIR_DRAG = 1f;
}

public struct talents
{
    public float speed;
    public float health;
    public bool evasionEnabled;
    public float evasionModifier;
    public bool flyEnabled;
    public bool attackEnabled;
    public float attackDamage;
    public float attackTime;
    public bool immuneEnabled;
}

public enum T_TYPES
{
    VOID = 0,
    SPEED = 1,
    ARMOR = 2,
}
public enum GAME_STATE
{
    VIEW = 0,
    PLAY = 1,
    FINISH_SPAWN = 2,
    END = 3,
}

