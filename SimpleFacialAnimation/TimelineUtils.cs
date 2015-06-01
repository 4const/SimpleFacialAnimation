using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Autodesk.Max;

namespace SimpleFacialAnimation
{
    abstract class TimelineUtils
    {
        private static readonly IGlobal Global = GlobalInterface.Instance;
        private static readonly IInterface Core = Global.COREInterface;
        
        private static readonly Func<int, int> Time = frame => frame * Global.TicksPerFrame;

        private static readonly Dictionary<string, FacialControl> Controls = new Dictionary<string, FacialControl>()
        {
            { "l_eyebrow", new FacialControl("Body_BFMG1p_BROW_cc_L", "Body_BFMG2p_BROW_cc_L") },
            { "lt_eyelid", new FacialControl("Body_BFMG1p_IU_EYE_L", "Body_BFMG2p_IU_EYE_L") },
            { "lb_eyelid", new FacialControl("Body_BFMG1p_ID_EYE_L", "Body_BFMG2p_ID_EYE_L") },
            
            { "r_eyebrow", new FacialControl("Body_BFMG1p_BROW_cc_R", "Body_BFMG2p_BROW_cc_R") },
            { "rt_eyelid", new FacialControl("Body_BFMG1p_IU_EYE_R", "Body_BFMG2p_IU_EYE_R") },
            { "rb_eyelid", new FacialControl("Body_BFMG1p_ID_EYE_R", "Body_BFMG2p_ID_EYE_R") },

            { "t_lip", new FacialControl("Body_BFMG1p_MOUTH_U_cc", "Body_BFMG2p_MOUTH_U_cc") },
            { "b_lip", new FacialControl("Body_BFMG1p_MOUTH_D_cc", "Body_BFMG2p_MOUTH_D_cc") },
            { "jaw", new FacialControl("Body_BFMG1p_JAW_cc", "Body_BFMG2p_JAW_cc") },
            
            { "l_lipangle", new FacialControl("Body_BFMG1p_MOUTH_L_cc", "Body_BFMG2p_MOUTH_L_cc") },
            { "r_lipangle", new FacialControl("Body_BFMG1p_MOUTH_R_cc", "Body_BFMG2p_MOUTH_R_cc") }
        };
        
        public static void ApplyTimeline(Timeline timeline)
        {
            ResetModel();
           
            Core.AnimRange = Global.Interval.Create(0, Time(timeline.Movements.Max(m => m.End)));
            foreach (var mov in timeline.Movements)
            {
                var facialControl = Controls[mov.ObjectId];
                var node = Core.GetINodeByName(facialControl.NodeName);
                var centerPosition = Core.GetINodeByName(facialControl.CenterNodeName).GetNodeTM(0, null).Trans;

                var startTime = Time(mov.Start);
                var endTime = Time(mov.End);

                Core.SetTime(startTime, false);

                var posController = node.TMController.PositionController;
                var animation = SelectAnimationLayer(posController);

                var keys = (IIKeyControl) posController.GetInterface(InterfaceID.Keycontrol);
                
                var startKey = Global.ITCBPoint3Key.Create();                
                var existedStartKeyIndex = animation.GetKeyIndex(startTime);
                if (existedStartKeyIndex != -1)
                {
                    keys.GetKey(existedStartKeyIndex, startKey);
                }
                else
                {
                    keys.AppendKey(startKey);
                }
                
                startKey.Time = startTime;
                startKey.Val = node.GetNodeTM(startTime, null).Trans;

                Core.SetTime(endTime, false);

                var endKey = Global.ITCBPoint3Key.Create();
                var existedEndKeyIndex = animation.GetKeyIndex(startTime);
                if (existedEndKeyIndex != -1)
                {
                    keys.GetKey(existedStartKeyIndex, endKey);
                }
                else
                {
                    keys.AppendKey(endKey);
                }

                endKey.Time = endTime;
                var endPosition = Global.Point3.Create(centerPosition);
                endPosition.Z += float.Parse(mov.Value) * 0.01f;
                endKey.Val = endPosition;
            }
            
            Core.SetTime(0, true);
        }

        public static bool HasIntersection(IEnumerable<Movement> movements, Movement movement)
        {
            Predicate<Movement> hasSame = m => m.ObjectId == movement.ObjectId &&
                (m.Start <= movement.Start && movement.Start < m.End ||
                m.Start < movement.End && movement.End <= m.End);

            return Contract.Exists(movements, hasSame);
        }

        public static void PlayAnimation()
        {
            if (Core.IsAnimPlaying)
            {
                Core.EndAnimPlayback();
            }
            else
            {
                Core.SetTime(0, true);
                Core.StartAnimPlayback(0);   
            }            
        }

        public static void ResetModel()
        {
            Core.SetTime(0, true);
            Core.EndAnimPlayback();

            foreach (var control in Controls.Values)
            {
                var node = Core.GetINodeByName(control.NodeName);
                var centerNode = Core.GetINodeByName(control.CenterNodeName);
                node.SetNodeTM(0, centerNode.GetNodeTM(0, null)); 
                
                ClearKeys(node);
            }
        }

        private static IAnimatable SelectAnimationLayer(IAnimatable animatable)
        {
            for (var i = 0; i < animatable.NumSubs; i++)
            {
                if (animatable.SubAnimName(i) == "Animation")
                {
                    animatable.SelectSubAnim(i);
                    return animatable.SubAnim(i);
                }
            }

            return null;
        }

        private static void ClearKeys(IINode node)
        {
            Action<IControl> deleteKeys = c =>
            {
                Action<IAnimatable> delete = a => { while (a.NumKeys > 0) a.DeleteKeyByIndex(0); };

                for (var i = 0; i < c.NumSubs; i++)
                {
                    var anim = c.SubAnim(i);
                    delete(anim);
                }
                delete(c);
            };

            var posControl = node.TMController.PositionController;
            var rotControl = node.TMController.RotationController;
            var sclControl = node.TMController.ScaleController;

            deleteKeys(posControl);
            deleteKeys(rotControl);
            deleteKeys(sclControl);
        }

        private class FacialControl
        {
            public FacialControl(string nodeName, string centerNodeName)
            {
                NodeName = nodeName;
                CenterNodeName = centerNodeName;
            }

            public string NodeName { get; private set; }
            public string CenterNodeName { get; private set; }
        }
    }
}
