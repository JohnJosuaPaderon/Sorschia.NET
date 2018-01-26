using MyDayManager.Entity;
using Sorschia.Models;
using System;

namespace MyDayManager.Models
{
    internal sealed class AssignmentModel : EntityModelBase<IAssignment, long>
    {
        public static AssignmentModel TryInitialize(IAssignment source)
        {
            return source != null ? new AssignmentModel(source) : null;
        }

        public AssignmentModel(IAssignment source) : base(source)
        {
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private AssignmentStatusModel _Status;
        public AssignmentStatusModel Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { SetProperty(ref _Date, value); }
        }

        public override IAssignment GetSource()
        {
            Source.Title = Title;
            Source.Description = Description;
            Source.Status = Status.GetSource();
            Source.Date = Date;
            return base.GetSource();
        }
    }
}
