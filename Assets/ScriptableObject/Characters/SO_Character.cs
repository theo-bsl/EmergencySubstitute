using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class SO_Character : ScriptableObject
{
    [SerializeField]
    private string m_name;

    [SerializeField]
    private Sprite m_icon;

    private float m_workTime = 0;

    [Serializable]
    public struct Ability
    {
        public Expertise Mechanic;
        public Expertise Informatician;
        public Expertise Cook;
        public Expertise Doctor;
    }

    [SerializeField]
    private Ability m_skills;

    public Ability Skills { get { return m_skills; } }

    public float WorkTime { get { return m_workTime; } set { m_workTime = value; } }

    public string Name { get { return m_name; } }

    public Sprite Icon { get { return m_icon;} }

    public bool IsAvailable { get { return m_workTime <= 0; } }
}
