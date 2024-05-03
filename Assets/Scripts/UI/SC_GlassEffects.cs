using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SC_GlassEffects : MonoBehaviour
{
    [SerializeField] private Image m_leftScreen;
    [SerializeField] private Image m_rightScreen;
    [SerializeField] private Image m_frontScreen;

    [SerializeField] private List<Sprite> m_freezeLeft;
    [SerializeField] private List<Sprite> m_freezeRight;
    [SerializeField] private List<Sprite> m_freezeFront;

    [SerializeField] private List<Sprite> m_fogLeft;
    [SerializeField] private List<Sprite> m_fogRight;
    [SerializeField] private List<Sprite> m_fogFront;

    private SC_StarshipManager m_starshipManager;

    private void Start()
    {
        m_starshipManager = SC_StarshipManager.Instance;
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
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case <= -15:
                m_leftScreen.sprite = m_freezeLeft[3];
                m_rightScreen.sprite = m_freezeRight[3];
                m_frontScreen.sprite = m_freezeFront[3];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case <= -10:
                m_leftScreen.sprite = m_freezeLeft[2];
                m_rightScreen.sprite = m_freezeRight[2];
                m_frontScreen.sprite = m_freezeFront[2];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case <= -5:
                m_leftScreen.sprite = m_freezeLeft[1];
                m_rightScreen.sprite = m_freezeRight[1];
                m_frontScreen.sprite = m_freezeFront[1];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case <= 0:
                m_leftScreen.sprite = m_freezeLeft[0];
                m_rightScreen.sprite = m_freezeRight[0];
                m_frontScreen.sprite = m_freezeFront[0];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case >= 50:
                m_leftScreen.sprite = m_fogLeft[4];
                m_rightScreen.sprite = m_fogRight[4];
                m_frontScreen.sprite = m_fogFront[4];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case >= 45:
                m_leftScreen.sprite = m_fogLeft[3];
                m_rightScreen.sprite = m_fogRight[3];
                m_frontScreen.sprite = m_fogFront[3];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case >= 40:
                m_leftScreen.sprite = m_fogLeft[2];
                m_rightScreen.sprite = m_fogRight[2];
                m_frontScreen.sprite = m_fogFront[2];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case >= 35:
                m_leftScreen.sprite = m_fogLeft[1];
                m_rightScreen.sprite = m_fogRight[1];
                m_frontScreen.sprite = m_fogFront[1];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            case >= 30:
                m_leftScreen.sprite = m_fogLeft[0];
                m_rightScreen.sprite = m_fogRight[0];
                m_frontScreen.sprite = m_fogFront[0];
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 1);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 1);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 1);
                break;
            default:
                m_leftScreen.color = new(m_leftScreen.color.r, m_leftScreen.color.g, m_leftScreen.color.b, 0);
                m_rightScreen.color = new(m_rightScreen.color.r, m_rightScreen.color.g, m_rightScreen.color.b, 0);
                m_frontScreen.color = new(m_frontScreen.color.r, m_frontScreen.color.g, m_frontScreen.color.b, 0);
                break;
        }
    }
}
