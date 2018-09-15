using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveDefinition {
    public List<GameObject> Hazards;
    public List<GameObject> Friends;

    public int HazardsPerWave = 10;
    public int FriendsPerWave = 3;
}
