using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [Header("Hunger")]
    [SerializeField] private int hungerMax = 3;
    [SerializeField] private int hungerCurrent = 0;

    [Header("UI")]
    [SerializeField] private Slider hungerSlider;

    private void Start()
    {
        if (hungerSlider != null)
        {
            hungerSlider.maxValue = hungerMax;
            hungerSlider.value = hungerCurrent;
        }
    }

    public void FeedAnimal(int foodAmount = 1)
    {
        hungerCurrent += foodAmount;
        hungerCurrent = Mathf.Clamp(hungerCurrent, 0, hungerMax);

        if (hungerSlider != null)
        {
            hungerSlider.value = hungerCurrent;
        }

        if (hungerCurrent >= hungerMax)
        {
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}