using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    public static UnitManager Instance;

    private List<ScriptableUnit> _units;
    
    void Awake() {
        Instance = this;

        // _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }

    public void SpawnUnits() {
        var unitsCount = 3;

        for (int i = 0; i < unitsCount; i++) {

        }
    }
}
