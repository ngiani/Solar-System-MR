/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Oculus.Interaction.Samples
{
    /// <summary>
    /// It is not expected that typical users of the SlateWithManipulators prefab
    /// should need to either interact with or understand this script.
    ///
    /// This is a specialized transformer for scaling based on a single grab,
    /// canonically from an affordance such as the corner affordances on the
    /// SlateWithManipulators prefab.
    /// </summary>
    public class TwoGrabScaleTransformer : MonoBehaviour, ITransformer
    {
        [SerializeField] Transform _transformToScale;

        [Serializable]
        public class TwoGrabScaleConstraints
        {
            public bool IgnoreFixedAxes;
            public bool ConstrainXYAspectRatio;
            public FloatConstraint MinX;
            public FloatConstraint MaxX;
            public FloatConstraint MinY;
            public FloatConstraint MaxY;
            public FloatConstraint MinZ;
            public FloatConstraint MaxZ;
        }

        [SerializeField, Tooltip("Constraints for allowable values on different axes")]
        private TwoGrabScaleConstraints _constraints =
            new TwoGrabScaleConstraints()
            {
                IgnoreFixedAxes = false,
                ConstrainXYAspectRatio = false,
                MinX = new FloatConstraint(),
                MaxX = new FloatConstraint(),
                MinY = new FloatConstraint(),
                MaxY = new FloatConstraint(),
                MinZ = new FloatConstraint(),
                MaxZ = new FloatConstraint()
            };

        public TwoGrabScaleConstraints Constraints
        {
            get
            {
                return _constraints;
            }

            set
            {
                _constraints = value;
            }
        }

        private Vector3 _initialLocalScale;
        //private Vector3 _initialLocalPosition;

        private IGrabbable _grabbable;

        private float _initialPointsDistance;

        public UnityEvent StartedScaling;
        public UnityEvent EndScaling;

        public void Initialize(IGrabbable grabbable)
        {
            _grabbable = grabbable;

            StartedScaling = new UnityEvent();
            EndScaling = new UnityEvent();
        }

        public void BeginTransform()
        {
            var grabPoint_0 = _grabbable.GrabPoints[0];
            var grabPoint_1 = _grabbable.GrabPoints[1];

            _initialPointsDistance = Vector3.Distance(grabPoint_0.position, grabPoint_1.position);

            var targetTransform = _transformToScale == null ? _grabbable.Transform : _transformToScale;
            //_initialLocalPosition = targetTransform.InverseTransformPointUnscaled(grabPoint.position);
            _initialLocalScale = targetTransform.localScale;

            StartedScaling?.Invoke();

        }

        public void UpdateTransform()
        {
            var grabPoint_0 = _grabbable.GrabPoints[0];
            var grabPoint_1 = _grabbable.GrabPoints[1];

            var targetTransform = _transformToScale == null ? _grabbable.Transform : _transformToScale;

            //var localPosition = targetTransform.InverseTransformPointUnscaled(grabPoint.position);
            var pointsDistance = Vector3.Distance(grabPoint_0.position, grabPoint_1.position);


            float newLocalScaleX = _initialLocalScale.x *  (pointsDistance  / _initialPointsDistance);
            float newLocalScaleY = _initialLocalScale.y * (pointsDistance / _initialPointsDistance);
            float newLocalScaleZ = _initialLocalScale.z * (pointsDistance / _initialPointsDistance);


            if (_constraints.MinX.Constrain)
            {
                newLocalScaleX = Mathf.Max(_constraints.MinX.Value, newLocalScaleX);
            }
            if (_constraints.MinY.Constrain)
            {
                newLocalScaleY = Mathf.Max(_constraints.MinY.Value, newLocalScaleY);
            }
            if (_constraints.MinZ.Constrain)
            {
                newLocalScaleZ = Mathf.Max(_constraints.MinZ.Value, newLocalScaleZ);
            }
            if (_constraints.MaxX.Constrain)
            {
                newLocalScaleX = Mathf.Min(_constraints.MaxX.Value, newLocalScaleX);
            }
            if (_constraints.MaxY.Constrain)
            {
                newLocalScaleY = Mathf.Min(_constraints.MaxY.Value, newLocalScaleY);
            }
            if (_constraints.MaxZ.Constrain)
            {
                newLocalScaleZ = Mathf.Min(_constraints.MaxZ.Value, newLocalScaleZ);
            }

            if (_constraints.IgnoreFixedAxes)
            {
                if (_constraints.MinX.Constrain && _constraints.MaxX.Constrain && _constraints.MinX.Value == _constraints.MaxX.Value)
                {
                    newLocalScaleX = targetTransform.localScale.x;
                }
                if (_constraints.MinY.Constrain && _constraints.MaxY.Constrain && _constraints.MinY.Value == _constraints.MaxY.Value)
                {
                    newLocalScaleY = targetTransform.localScale.y;
                }
                if (_constraints.MinZ.Constrain && _constraints.MaxZ.Constrain && _constraints.MinZ.Value == _constraints.MaxZ.Value)
                {
                    newLocalScaleZ = targetTransform.localScale.z;
                }
            }

            if (_constraints.ConstrainXYAspectRatio)
            {
                if (newLocalScaleX / newLocalScaleY < _initialLocalScale.x / _initialLocalScale.y)
                {
                    newLocalScaleY = newLocalScaleX * _initialLocalScale.y / _initialLocalScale.x;
                }
                else
                {
                    newLocalScaleX = newLocalScaleY * _initialLocalScale.x / _initialLocalScale.y;
                }
            }

            targetTransform.localScale = new Vector3(newLocalScaleX, newLocalScaleY, newLocalScaleZ);
        }

        public void EndTransform() 
        {
            EndScaling?.Invoke();
        }
    }
}

