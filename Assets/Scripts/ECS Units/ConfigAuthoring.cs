using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ConfigAuthoring : MonoBehaviour
{
    public GameObject UnitPrefab;
    public float UnitScale;
    public float UnitSpawnRate;

    class Baker : Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.None);
            AddComponent(entity, new Config
            {
                UnitPrefab = GetEntity(authoring.UnitPrefab),
                UnitScale = authoring.UnitScale,
                UnitSpawnRate = authoring.UnitSpawnRate
            });
        }
    }
}

public struct Config : IComponentData
{

    public float UnitScale;
    public float UnitSpawnRate;
    public Entity UnitPrefab;

}