using UnityEngine;

public class Area : HitResponder
{
    protected override void Start()
    {
        // Call HitResponder.Start() to ensure that setup runs first
        base.Start();
    }
}
