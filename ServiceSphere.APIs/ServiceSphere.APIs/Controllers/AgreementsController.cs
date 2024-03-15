using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.APIs.DTOs;
using ServiceSphere.APIs.Errors;
using ServiceSphere.core.Entities.Agreements;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Entities.Posting;
using ServiceSphere.core.Repositeries.contract;
using ServiceSphere.core.Services.contract;
using ServiceSphere.core.Specifications;
using ServiceSphere.repositery.Data;
using System.Security.Claims;
using static ServiceSphere.core.Specifications.ProposalSpecs;

namespace ServiceSphere.APIs.Controllers
{
    
    public class AgreementsController : BaseController
    {
        private readonly IGenericRepositery<Proposal> _proposalRepo;
        private readonly ServiceSphereContext _serviceSphereContext;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepositery<ServicePosting> _servicePostingsRepo;
        private readonly INotificationService _notificationService;

        public AgreementsController(IGenericRepositery<Proposal> ProposalRepo, ServiceSphereContext serviceSphereContext, IMapper mapper, UserManager<AppUser>userManager, IGenericRepositery<ServicePosting>servicePostingsRepo, INotificationService notificationService)
        {
            _proposalRepo = ProposalRepo;
            _serviceSphereContext = serviceSphereContext;
            _mapper = mapper;
            _userManager = userManager;
            _servicePostingsRepo = servicePostingsRepo;
            _notificationService = notificationService;
        }

