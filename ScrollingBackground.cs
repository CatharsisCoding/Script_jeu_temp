using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;

    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Défilement continu de l'arrière-plan
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
