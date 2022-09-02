using AutoMapper;
using FindMyPG.Controllers.Base;
using FindMyPG.Core.Entities;
using FindMyPG.Models;
using FindMyPG.Service.States;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPG.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StateController : BaseController
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;
        public StateController(IStateService stateService,IMapper mapper)
        {
            _stateService = stateService;
            _mapper = mapper;   
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAllStates()
        {
            var states = _stateService.GetAllStates();
            //List<StateModel> stateModels = new List<StateModel>();
            //foreach (var state in states)
            //{
            //    var stateModel=new StateModel()
            //    {
            //        Id = state.Id,
            //        Name = state.Name,
            //    };
            //    stateModels.Add(stateModel);
            //}
          var stateModels = _mapper.Map<List<StateModel>>(states);
            return Ok(stateModels);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStateById(int id)
        {
            var state = _stateService.GetStateById(id);
            //var stateModel = new StateModel()
            //{
            //    Id=state.Id,
            //    Name=state.Name,
            //};
            var stateModel = _mapper.Map<StateModel>(state); //In Background it does the above functionnality bu the AutoMapper..
            return Ok(stateModel);
        }
        [HttpPost]
        public IActionResult InsertState(StateModelRequest request)
        {
            //var state = _mapper.Map<State>(request);
            //var stateData = _stateService.GetStateByName(request.StateName);

            //if(stateData !==null)
            //{
            //    _stateService.InsertState(state);
            //    return Ok("Success");
            //}
            //Production level code Wrote below..

            if(_stateService.GetStateByName(request.StateName) == null)
            {
                _stateService.InsertState(_mapper.Map<State>(request));
                return Ok("Success");
            }
            return BadRequest("State already added");
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateState(int id,StateModelUpdateRequest request)
        {
            var state= _stateService.GetStateById(id);
            if(state !=null)
            {
                state.Name=request.StateName;
                state.IsActive = request.IsActive;

                _stateService.UpdateState(state);
                return Ok("Success");
            }
            return BadRequest("State not exits");
        }
        [HttpPost]
        [Route("Active")]
        public IActionResult GetAllActiveState()
        {
            var states=_stateService.GetAllActiveStates();
            var stateModels=_mapper.Map<List<StateModel>>(states);
            return Ok(stateModels);
        }
    }
}
