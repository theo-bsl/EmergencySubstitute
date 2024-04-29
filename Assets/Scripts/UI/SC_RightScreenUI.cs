using UnityEngine;
using UnityEngine.UI;

public class SC_RightScreenUI : MonoBehaviour
{
    [SerializeField] private Image _gaugeContainer;
    [SerializeField] private Image _gaugeFill;
    [SerializeField] private Sprite _gaugeFillWhite;
    [SerializeField] private Sprite _gaugeFillYellow;
    [SerializeField] private Sprite _gaugeFillOrange;
    [SerializeField] private Sprite _gaugeContainerBlue;
    [SerializeField] private Sprite _gaugeContainerOrange;
    [SerializeField] private Sprite _gaugeContainerRed;

    private void Start()
    {
        _gaugeContainer.sprite = _gaugeContainerBlue;
        _gaugeFill.sprite = _gaugeFillWhite;
    }

    private void Update()
    {
        _gaugeFill.rectTransform.localScale = new Vector2(SC_CrisisGaugeManager.Instance.GetCrisisPercentage(),0);
        if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 35 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 65)
        {
            _gaugeContainer.sprite = _gaugeContainerOrange;
            _gaugeFill.sprite = _gaugeFillYellow;
        }
        else if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 65 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 100)
        {
            _gaugeContainer.sprite = _gaugeContainerRed;
            _gaugeFill.sprite = _gaugeFillOrange;
        }
    }
}
