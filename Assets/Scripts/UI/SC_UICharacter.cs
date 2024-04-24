using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_UICharacter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_textName;
    private string m_name;

    [SerializeField]
    private Image m_head;

    [SerializeField]
    private Slider m_workTime;

    public void InitCharacter(string Name, Sprite Head)
    {
        m_textName.text = Name;
        m_name = Name;
        m_head.sprite = Head;
    }

    public void UpdateWorkTime(float EventDuration, float WorkTime)
    {
        m_workTime.value = WorkTime / EventDuration;
    }


    public float WorkTime { get { return m_workTime.value; } set { m_workTime.value = value; } }
    public string Name { get { return m_name; } }
}