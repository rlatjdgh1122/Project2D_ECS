using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public readonly partial struct SlimeSpawnerAspect : IAspect
{
    private readonly RefRW<SlimeSpawnerComponentData> _bulletSpawnerComponentData;

    public Entity SlimePrefab => _bulletSpawnerComponentData.ValueRO.SlimePrefab;
    public int Count => _bulletSpawnerComponentData.ValueRO.Count;

    public float3 GetRandomSpawnPostion()
    {
        uint idx = _bulletSpawnerComponentData.ValueRW.Instance.NextUInt(UInt32.MaxValue);
        _bulletSpawnerComponentData.ValueRW.Instance = Random.CreateFromIndex(idx);
        float randomPostionX = _bulletSpawnerComponentData.ValueRW.Instance.NextFloat(-10, 10);
        float randomPostionY = _bulletSpawnerComponentData.ValueRW.Instance.NextFloat(-10, 10);
        return new float3(randomPostionX, randomPostionY, 0);
    }
}
