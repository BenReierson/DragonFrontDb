using System;

namespace DragonFrontDb.Enums
{

    public enum Booster
    {
        INVALID = 0,
        CLASSIC = 1,
    }

    public enum Faction
    {
        INVALID = 0,
        UNALIGNED = 1,
        ECLIPSE = 2,
        SCALES = 3,
        STRIFE = 4,
        THORNS = 5,
        UNKNOWN1 = 6,
        UNKNOWN2 = 7,
        UNKNOWN3 = 8,
    }

    public enum CardSet
    {
        INVALID = 0,
        BLANK = 1,
        CORE = 2,
    }

    public enum CardType
    {
        INVALID = 0,
        CHAMPION = 1,
        SPELL = 2,
        FORT = 3,
        UNIT = 4,
    }

    public enum DeckType
    {
        NORMAL_DECK = 1,
        AI_DECK = 2,
        GENERATED_DECK = 3,
        EXTERNAL_DECK = 4,
        HIDDEN_DECK = 1000,
    }

   
    public enum Traits 
    {
        _SPAWN,
        SIPHON,
        FLIGHT,
        RANGE,
        BLIGHT,
        RESPAWN,
        TRAP,
        CHOOSE_ONE,
        START_OF_TURN,
        DEATH_,
        SURVIVOR,
        UNION,
        ARMOR,
        END_OF_TURN,
        CATAPULT,
        STUN,
        POWER,
        HEAL,
        SPRINT,
        DRAW,
        DEATHBLOW,
        BREACH,
        BERSERK,
        RUSH,
        REGEN,
        WALL,
        GIANT,
        EXECUTE
    }
    
    public enum Race
    {
        NONE = 0,
        DRUID = 1,
        WARDEN = 2,
        STYGIAN = 3,
        TEMPEST = 4,
        HOLLOW = 5,
        DRAGON = 6,
        SLAG = 7,
        SHADOW = 8
    }

    public enum Rarity
    {
        INVALID = 0,
        BASIC = 1,
        COMMON = 2,
        RARE = 3,
        EPIC = 4,
        CHAMPION = 5
    }
    
}
