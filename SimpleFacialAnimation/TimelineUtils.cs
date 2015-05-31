using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Autodesk.Max;

namespace SimpleFacialAnimation
{
    abstract class TimelineUtils
    {
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

        public static bool HasIntersection(IEnumerable<Movement> movements, Movement movement)
        {
            Predicate<Movement> hasSame = m => m.ObjectId == movement.ObjectId &&
                (m.Start <= movement.Start && movement.Start < m.End ||
                m.Start < movement.End && movement.End <= m.End);

            return Contract.Exists(movements, hasSame);
        }

        public static void PlayAnimation()
        {
            var global = GlobalInterface.Instance;
            var itf = global.COREInterface;
            if (itf.IsAnimPlaying)
            {
                itf.EndAnimPlayback();
            }
            else
            {
                itf.SetTime(0, true);
                itf.StartAnimPlayback(0);   
            }            
        }

        public static void ResetModel()
        {
            var global = GlobalInterface.Instance;
            var itf = global.COREInterface;

            itf.SetTime(0, true);
            itf.EndAnimPlayback();

            var interval = itf.AnimRange;       
            foreach (var control in Controls.Values)
            {
                var node = itf.GetINodeByName(control.NodeName);
                var centerNode = itf.GetINodeByName(control.CenterNodeName);
                node.SetNodeTM(0, centerNode.GetNodeTM(0, null));                             
            }
        }

        public static void TestFuck()
        {
            var global = GlobalInterface.Instance;
            var itf = global.COREInterface;

            itf.SetTime(0, true);
            itf.EndAnimPlayback();
            var node = itf.GetINodeByName("S001");
            node.TMController.PositionController.GetInterface(InterfaceID.Keycontrol);
            itf.SelectNode(node, true);
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
