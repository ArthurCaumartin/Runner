using System.Collections.Generic;
using UnityEngine;

public class TerrainElement : MonoBehaviour
{
    [SerializeField] private List<TerrainSlice> _terrainSlice;
    public List<TerrainSlice> Slice { get => _terrainSlice; }
}
