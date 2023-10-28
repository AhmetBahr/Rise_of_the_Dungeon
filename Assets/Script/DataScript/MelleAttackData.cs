using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "NewMovemntData", menuName = "Data/AttackMelleData")]
    public class MelleAttackData : ScriptableObject
    {
        [Header("Damage")]
        public int minDamage;
        public int maxDamage;
        
        [Header("Distance")]
        public float attackRangeX;
        public float attackRangeY;
        
        [Header("Another")]
        public LayerMask whatisEnemies;
    }

    
}
