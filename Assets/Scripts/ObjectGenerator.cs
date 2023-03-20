using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

interface IObjectGenerator
{
    int count { get; }
    Dictionary<int, Vector3> BlocksPosition { get; }
}

public abstract class ObjectGeneration : IObjectGenerator
{
    public int count { get; private set; }
    public Dictionary<int, Vector3> BlocksPosition { get; private set; }
    protected abstract int RandomSeedByVector(Vector3 vector);
    protected abstract int RandomRange(Random random, int startRange, int endRange);

    public abstract void Generate(GameObject original);
}
