using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingTutorial.Models;

namespace UnitTestingTutorial.ServiceAgent
{
    public class CommunityManager : ICommunityManager
    {
        public List<CommunityModel> GetCommunities()
        {
            List<CommunityModel> result = new List<CommunityModel>();
            result.Add(new CommunityModel { ID = 1, Name = "Pramod" });
            result.Add(new CommunityModel { ID = 2, Name = "Pramod 1" });
            result.Add(new CommunityModel { ID = 3, Name = "Pramod 2" });
            result.Add(new CommunityModel { ID = 4, Name = "Pramod 3" });
            result.Add(new CommunityModel { ID = 5, Name = "Pramod 4" });
            return result;
        }
    }
}