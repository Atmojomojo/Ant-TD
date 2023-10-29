using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SetDecalBuildCone : MonoBehaviour
{
    public TowerSO towerso;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Translate(Vector3.down * towerso.range1 / 2);
        gameObject.GetComponent<DecalProjector>().size = new Vector3(towerso.range1,towerso.range1, 1f);
    }

}
