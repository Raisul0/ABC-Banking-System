using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIEntity;

namespace APIInterface
{
    public interface ITOfficerRepository
    {
        List<TOfficer> GetAll();
        TOfficer Get(int TO_accId);
        int Insert(TOfficer TOfficer);
        int Update(TOfficer TOfficer);
        int Delete(int TO_accId);
    }
}
