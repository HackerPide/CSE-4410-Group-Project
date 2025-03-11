using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent
{
    // Enemy events
    public const string ENEMY_DEATH = "ENEMY_DEATH";
    public const string ENEMY_HEALTH_CHANGED = "ENEMY_HEALTH_CHANGED";

    // Player events
    public const string PLAYER_DAMAGE_CHANGED = "PLAYER_DAMAGE_CHANGED";
    public const string PLAYER_HEALTH_CHANGED = "PLAYER_HEALTH_CHANGED";
    public const string PLAYER_LIFE_STATUS = "PLAYER_LIFE_STATUS";

    // Game events
    public const string NEW_ROUND = "NEW_ROUND";
    public const string GAME_PAUSE = "GAME_PAUSE";


    // Maybe
    public const string RESET = "RESET";
}
