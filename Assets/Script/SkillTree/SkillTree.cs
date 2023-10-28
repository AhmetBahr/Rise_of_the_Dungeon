using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Skilltree
{
    public class SkillTree : MonoBehaviour
    {
        [SerializeField] private Skill[] _skills;
        [SerializeField] private Skill[] _unlocedByDefault;

        private int points = 10;

        [SerializeField] private TMP_Text skillPointText;
        
        void Start()
        {
            ResetSkill();
        }

        public void TryUseSkill(Skill _skill)
        {
            if (myPoints > 0 && _skill.Cliced())
            {
                myPoints--; 
            }
        }

        public int myPoints
        {
            get { return points; }
            set
            {
                points = value;
                UpdateSkillPointText();
            }
        }

        private void ResetSkill()
        {
            UpdateSkillPointText();

            foreach (Skill skill  in _skills)
            {
                skill.Lock();
                
            }
            foreach (Skill skill  in _unlocedByDefault)
            {
                skill.Unlock();
                
            }
        }

        private void UpdateSkillPointText()
        {
            skillPointText.text = points.ToString();
        }
        
    }
}
