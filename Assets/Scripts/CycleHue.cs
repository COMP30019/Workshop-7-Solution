// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CycleHue : MonoBehaviour
{
    [SerializeField] private float frequency = 1f;

    private Material _material;

    private void Start()
    {
        // Store material reference since GetComponent() is expensive
        this._material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        var t = Time.time * this.frequency % 1f;
        var color = Color.HSVToRGB(t, 1f, 1f);

        // Approach #1
        this._material.color = color;

        // Approach #2
        this._material.SetColor("_Color", color);
    }
}
