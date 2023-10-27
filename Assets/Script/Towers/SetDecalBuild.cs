using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SetDecalBuild : MonoBehaviour
{
    public TowerSO towerso;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<DecalProjector>().size = new Vector3(towerso.range1 + towerso.range1, towerso.range1 + towerso.range1, 1f);
    }

}
