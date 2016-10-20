using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingTutorial.Models;

namespace UnitTestingTutorial.ServiceAgent
{
    public interface ICommunityManager
    {
        List<CommunityModel> GetCommunities();
    }
}
