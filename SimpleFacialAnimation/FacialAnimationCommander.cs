using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;
using UiViewModels.Actions;

namespace SimpleFacialAnimation
{
    public class FacialAnimationCommander : CuiActionCommandAdapter
    {
        public override string ActionText
        {
            get { return "Simple Facial Animation"; }
        }

        public override string Category
        {
            get { return InternalCategory; }
        }

        public override void Execute(object parameter)
        {
            var dlg = new SimpleFacialAnimationForm();
            dlg.ShowDialog();
        }

        public override string InternalActionText
        {
            get { return "Run SFA"; }
        }

        public override string InternalCategory
        {
            get { return "Simple Facial Animation Test"; }
        }
    }
}
