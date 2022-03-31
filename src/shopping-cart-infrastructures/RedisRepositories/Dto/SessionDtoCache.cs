using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart_infrastructures.RedisRepositories.Dto
{
    [Serializable]
    public class SessionCacheDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SessionId { get; set; }
        public List<string> Permission { get; set; }
        public bool IsAdmin { get; set; }
        public Guid RoleId { get; set; }
    }
}
