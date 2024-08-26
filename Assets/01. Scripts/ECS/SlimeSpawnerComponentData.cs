using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct SlimeSpawnerComponentData : IComponentData
{
    public Unity.Mathematics.Random Instance;
    public Entity SlimePrefab;
    public int Count;
}
