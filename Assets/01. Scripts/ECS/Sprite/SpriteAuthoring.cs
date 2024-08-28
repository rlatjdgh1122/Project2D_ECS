using NSprites;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

[assembly: InstancedPropertyComponent(typeof(WorldPosition2D), "_pos2D")]
[assembly: InstancedPropertyComponent(typeof(SpriteColor), "_color")]

public struct WorldPosition2D : IComponentData
{
    public float2 Value;
}

public struct SpriteColor : IComponentData
{
    public Color Value;
}

public class SpriteAuthoring : MonoBehaviour
{
    [SerializeField] private GameObject _spriteEntity;
    [SerializeField] private int _renderID;

    public GameObject spriteEntity => _spriteEntity;
    public int RenderID => _renderID;

    public void Awake()
    {

    }
    private class Baker : Baker<SpriteAuthoring>
    {
        public override void Bake(SpriteAuthoring authoring)
        {
            var spriteEntity = GetEntity(TransformUsageFlags.None);

            //entityManager.AddSpriteRenderComponents(spriteEntity, renderID);
            // WorldPosition2D and SpriteColor are example client's components
            //entityManager.AddComponentData(spriteEntity, new WorldPosition2D { Value = new float2(0, 0) });
            //.AddComponentData(spriteEntity, new SpriteColor { Value = Color.white });
            AddComponent(spriteEntity, new WorldPosition2D { Value = new float2(authoring.transform.position.x, authoring.transform.position.y) });
            AddComponent(spriteEntity, new SpriteColor { Value = Color.white });
            //this.AddSpriteComponents(authoring.RenderID); // Render ID is client defined unique per-render archetype int. You can define it manually or for example use Material's instance ID or whatever else.
        }
    }
}

