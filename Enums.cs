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
        SILENCE = 6,
        ESSENCE = 7,
        DELIRIUM = 8,
        AEGIS = 9,
        NINTH = 10
    }

    public enum CardSet
    {
        INVALID = 0,
        BLANK = 1,
        CORE = 2,
        CONQUEST = 3,
        DUAL = 4,
        AEGIS = 5,
        NEXT = 6
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
        EXECUTE, 
        SWIFT,
        STEALTH,
        POISONED,
        HUSH,
        REFRESH,
        MANA,
        SHIFT,
        PUSH,
        PULL,
        DRAIN,
        COMMAND,
        TOKEN,
        DUAL
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
        SHADOW = 8,
        GOLEM = 9,
        STARLING =10
    }

    public enum Rarity
    {
        INVALID = 0,
        BASIC = 1,
        COMMON = 2,
        RARE = 3,
        EPIC = 4,
        CHAMPION = 5,
        TOKEN = 6
    }

    public enum CardScrapPrice
    {
        INVALID = 0,
        COMMON = 400,
        RARE = 1600,
        EPIC = 3200,
        CHAMPION = 8000
    }

    public enum CardScrapValue
    {
        INVALID = 0,
        COMMON = 50,
        RARE = 200,
        EPIC = 400,
        CHAMPION = 0
    }

    public enum DataStatus
    {
        RELEASE = 0,
        PREVIEW = 1,
        UNKNOWN = 2,
    }
}
