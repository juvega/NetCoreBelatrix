using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Filters
{
    public class CustomerResultFilterAttribute : ResultFilterAttribute
    {
        private readonly IMapper _mapper;
        public CustomerResultFilterAttribute(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if(resultFromAction?.Value==null 
                || resultFromAction .StatusCode<200
                || resultFromAction.StatusCode>=300)
            {
                await next();
                return;
            }

            //if(typeof(IEnumerable).IsAssignableFrom(resultFromAction.Value.GetType()))
            //{

            //}

            resultFromAction.Value = Mapper.Map<DTO.Customer>(resultFromAction.Value);
            await next();
        }
    }
}
