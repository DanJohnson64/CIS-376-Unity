using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
