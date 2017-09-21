using Sorschia.Entities;

namespace Sorschia.DevTeam.Entities
{
    public sealed class TeamMemberCollection : EntityCollection<ITeamMember, long>, ITeamMemberCollection
    {
        public TeamMemberCollection(Team team)
        {
            Team = team ?? throw new SorschiaException(nameof(team), SorschiaExceptionType.UnexpectedNull);
        }

        public ITeam Team { get; }

        protected override void UnsafeAdd(ITeamMember item)
        {
            if (item.Team != Team)
            {
                item.Team = Team;
            }

            if (!item.Teams.Contains(Team))
            {
                item.Teams.Add(Team);
            }

            base.UnsafeAdd(item);
        }

        protected override bool UnsafeRemove(ITeamMember item)
        {
            item.Team = null;

            if (item.Teams.Contains(Team))
            {
                item.Teams.Remove(Team);
            }

            return base.UnsafeRemove(item);
        }
    }
}
