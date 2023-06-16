using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float opacity = 0.3f; // 불투명도 값

    void Start()
    {
        transform.position = new Vector3(0, 5, 0);
        transform.localScale = Vector3.one * 3.0f;

        Material material = Renderer.sharedMaterial;

        Color color = material.color;
        color = Color.yellow; // 색상을 먼저 설정
        color.a = opacity; // 알파 값을 변경
        material.color = color;

        Renderer.material = material; // 수정된 머티리얼을 다시 할당
    }

    void Update()
    {
        transform.Rotate(0.0f, 20.0f * Time.deltaTime, 0.0f);
    }
}
