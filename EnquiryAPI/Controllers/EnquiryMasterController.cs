using System.Diagnostics.Eventing.Reader;
using Azure;
using EnquiryAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnquiryAPI.Controllers
{
    [EnableCors("allowCors")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class EnquiryMasterController : ControllerBase
    {
        private readonly EnquiryDbContext _context;

        public EnquiryMasterController(EnquiryDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllStatus")]
        public List<EnquiryStatus> GetEnquiryStatus() { 
            var list = _context.EnquiryStatus.ToList();
            return list;
        }

        [HttpGet("GetAllTypes")]
        public List<EnquiryType> GetEnquiryType() { 
            var list = _context.EnquiryType.ToList();
            return list;
        }

        [HttpGet("GetAllEnquiry")]
        public List<EnquiryModel> GetEnquiryModel() {
            var list = _context.EnquiryModel.ToList();
            return list;
        }

        [HttpPost("CreateNewEnquiry")]
        public EnquiryModel AddNewEnquiry(EnquiryModel obj)
        {
            //try {
                obj.createdDate = DateTime.Now;
                _context.EnquiryModel.Add(obj);
                _context.SaveChanges();
                return obj;
            //}
            //catch ()
            //{
            //    throw;
            //}
            
        }

        [HttpPut("UpdateEnquiry")]
        public EnquiryModel UpdateEnquiry(EnquiryModel obj)
        {
            var record = _context.EnquiryModel.SingleOrDefault(m => m.enquiryId == obj.enquiryId);
            if (record != null) {
                record.resolution = obj.resolution;
                record.enquiryStatusId = obj.enquiryStatusId;
                _context.SaveChanges();
            } 
            return obj;
        }

        [HttpDelete("DeleteEnquiryById")]
        public bool DeleteEnquiry(int id)
        {
            var record = _context.EnquiryModel.SingleOrDefault(m => m.enquiryId == id);
            if (record != null)
            {
                _context.EnquiryModel.Remove(record);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
