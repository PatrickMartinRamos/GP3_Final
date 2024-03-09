using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class cardEffects : MonoBehaviour
{
    public GameObject[] _cards;
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float duration = 0.3f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = _cards[0].GetComponent<RectTransform>().localScale; // Assuming all cards have the same initial scale
    }

    private void Update()
    {
        foreach (GameObject card in _cards)
        {
            RectTransform rectTransform = card.GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
            {
                rectTransform.DOScale(hoverScale, duration);
            }
            else
            {
                rectTransform.DOScale(originalScale, duration);
            }
        }
    }
}
