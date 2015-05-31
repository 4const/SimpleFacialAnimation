using UiViewModels.Actions;

namespace SimpleFacialAnimation
{
    public class FacialAnimationCommander : CuiActionCommandAdapter
    {
       private SimpleFacialAnimationForm dlg = new SimpleFacialAnimationForm();

        public override string ActionText
        {
            get { return "SFA"; }
        }

        public override string Category
        {
            get { return InternalCategory; }
        }

        public override void Execute(object parameter)
        {
            dlg.Show();
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
