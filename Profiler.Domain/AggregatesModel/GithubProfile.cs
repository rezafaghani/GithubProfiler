using System.Collections.Generic;
using Profiler.Domain.SeedWork;

namespace Profiler.Domain.AggregatesModel
{
    public class GithubProfile : Entity, IAggregateRoot
    {
        #region | Properties |

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string GithubAccount { get; set; }

        #endregion | Properties |

        #region | Navigations |

        public virtual ICollection<ProfileRepo> ProfileRepos { get; set; }

        #endregion
    }
}