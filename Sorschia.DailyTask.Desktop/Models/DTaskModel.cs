using Sorschia.DailyTask.Entity;
using Sorschia.Models;
using System;

namespace Sorschia.DailyTask.Models
{
    public sealed class DTaskModel : EntityModelBase<IDTask, long>
    {
        public DTaskModel(IDTask source) : base(source)
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

        private DateTime _ScheduledDate;
        public DateTime ScheduledDate
        {
            get { return _ScheduledDate; }
            set { SetProperty(ref _ScheduledDate, value); }
        }

        public override IDTask GetSource()
        {
            if (Source != null)
            {
                Source.Title = Title;
                Source.Description = Description;
                Source.ScheduledDate = ScheduledDate;
            }

            return base.GetSource();
        }
    }
}
