using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class CharacterEvents
    {
        //Character damaged and damage value
        public static UnityAction<GameObject, int> characterDamaged;

        //Character healed and amount healed
        public static UnityAction<GameObject, int> characterHealed;

        //player gained points
        public static UnityAction<GameObject, int> characterPointGet;

        public static UnityAction<GameObject,int> enemyKilled;

       
    }
}
