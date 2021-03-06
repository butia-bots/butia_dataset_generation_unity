using System;

namespace UnityEngine.Perception.GroundTruth
{
    /// <summary>
    /// Describes an instance of an object in an instance segmentation frame.
    /// Generated by <see cref="RenderedObjectInfoGenerator"/>.
    /// </summary>
    public struct RenderedObjectInfo : IEquatable<RenderedObjectInfo>
    {
        /// <summary>
        /// The instanceId of the rendered object.
        /// </summary>
        public uint instanceId;
        /// <summary>
        /// The bounding box of the object in pixel coordinates.
        /// </summary>
        public Rect boundingBox;
        /// <summary>
        /// The number of pixels in the image matching this instance.
        /// </summary>
        public int pixelCount;
        /// <summary>
        /// The unique RGBA color for the instance.
        /// </summary>
        public Color32 instanceColor;

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(instanceId)}: {instanceId}, {nameof(boundingBox)}: {boundingBox}, " +
                $"{nameof(pixelCount)}: {pixelCount}, {nameof(instanceColor)}: {instanceColor}";
        }

        /// <inheritdoc />
        public bool Equals(RenderedObjectInfo other)
        {
            return instanceId == other.instanceId &&
                boundingBox.Equals(other.boundingBox) &&
                pixelCount == other.pixelCount;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is RenderedObjectInfo other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                var hashCode = (int)instanceId;
                hashCode = (hashCode * 397) ^ boundingBox.GetHashCode();
                hashCode = (hashCode * 397) ^ pixelCount;
                return hashCode;
            }
        }
    }
}
