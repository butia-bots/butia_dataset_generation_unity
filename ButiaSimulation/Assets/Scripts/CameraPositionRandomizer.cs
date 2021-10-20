using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

[Serializable]
[AddRandomizerMenu("Perception/Camera Position Randomizer")]
public class CameraPositionRandomizer : Randomizer
{
    public float placementZPosition;

    public Vector2 placementArea;

    public FloatParameter cameraZParameter;

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<CameraPositionRandomizerTag>();

        foreach (var tag in tags)
        {
            var t = tag.GetComponent<Transform>();
            var pitch = t.eulerAngles.x;
            var yaw = t.eulerAngles.y;
            var roll = t.eulerAngles.z;
            var x = t.position.x;
            var y = t.position.y;
            var z = t.position.z;

            var new_z = cameraZParameter.Sample();

            var c = tag.GetComponent<Camera>();
            var half_fov = c.fieldOfView/2.0;

            var distance = Math.Abs(placementZPosition - new_z);

            var length_y = Math.Abs(Math.Tan(half_fov*Math.PI/180.0)*distance);

            var max_y = (float) (placementArea.y/2.0 - length_y);
            var max_x = (float) (max_y*1.33);

            var new_y = new UniformSampler(-max_y, max_y);
            var new_x = new UniformSampler(-max_x, max_x);

            t.position = new Vector3(new_x.Sample(), new_y.Sample(), new_z);            
        }
    }
}
