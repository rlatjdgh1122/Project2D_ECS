
using System;
using Unity.Entities;
using UnityEngine;

public class SlimeSpawnerAuthoring : MonoBehaviour
{
    [SerializeField] private GameObject _slimePrefab;
    [SerializeField] private int _slimeCount;

    public uint InitialIdx => (uint)new System.Random().Next(0, Int32.MaxValue);

    public GameObject SlimePrefab => _slimePrefab;
    public int SlimeCount => _slimeCount;
}

public class SlimeSpawnerBaker : Baker<SlimeSpawnerAuthoring>
{
    public override void Bake(SlimeSpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new SlimeSpawnerComponentData
        {
            Instance = Unity.Mathematics.Random.CreateFromIndex(authoring.InitialIdx),
            SlimePrefab = GetEntity(authoring.SlimePrefab, TransformUsageFlags.Dynamic),
            Count = authoring.SlimeCount
        });
    }
}