        [HttpPost("SubmitProposalForProjectPosting")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> SubmitProposalForProjectPosting([FromBody] ProposalDto proposalDto)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound(new ApiResponse(404, "Target user not found."));
            }
            if(proposalDto.userId!=user.Id)
            {
                return Unauthorized(new ApiResponse(404, "You Mustn't submit a proposal"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Check if the ProjectPosting exists
            var projectPosting = await _serviceSphereContext.ProjectPostings.FindAsync(proposalDto.ProjectPostingId);
            if (projectPosting == null)
            {
                return NotFound($"ProjectPosting with ID {proposalDto.ProjectPostingId} not found.");
            }

            // Check if the user has already submitted a proposal for this project
            

            try
            {
                if (projectPosting.Status == PostStatus.Open)
                {
                    bool alreadySubmitted = await _serviceSphereContext.Proposals.AnyAsync(p => p.ProjectPostingId == proposalDto.ProjectPostingId && p.userId == user.Id);
                    if (alreadySubmitted)
                    {
                        return BadRequest("You have already submitted a proposal for this project.");
                    }
                    var mappedProposal = _mapper.Map<Proposal>(proposalDto);
                    await _proposalRepo.AddAsync(mappedProposal);
                    var result = await _serviceSphereContext.SaveChangesAsync();
                    if (result <= 0) { return null; }
                    return Ok(proposalDto);
                }
                else
                {
                    return BadRequest("This post is Closed, You can't submit a proposal");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the project: {ex.Message}");
            }
        }

        [HttpPost("SubmitProposalForServicePosting")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> SubmitProposalForServicePosting([FromBody] ProposalDto proposalDto)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound(new ApiResponse(404, "Target user not found."));
            }
            if (proposalDto.userId != user.Id)
            {
                return Unauthorized(new ApiResponse(404, "You aren't authorized submit a proposal"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Check if the ProjectPosting exists
            var ServicePosting = await _serviceSphereContext.ServicePostings.FindAsync(proposalDto.ServicePostingId);
            if (ServicePosting == null)
            {
                return NotFound($"ServicePosting with ID {proposalDto.ServicePostingId} not found.");
            }

            

            try
            {
                if (ServicePosting.Status == PostStatus.Open)
                {
                    // Check if the user has already submitted a proposal for this project
                    bool alreadySubmitted = await _serviceSphereContext.Proposals.AnyAsync(p => p.ServicePostingId == proposalDto.ServicePostingId && p.userId == user.Id);
                    if (alreadySubmitted)
                    {
                        return BadRequest("You have already submitted a proposal for this project.");
                    }
                    var mappedProposal = _mapper.Map<Proposal>(proposalDto);
                    await _proposalRepo.AddAsync(mappedProposal);
                    var result = await _serviceSphereContext.SaveChangesAsync();
                    if (result <= 0) { return null; }
                    return Ok(proposalDto);
                }
                else
                {
                    return BadRequest("This post is Closed, You can't submit a proposal");
                }
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the project: {ex.Message}");
            }
        }

        [HttpGet("GetUserProposals")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetUserProposals()
        {
            
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(400, "user not recognized"));
            }
            var spec = new ProposalSpecs(user.Id);
            var proposals = await _proposalRepo.GetAllWithSpecAsync(spec);
            var mappedProposals = _mapper.Map<List<ProposalDto>>(proposals);


            if (proposals == null || !proposals.Any())
            {
                
                return NotFound(new ApiResponse(404, "No proposals found for this user."));
            }

            // You might want to map these entities to DTOs before returning them
            return Ok(mappedProposals);
        }

        

        [HttpPut("UpdateProposal/{PostId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateProposal([FromBody] UpdateProposalDto UpdateproposalDto, int PostId, [FromQuery] PostingType postingType)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound(new ApiResponse(404, "Target user not found."));
            }
           

            var spec = new ProposalSpecs(PostId,postingType);
            var proposal = await _proposalRepo.GetByIdWithSpecAsync(spec);
            if (proposal == null)
            {
                return NotFound($"Proposal doesn't exist");
            }
            UpdateproposalDto.Id = proposal.Id;
            if (proposal.userId != user.Id)
            {
                return Unauthorized(new ApiResponse(400,"You do not have permission to update this proposal."));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Map the changes from proposalDto to the tracked entity directly
                _mapper.Map(UpdateproposalDto, proposal); // This avoids creating a new instance

                // _proposalRepo.Update(proposal); // This line might be unnecessary if _mapper.Map updates the tracked entity
                var result = await _serviceSphereContext.SaveChangesAsync();
                if (result <= 0) { return null; }
                return Ok(UpdateproposalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the project: {ex.Message}");
            }
        }

        [HttpDelete("{proposalId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteProposal(int proposalId)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound(new ApiResponse(404, "user not found."));
            }

            var proposal = await _proposalRepo.GetByIdAsync(proposalId);
            if (proposal == null)
            {
                return NotFound("Proposal not found.");
            }

            // Check if the user is authorized to delete the proposal
            // This is just an example; adjust the condition according to your authorization logic
            if (proposal.userId != user.Id )
            {
                return Unauthorized(new ApiResponse(400, "You do not have permission to delete this proposal."));
            }

            try
            {
                // Perform the deletion
                _proposalRepo.Delete(proposal);
                await _serviceSphereContext.SaveChangesAsync();
                return Ok("You deleted the proposal successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting: {ex.Message}");
            }
        }

        [HttpPatch("AcceptProposal/{proposalId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AcceptProposal(int proposalId)
        {
            var proposal = await _proposalRepo.GetByIdAsync(proposalId);
            if (proposal == null)
            {
                return NotFound("Proposal not found.");
            }

            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound(new ApiResponse(404, "user not found."));
            }

            if (!(user.Id == proposal.userId))
            {
                return Unauthorized(new ApiResponse(400, "You do not have permission to accept this proposal."));

            }

            // Accept the proposal
            proposal.IsAccepted = true;
            _proposalRepo.Update(proposal);
            await _serviceSphereContext.SaveChangesAsync();

            //send notification
            await _notificationService.CreateNotificationAsync(proposal.userId,"Congrats, Your proposal is accepted");
            
            //update serviceposting

            if(proposal.ServicePostingId!=null)
            {
                int proposalServicePost =(int) proposal.ServicePostingId;
                var servicePost =await _servicePostingsRepo.GetByIdAsync(proposalServicePost);
                servicePost.Status = PostStatus.Closed;
                _servicePostingsRepo.Update(servicePost);
                
            }
            await _serviceSphereContext.SaveChangesAsync();
            //update projectposting

            return Ok("Proposal accepted successfully.");
        }
    }

}
