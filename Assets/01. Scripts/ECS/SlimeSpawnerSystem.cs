using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial struct SlimeSpawnerSystem : ISystem
{
    private bool _isEnabled;
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SlimeSpawnerComponentData>();
        _isEnabled = true;
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (!_isEnabled) return;    

        _isEnabled = false;

        Entity slimeSpanwerEntity = SystemAPI.GetSingletonEntity<SlimeSpawnerComponentData>();
        var slimeSpawnerAspect = SystemAPI.GetAspect<SlimeSpawnerAspect>(slimeSpanwerEntity);

        for(int idx = 0; idx < slimeSpawnerAspect.Count; ++idx)
        {
            float3 randomPos = slimeSpawnerAspect.GetRandomSpawnPostion();
            Entity slimeEntity = state.EntityManager.Instantiate(slimeSpawnerAspect.SlimePrefab);
            state.EntityManager.SetComponentData(slimeEntity, LocalTransform.FromPosition(randomPos));
            Debug.Log(randomPos);
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state) { }
}
