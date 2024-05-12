using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class UnitAuthoring : MonoBehaviour
{

    private class Baker : Baker<UnitAuthoring>
    {
        public override void Bake(UnitAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent<Unit>(entity);
        }
    }
}

public struct Unit : IComponentData
{
    public float Speed;
    public float Scale;
    public float health;
    public float maxHealth;
    public float attack;
    public float attackRange;
    public float attackRate;
    public float3 TargetPosition;
    public float3 Position;
    public quaternion Rotation;
}