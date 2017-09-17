using Sorschia.Entities;

namespace Sorschia.DevTeam.Entities
{
    public sealed class TeamMemberCollection : EntityCollection<TeamMember, long>, ITeamMemberCollection
    {
        public TeamMemberCollection(Team team)
        {
            Team = team ?? throw new SorschiaException(nameof(team), SorschiaExceptionType.UnexpectedNull);
        }

        public Team Team { get; }

        protected override void UnsafeAdd(TeamMember item)
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

        protected override bool UnsafeRemove(TeamMember item)
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
