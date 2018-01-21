using MyDayManager.Entity.Manager;
using Sorschia;

namespace MyDayManager.Entity.Provider
{
    internal sealed class AssignmentStatusProvider : IAssignmentStatusProvider
    {
        public AssignmentStatusProvider(IAssignmentStatusManager manager)
        {
            _Manager = manager;
        }

        private readonly IAssignmentStatusManager _Manager;

        private bool IsInitialize;

        public IAssignmentStatus Pending { get; private set; }
        public IAssignmentStatus Ongoing { get; private set; }
        public IAssignmentStatus Finished { get; private set; }

        public void TryInitialize()
        {
            if (!IsInitialize)
            {
                Pending = Get(nameof(Pending));
                Ongoing = Get(nameof(Ongoing));
                Finished = Get(nameof(Finished));

                IsInitialize = true;
            }
        }

        private IAssignmentStatus Get(string key)
        {
            var result = _Manager.GetByKey(key);
            return result.Data ?? throw SorschiaException.PropertyRequired(nameof(Pending));
        }
    }
}
