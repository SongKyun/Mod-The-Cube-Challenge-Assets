using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float colorChangeInterval = 1f; // 색상 변경 간격
    public float opacityMin = 0.2f; // 최소 불투명도 값
    public float opacityMax = 1f; // 최대 불투명도 값

    private Material material;
    private Color initialColor;
    private Color targetColor;

    private float initialOpacity;
    private float targetOpacity;

    private void Start()
    {
        transform.localScale = Vector3.one * 2.0f;
        transform.position = new Vector3(0, 5, 0);


        material = Renderer.material;
        initialColor = material.color;
        initialOpacity = material.color.a;

        StartCoroutine(ChangeColorRandomly());
    }

    private void Update()
    {
        transform.Rotate(0.0f, 80.0f * Time.deltaTime, 80.0f * Time.deltaTime);
    }

    private IEnumerator ChangeColorRandomly()
    {
        while (true)
        {
            targetColor = Random.ColorHSV();
            targetOpacity = Random.Range(opacityMin, opacityMax);
            float elapsedTime = 0f;

            while (elapsedTime < colorChangeInterval)
            {
                elapsedTime += Time.deltaTime;
                Color currentColor = Color.Lerp(initialColor, targetColor, elapsedTime / colorChangeInterval);
                currentColor.a = Mathf.Lerp(initialOpacity, targetOpacity, elapsedTime / colorChangeInterval);
                material.color = currentColor;
                yield return null;
            }

            initialColor = targetColor;
            initialOpacity = targetOpacity;
        }
    }
}