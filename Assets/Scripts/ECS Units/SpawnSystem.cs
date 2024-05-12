using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using Unity.VisualScripting.FullSerializer;
using UnityEngine.Rendering.VirtualTexturing;
using Random = Unity.Mathematics.Random;
public partial struct SpawnSystem : ISystem
{
    public float timer;
    public Random rand;
    // Start is called before the first frame update
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
        rand = new Random(1);

        timer = 0f;
    }

    // Update is called once per frame
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var config = SystemAPI.GetSingleton<Config>();
        timer += SystemAPI.Time.DeltaTime;

        var UnitsEntities = new NativeList<Entity>(Allocator.Temp);
        if (timer >= config.UnitSpawnRate)
        {
            var UnitEntity = state.EntityManager.Instantiate(config.UnitPrefab);
            var EntityTransform = state.EntityManager.GetComponentData<LocalTransform>(UnitEntity);
            var unit = state.EntityManager.GetComponentData<Unit>(UnitEntity);

            EntityTransform.Scale = config.UnitScale;
            EntityTransform.Position = new float3(rand.NextFloat(-5, 5), 0, rand.NextFloat(-5, 5));
            unit.TargetPosition = new float3(rand.NextFloat(-5, 5), 0, rand.NextFloat(-5, 5));
            unit.Speed = rand.NextFloat(0.5f, 3f);
            state.EntityManager.SetComponentData(UnitEntity, EntityTransform);
            state.EntityManager.SetComponentData(UnitEntity, unit); // Réaffecter la Unit modifiée à l'entité
            timer = 0f;
        }
    }
}
