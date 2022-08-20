// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class OscillateBlendFactor : MonoBehaviour
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
        var x = Time.time * this.frequency * Mathf.PI * 2f;
        var t = Mathf.InverseLerp(-1f, 1f, Mathf.Sin(x));

        this._material.SetFloat("_BlendFct", t);
    }
}
