using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SC_GlassEffects : MonoBehaviour
{
    [SerializeField] private Image m_leftScreen;
    private Color m_leftScreenColor;
    [SerializeField] private Image m_rightScreen;
    private Color m_rightScreenColor;
    [SerializeField] private Image m_frontScreen;
    private Color m_frontScreenColor;

    [SerializeField] private List<Sprite> m_freezeLeft;
    [SerializeField] private List<Sprite> m_freezeRight;
    [SerializeField] private List<Sprite> m_freezeFront;

    [SerializeField] private List<Sprite> m_fogLeft;
    [SerializeField] private List<Sprite> m_fogRight;
    [SerializeField] private List<Sprite> m_fogFront;

    private SC_EventManager m_eventManager;
    private SC_StarshipManager m_starshipManager;

    private void Start()
    {
        m_eventManager = SC_EventManager.Instance;
        m_eventManager.NewEvent.AddListener(StartEffects);
        m_eventManager.DeleteEvent.AddListener(CancelEffects);
        m_starshipManager = SC_StarshipManager.Instance;
        m_leftScreenColor = m_leftScreen.color;
        m_rightScreenColor = m_rightScreen.color;
        m_frontScreenColor = m_frontScreen.color;
    }

    private void StartEffects(SC_Event Event)
    {
        if (Event.Name == "excès de chaleur")
        {
            m_leftScreen.sprite = m_fogLeft[0];
            m_rightScreen.sprite = m_fogRight[0];
            m_frontScreen.sprite = m_fogFront[0];
            m_leftScreenColor.a = 1;
            m_rightScreenColor.a = 1;
            m_frontScreenColor.a = 1;
        }
        else if (Event.Name == "manque de chaleur")
        {
            m_leftScreen.sprite = m_freezeLeft[0];
            m_rightScreen.sprite = m_freezeRight[0];
            m_frontScreen.sprite = m_freezeFront[0];
            m_leftScreenColor.a = 1;
            m_rightScreenColor.a = 1;
            m_frontScreenColor.a = 1;
        }
    }

    private void CancelEffects(SC_Event Event)
    {
        m_leftScreenColor.a = 0;
        m_rightScreenColor.a = 0;
        m_frontScreenColor.a = 0;
        m_leftScreen.sprite = null;
        m_rightScreen.sprite = null;
        m_frontScreen.sprite = null;
    }

    private void Update()
    {
        CheckForChanges();
    }

    private void CheckForChanges()
    {

            switch (m_starshipManager.GetTemperature())
            {
                case <= -20:
                    m_leftScreen.sprite = m_freezeLeft[4];
                    m_rightScreen.sprite = m_freezeRight[4];
                    m_frontScreen.sprite = m_freezeFront[4];
                    break;
                case <= -15:
                    m_leftScreen.sprite = m_freezeLeft[3];
                    m_rightScreen.sprite = m_freezeRight[3];
                    m_frontScreen.sprite = m_freezeFront[3];
                    break;
                case <= -10:
                    m_leftScreen.sprite = m_freezeLeft[2];
                    m_rightScreen.sprite = m_freezeRight[2];
                    m_frontScreen.sprite = m_freezeFront[2];
                    break;
                case <= -5:
                    m_leftScreen.sprite = m_freezeLeft[1];
                    m_rightScreen.sprite = m_freezeRight[1];
                    m_frontScreen.sprite = m_freezeFront[1];
                    break;
                case >= 45:
                    m_leftScreen.sprite = m_fogLeft[4];
                    m_rightScreen.sprite = m_fogRight[4];
                    m_frontScreen.sprite = m_fogFront[4];
                    break;
                case >= 40:
                    m_leftScreen.sprite = m_fogLeft[3];
                    m_rightScreen.sprite = m_fogRight[3];
                    m_frontScreen.sprite = m_fogFront[3];
                    break;
                case >= 35:
                    m_leftScreen.sprite = m_fogLeft[2];
                    m_rightScreen.sprite = m_fogRight[2];
                    m_frontScreen.sprite = m_fogFront[2];
                    break;
                case >= 30:
                    m_leftScreen.sprite = m_fogLeft[1];
                    m_rightScreen.sprite = m_fogRight[1];
                    m_frontScreen.sprite = m_fogFront[1];
                    break;
                default:
                    break;
            }
    }
}
