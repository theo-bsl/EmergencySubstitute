using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class SO_Character : ScriptableObject
{
    [SerializeField]
    private string m_name;

    [SerializeField]
    private Sprite m_icon;

    [SerializeField]
    private float m_workTime;

    [Serializable]
    struct Skills
    {
        public SC_ProfessionEnum.Expertise Mechanic;
        public SC_ProfessionEnum.Expertise Informatician;
        public SC_ProfessionEnum.Expertise Cook;
        public SC_ProfessionEnum.Expertise Doctor;
    }

    [SerializeField]
    private Skills m_skills;

    public float WorkTime { get { return m_workTime; } }

    public string Name { get { return m_name; } }

    public Sprite Icon { get { return m_icon;} }
}
