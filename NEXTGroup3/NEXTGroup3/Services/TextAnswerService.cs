using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using NEXTGroup3.Data;
using NEXTGroup3.Models;



namespace NEXTGroup3.Services
{
    public class TextAnswerService
    {
        // a context factory for providing appropriate access to the database
        private readonly IDbContextFactory<AzureContext> contextFactory;

        //functions are run once before refering to text questions, so current index increases by one before starting the set of quesitons
        public int CurrentQuestionIndex { get; set; } = default;
        public bool CompletedQuestionnaire { get; set; } = false;
        public List<Role> roles { get; set; }

        public int QuestionMax { get; set; } = default;

        public List<TextAnswer> availableAnswers { get; set; }

        public Dictionary<int, int> countAnswerDisplay { get; set; } = new Dictionary<int, int>();

        public TextAnswerService(IDbContextFactory<AzureContext> c)
        {
            contextFactory = c;
        }

        // uses functions below to retrieve all text answers relating to the provided department
        public async Task<List<TextAnswer>> GetTextAnswersFromDepartment(Department department)
        {            
            var context = contextFactory.CreateDbContext();
            roles = context.Role
                               .Where(x => x.DepartmentId == department.Id)
                               .AsNoTracking()
                               .ToList();
            
            return await GetTextAnswersFromRoles(context);
        }

        // retrieves the text answers from all roles in the derpartment
        public async Task<List<TextAnswer>> GetTextAnswersFromRoles(AzureContext context)
        {
            var tasks = roles.Select(async role =>
            {
                try
                {
                    Console.WriteLine($"Starting task for role {role.Id}");
                    var result = await GetAllTextAnswersFromRole(role, context);
                    Console.WriteLine($"Completed task for role {role.Id}");
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching text answers for role {role.Id}: {ex.Message}");
                    return new List<TextAnswer>();
                }
            }).ToList();
                var results = await Task.WhenAll(tasks);
            Console.WriteLine($"Found results.");
                return results.SelectMany(x => x).ToList();
            
        }

        // retrieves text answers from each individual role
        private async Task<List<TextAnswer>> GetAllTextAnswersFromRole(Role role, AzureContext context)
        {
            using (var Context = contextFactory.CreateDbContext())
            {
                try
                {
                    // Log the Role ID and try to fetch the answers
                    Console.WriteLine($"Fetching text answers for role {role.Id}");

                    // Check if the role is valid (to prevent null reference exceptions)
                    if (role == null || role.Id <= 0)
                    {
                        Console.WriteLine($"Invalid role: {role?.Id}");
                        return new List<TextAnswer>(); // Return an empty list if the role is invalid
                    }

                    return await Context.TextAnswer
                                                   .AsNoTracking()
                                                   .Where(x => x.RoleId == role.Id)
                                                   .ToListAsync();
                }
                catch (Exception ex)
                {
                    // Catch and log the exception
                    Console.WriteLine($"Error fetching text answers for role {role.Id}: {ex.Message}");
                    throw; // Optionally rethrow the exception to propagate it
                }
            }
        }

        // calculates the maximum amount if questions corresponding to the amount of answers for this department
        public async Task CalculateQuestionMax(int possibleAnswerCount)
        {
            QuestionMax = (int)Math.Ceiling((Convert.ToDouble(possibleAnswerCount) * 2) / 3);
        }
        //public async Task<Role> GetRoleFromTextAnswerId(int id)
        //{
        //    var context = contextFactory.CreateDbContext();
        //    var textAnswer = context.TextAnswer.Find(id);
        //    return context.Role.Find(textAnswer.RoleId);
        //}
    }
}
