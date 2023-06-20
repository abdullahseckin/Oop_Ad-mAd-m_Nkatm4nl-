using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManagerBLL : IJobServiceBLL
    {
        IJobDAL _jobDAL;

        public JobManagerBLL(IJobDAL jobDAL)
        {
            _jobDAL = jobDAL;
        }

        public void DeleteBLL(Job t)
        {
            _jobDAL.DeleteDAL(t);
        }

        public List<Job> GetAllListBLL()
        {
            return _jobDAL.GetAllListDAL();
        }

        public Job GetListByIdBLL(int id)
        {
            return _jobDAL.GetListByIdDAL(id);
        }

        public void InsertBLL(Job t)
        {
            _jobDAL.InsertDAL(t);
        }

        public void UpdateBLL(Job t)
        {
           _jobDAL.UpdateDAL(t);
        }
    }
}
