using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public MeshRenderer mesh;
    [SerializeField] Material Selected;
    Material Original;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        Original = mesh.material;
    }
    public void OnEyeGaze()
    {
        mesh.material = Selected;
    }

    public void OffEyeGaze()
    {
        mesh.material = Original;
    }

}
