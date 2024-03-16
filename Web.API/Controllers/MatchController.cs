using AutoMapper;
using BuisnessLogic.Contracts.Match;
using BuisnessLogic.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<MatchDto>> Get()
        {
            return await _matchService.GetAllAsync();
        }
    }
}
