using System;
using System.Linq;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.Utilities;
using UnityEngine.Perception.Randomization.Samplers;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Creates a 2D layer of of evenly spaced GameObjects from a given list of prefabs
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Foreground Object Placement Randomizer 3D")]
    public class ForegroundObjectPlacementRandomizer3D : Randomizer
    {

        public int maxInstances;

        /// <summary>
        /// The list of prefabs sample and randomly place
        /// </summary>
        [Tooltip("The list of furniture Prefabs to be placed by this Randomizer.")]
        public GameObjectParameter furniturePrefabs;


        /// <summary>
        /// The list of prefabs sample and randomly place
        /// </summary>
        [Tooltip("The list of Prefabs to be placed by this Randomizer.")]
        public GameObjectParameter prefabs;

        GameObject m_Container;
        GameObjectOneWayCache m_GameObjectOneWayCache;
        /// <inheritdoc/>
        protected override void OnAwake()
        {
            m_Container = new GameObject("Foreground Objects");
            m_Container.transform.parent = scenario.transform;
            m_GameObjectOneWayCache = new GameObjectOneWayCache(
                m_Container.transform, prefabs.categories.Select(element => element.Item1).ToArray().Concat(furniturePrefabs.categories.Select(element => element.Item1).ToArray()).ToArray(), this);
        }

        /// <summary>
        /// Generates a foreground layer of objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            /*
            var seed = SamplerState.NextRandomState();
            var placementSamples = PoissonDiskSampling.GenerateSamples(
                placementRange.x, placementRange.y, placementRange.z, seed);
            var offset = new Vector3(placementLocation.x, placementLocation.y, placementLocation.z);
            foreach (var sample in placementSamples)
            {
                var instance = m_GameObjectOneWayCache.GetOrInstantiate(prefabs.Sample());
                instance.transform.position = new Vector3(sample.x, 0, sample.y) + offset;
            }
            placementSamples.Dispose();
            */
            var seed = SamplerState.NextRandomState();
            Random.InitState((int)seed);
            FurnitureObject furniture = m_GameObjectOneWayCache.GetOrInstantiate(furniturePrefabs.Sample()).GetComponent<FurnitureObject>();
            furniture.transform.position = new Vector3(0f, 0f, 4.0f);
            for (int i = 0; i < maxInstances; i++) {
                int anchorIndex = Random.Range(0, furniture.anchors.Count());
                AnchorPoint anchor = furniture.anchors[anchorIndex];
                Vector3 placementRange = anchor.placementRange;
                Vector3 placementLocation = anchor.transform.position;
                var offset = new Vector3(Random.Range(-placementRange.x, placementRange.x), Random.Range(-placementRange.y, placementRange.y), Random.Range(-placementRange.z, placementRange.z));
                var instance = m_GameObjectOneWayCache.GetOrInstantiate(prefabs.Sample());
                instance.transform.position = new Vector3(placementLocation.x, placementLocation.y, placementLocation.z) + offset;
            }
        }

        /// <summary>
        /// Deletes generated foreground objects after each scenario iteration is complete
        /// </summary>
        protected override void OnIterationEnd()
        {
            m_GameObjectOneWayCache.ResetAllObjects();
        }
    }
}