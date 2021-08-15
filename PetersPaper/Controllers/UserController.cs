using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetersPaper.Data;
using PetersPaper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PetersPaper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PetersPapersDbContext dbContext;

        public UserController(PetersPapersDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers(string q)
        {
            try
            {
                var users = await dbContext.Users
                                  .AsNoTracking()
                                  .Include(i => i.Department)
                                  .Include(i => i.Tasks).ThenInclude(i => i.TaskStatus)
                                  .Where(i => string.IsNullOrEmpty(q)
                                     || (i.FirstName.ToLower().Contains(q.ToLower()))
                                     || (i.LastName.ToLower().Contains(q.ToLower()))
                                     || (i.Email.ToLower().Contains(q.ToLower()))
                                     || (i.CellNumber.ToLower().Contains(q.ToLower())))
                                  .Where(i => !i.IsDeleted)
                                  .ToListAsync();

                return Ok(users);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("getDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await dbContext.Departments
                                  .AsNoTracking()
                                  .Where(i => !i.IsDeleted)
                                  .ToListAsync();

                return Ok(departments);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("getUserDetails/{id}")]
        public async Task<IActionResult> UserDetail([FromRoute] long id)
        {
           
            try
            {
                var userDetail = await dbContext.Users
                            .AsNoTracking()
                            .Include(i => i.Department)
                            .Include(i => i.Tasks).ThenInclude(i => i.TaskStatus)
                            .Where(i => !i.IsDeleted)
                            .FirstOrDefaultAsync(i => i.Id == id);

                return Ok(userDetail);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPut("saveUser")]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            try
            {
                user.DateCreated = DateTime.Now;

                if (user.Id == 0)
                {
                    dbContext.Users.Add(user);
                    await dbContext.SaveChangesAsync();
                } else
                {
                    dbContext.Users.Update(user);
                    await dbContext.SaveChangesAsync();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("getTaskStatuses")]
        public async Task<IActionResult> GetTaskStatuses()
        {
            try
            {
                var taskStatuses = await dbContext.TaskStatuses
                                  .AsNoTracking()
                                  .Where(i => !i.IsDeleted)
                                  .ToListAsync();

                return Ok(taskStatuses);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("saveTasks")]
        public async Task<IActionResult> SaveTasks([FromBody] List<Data.Models.Task> tasks)
        {
            try
            {

                foreach(var task in tasks)
                {
                    task.DateCreated = DateTime.Now;

                    if (task?.Id == null)
                    {
                        dbContext.Tasks.Add(task);
                        await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        dbContext.Tasks.Update(task);
                        await dbContext.SaveChangesAsync();
                    }
                }
                

                return Ok(tasks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("deleteTask/{id}")]
        public async Task<IActionResult> DeleteUserTask([FromRoute] long id)
        {
            try
            {
                var task = await dbContext.Tasks.FirstOrDefaultAsync(i => i.Id == id);
                task.IsDeleted = true;
                dbContext.Tasks.Update(task);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);
                user.IsDeleted = true;
                dbContext.Users.Update(user);

                var tasks = await dbContext.Tasks.Where(i => i.UserId == id).ToListAsync();

                foreach(var task in tasks)
                {
                    task.IsDeleted = true;
                    dbContext.Tasks.Update(task);
                }

                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

}
