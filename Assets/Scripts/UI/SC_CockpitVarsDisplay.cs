using TMPro;
using UnityEngine;

public class SC_CockpitVarsDisplay : MonoBehaviour
{
    [SerializeField] private StarshipVar m_parameter;
    [SerializeField] private TextMeshProUGUI m_text;
    private SC_StarshipManager m_manager;

    private void Start()
    {
        m_manager = SC_StarshipManager.Instance;
    }

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (m_parameter == StarshipVar.Pressure)
        {
            m_text.text = ((int)m_manager.GetPressure()).ToString() + "bar";
        }
        else if (m_parameter == StarshipVar.Oxygen)
        {
            m_text.text = ((int)m_manager.GetOxygen()).ToString() + "%";
        }
        else if (m_parameter == StarshipVar.Temperature)
        {
            m_text.text = ((int)m_manager.GetTemperature()).ToString() + "°C";
        }
        else
        {
            m_text.text = ((int)m_manager.GetSpeed()).ToString() + "Ua/h";
        }
    }
}
