using CognizantChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using CognizantChallengeAPI.Clients;
using CognizantChallengeDAL.Repositories;

namespace CognizantChallengeAPI.Logic
{
    public interface ICheckSubmissionLogic
    {
        Task<TaskSubmitResult> Check(TaskSubmit taskSubmit);
    }
    public class CheckSubmissionLogic : ICheckSubmissionLogic
    {
        private readonly IJDoodleClient jDoodleClient;
        private readonly ITasksRepository tasksRepository;
        private readonly IUsersRepository usersRepository;
        private readonly ISolutionsRepository solutionsRepository;

        public CheckSubmissionLogic(
            IJDoodleClient jDoodleClient,
            ITasksRepository tasksRepository,
            IUsersRepository usersRepository,
            ISolutionsRepository solutionsRepository)
        {
            this.jDoodleClient = jDoodleClient;
            this.tasksRepository = tasksRepository;
            this.usersRepository = usersRepository;
            this.solutionsRepository = solutionsRepository;
        }

        public async Task<TaskSubmitResult> Check(TaskSubmit taskSubmit)
        {
            var task = this.tasksRepository.GetByExternalId(taskSubmit.TaskExternalId);
            var user = this.usersRepository.GetByName(taskSubmit.Name);
            
            if (user == null)
                this.usersRepository.CreateUser(taskSubmit.Name);

            var executionResult = await this.jDoodleClient.Execute(taskSubmit);
            if(executionResult.StatusCode == 200)
            {
                var solution = solutionsRepository.GetUserSolutionForTask(user.ID, task.ID);

                if(solution == null)
                {
                    solution = solutionsRepository.CreateSolution(user, task, taskSubmit.Solution, executionResult.Output == task.ExpectedResult);                    
                }
                else
                {
                    solution.Code = taskSubmit.Solution;
                    solution.Success = executionResult.Output == task.ExpectedResult;
                    solutionsRepository.UpdateSolution(solution);
                }

                return new TaskSubmitResult
                {
                    Output = executionResult.Output,
                    Errors = executionResult.Error,
                    StatusCode = executionResult.StatusCode,
                    Success = solution.Success
                };
            }
            else
            {
                return new TaskSubmitResult
                {
                    Output = executionResult.Output,
                    Errors = executionResult.Error,
                    StatusCode = executionResult.StatusCode,
                };
            }
        }
    }
}
