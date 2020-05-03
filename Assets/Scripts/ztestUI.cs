using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
 [ExecuteInEditMode]
public class ztestUI : MonoBehaviour
{
    public UnityEngine.Rendering.CompareFunction comparison = UnityEngine.Rendering.CompareFunction.Always;

    void Start()
    {
        Image img = this.gameObject.GetComponent<Image>();
        Material existingGlobalMat = img.materialForRendering;
        Material updatedMaterial = new Material(existingGlobalMat);
        updatedMaterial.SetInt("unity_GUIZTestMode", (int)comparison);
        img.material = updatedMaterial;
    }

}