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
//            ResetModel();
           
            Core.AnimRange = Global.Interval.Create(0, Time(timeline.Movements.Max(m => m.End)));

            foreach (var mov in timeline.Movements)
            {
                var facialControl = Controls[mov.ObjectId];
                var node = Core.GetINodeByName(facialControl.NodeName);
                var centerPosition = ExtractNodePosition(Core.GetINodeByName(facialControl.CenterNodeName), 0);

                var startTime = Time(mov.Start);
                var endTime = Time(mov.End);

                Core.SetTime(startTime, false);
                
                var animation = (IControl) SelectAnimationLayer(node.TMController.PositionController);

                var posControl = animation.XController;

                var xKeys = (IIKeyControl) animation.XController.GetInterface(InterfaceID.Keycontrol);
                var yKeys = (IIKeyControl) animation.YController.GetInterface(InterfaceID.Keycontrol);
                var zKeys = (IIKeyControl) animation.ZController.GetInterface(InterfaceID.Keycontrol);

                var x_0 = CreatePoint4Key();
                var x_1 = CreatePoint4Key();
                xKeys.GetKey(0, x_0);
                xKeys.GetKey(1, x_1);

                var y_0 = CreatePoint4Key();
                var y_1 = CreatePoint4Key();
                yKeys.GetKey(0, y_0);
                yKeys.GetKey(1, y_1);

                var z_0 = CreatePoint4Key();
                var z_1 = CreatePoint4Key();
                zKeys.GetKey(0, z_0);
                zKeys.GetKey(1, z_1);

                ResetModel();

                var existedStartKeyIndex = posControl.GetKeyIndex(startTime);
                if (existedStartKeyIndex == -1)
                {
                    var startXKey = CreatePoint4Key();
                    var startYKey = CreatePoint4Key();
                    var startZKey = CreatePoint4Key();
                    
                    startXKey.Time = startTime;
                    startYKey.Time = startTime;
                    startZKey.Time = startTime;

                    var position = ExtractNodePosition(node, startTime);
                    startXKey.Val = x_0.Val;
                    startXKey.Val.W = position.Item1;
                    startYKey.Val = y_0.Val;
                    startYKey.Val.W = position.Item2;
                    startZKey.Val = z_0.Val;
                    startZKey.Val.W = position.Item3;

                    xKeys.AppendKey(startXKey);
                    yKeys.AppendKey(startYKey);
                    zKeys.AppendKey(startZKey);
                }
                
                Core.SetTime(endTime, false);

                var endXKey = CreatePoint4Key();
                var endYKey = CreatePoint4Key();
                var endZKey = CreatePoint4Key();
                
                endXKey.Time = endTime;
                endYKey.Time = endTime;
                endZKey.Time = endTime;

                endXKey.Val = x_0.Val;
                endXKey.Val.W = centerPosition.Item1;
                endYKey.Val = y_0.Val;
                endYKey.Val.W = centerPosition.Item2;
                endZKey.Val = z_0.Val;
                endZKey.Val.W = centerPosition.Item3 - 5f;

                xKeys.AppendKey(endXKey);
                yKeys.AppendKey(endYKey);
                zKeys.AppendKey(endZKey);
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

        private static IIBezFloatKey CreateBezFloatKey()
        {
            var key = Global.IBezFloatKey.Create();
            key.Intan = key.Outtan = 0;
            key.InLength = 1;
            key.OutLength = -1;

            key.Flags = 0x00001B00;

            return key;
        }
        private static IIBezPoint4Key CreatePoint4Key()
        {
            var key = Global.IBezPoint4Key.Create();
            
            return key;
        }

        private static Tuple<float, float, float> ExtractNodePosition(IINode node, int time)
        {
            var tm = node.GetNodeTM(time, null);
            var x = tm.GetColumn(0).W;
            var y = tm.GetColumn(1).W;
            var z = tm.GetColumn(2).W;

            return Tuple.Create(x, y, z);
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
