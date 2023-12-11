using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlidingMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public Button toggleButton;
    public float slideSpeed = 5f;
    private float target;
    private bool isMenuOpen = false;

    public Color openColor;
    public Color closeColor;

    private void Start()
    {
        target = menuPanel.GetComponent<RectTransform>().rect.height * -1;
        toggleButton.onClick.AddListener(ToggleMenu);
    }

    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        StartCoroutine(SlideMenu(isMenuOpen ? target : 0));
        toggleButton.GetComponent<Image>().color = isMenuOpen ? openColor : closeColor;
    }

    private IEnumerator SlideMenu(float target)
    {
        float start = menuPanel.anchoredPosition.y;

        for (float t = 0; t < 1.0f; t += Time.deltaTime * slideSpeed)
        {
            float newY = Mathf.Lerp(start, target, t);
            menuPanel.anchoredPosition = new Vector2(menuPanel.anchoredPosition.x, newY);
            yield return null;
        }

        menuPanel.anchoredPosition = new Vector2(menuPanel.anchoredPosition.x, target);
    }
}
