using AutoMapper;
using IMS_API.Model;

namespace IMS_API.common
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<QuotationDTO, Quotation>().ReverseMap();
        }
    }
}
