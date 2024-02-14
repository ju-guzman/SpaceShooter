using System.Collections;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Color[] color;
    [SerializeField] private SpriteRenderer[] spriteRenderer;
    [SerializeField] private float secondsByTransition = 1f;

    private int currentColor = 0;

    void Start()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnLevelUp += SetColor;
            foreach (SpriteRenderer sprite in spriteRenderer)
            {
                sprite.color = color[currentColor];
            }
        }
    }

    private void SetColor()
    {
        int previousColor = currentColor;
        currentColor++;
        currentColor %= color.Length;
        StartCoroutine(ChangeColorGradually(previousColor));
    }

    //Corrutina que cambia el color de fondo de forma gradual
    private IEnumerator ChangeColorGradually(int previousColor)
    {
        Color currentColor = color[previousColor];
        Color targetColor = color[this.currentColor];
        float time = 0;
        while (time < secondsByTransition)
        {
            time += Time.deltaTime;
            foreach (SpriteRenderer sprite in spriteRenderer)
            {
                sprite.color = Color.Lerp(currentColor, targetColor, (time / secondsByTransition));
            }
            yield return null;
        }
    }

    private void SetColor(int level)
    {
        SetColor();
    }
}
