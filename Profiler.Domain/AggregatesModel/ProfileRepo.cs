using Profiler.Domain.SeedWork;

namespace Profiler.Domain.AggregatesModel
{
    public class ProfileRepo : Entity
    {
        #region | Properties |

        public string Name { get; set; }
        public long GithubProfileId { get; set; }

        #endregion | Properties |

        #region | Navigations |

        public virtual GithubProfile  GithubProfile { get; set; }

        #endregion | Navigations |
    }
}