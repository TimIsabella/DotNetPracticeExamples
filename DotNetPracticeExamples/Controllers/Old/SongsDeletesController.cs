using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;

namespace DotNetPracticeExamples.Controllers.Old
{
    //URL 'Route' -- https://localhost:1234/api/SongsDeletes
    //- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
    //[Route("api/[controller]")]
    [Route("api/SongsDeletes")]
    [ApiController]
    public class SongsDeletesController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public SongsDeletesController(ApiDbContext dbContext)
        { _dbContext = dbContext; }

        /// ///////////////////////////////// DELETE EXAMPLES /////////////////////////////////

        /// /////////// void Return ///////////
        [HttpDelete("DeleteVoid/{id}")]
        public void DeleteVoid(int id)
        {
            var song = _dbContext.Songs.Find(id);   //Find song record by id

            //If record not null
            if (song != null)
            {
                _dbContext.Songs.Remove(song);  //Remove song with '.Remove()'
                _dbContext.SaveChanges();       //'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
            }

            //No return
        }

        /// /////////// string Return ///////////
        [HttpDelete("DeleteString/{id}")]
        public string DeleteString(int id)
        {
            var song = _dbContext.Songs.Find(id);

            if (song != null)
            {
                _dbContext.Remove(song);
                _dbContext.SaveChanges();
                return $"200 -- Song Id: {id} successfully deleted.";
            }
            else
            {
                return $"404 -- Song Id: {id} not found.";
            }
        }

        /// /////////// 'IEnumerable' Return ///////////
        [HttpDelete("DeleteIEnumerable/{id}")]
        public IEnumerable DeleteIEnumerable(int id)
        {
            var song = _dbContext.Songs.Find(id);

            if (song != null)
            {
                _dbContext.Remove(song);
                _dbContext.SaveChanges();

                yield return StatusCode(200, $"Song Id: {id} successfully deleted.");
            }
            else
            {
                yield return StatusCode(404, $"Song Id: {id} not found.");
            }
        }

        /// /////////// 'IActionResult' Return ///////////
        [HttpDelete("DeleteIActionResult/{id}")]
        public IActionResult DeleteIActionResult(int id)
        {
            var song = _dbContext.Songs.Find(id);

            if (song != null)
            {
                _dbContext.Remove(song);
                _dbContext.SaveChanges();
                return StatusCode(200, $"Song Id: {id} successfully deleted.");
            }
            else
            {
                return StatusCode(404, $"Song Id: {id} not found.");
            }
        }

        /// /////////// 'IEnumerable' Return of 'Task' with 'await' ///////////
        [HttpDelete("DeleteIEnumerableAsyncTask/{id}")]
        public async Task<IEnumerable> DeleteIEnumerableAsyncTask(int id)
        {
            var song = await Task.FromResult(_dbContext.Songs.Find(id));

            if (song != null)
            {
                await Task.FromResult(_dbContext.Remove(song));
                await Task.FromResult(_dbContext.SaveChanges());

                return await Task.FromResult(new List<StatusCodeResult>() { StatusCode(200) });
            }
            else
            {
                return await Task.FromResult(new List<StatusCodeResult>() { StatusCode(200) });
            }
        }

        /// /////////// 'IActionResult' Return of 'Task' with 'await' ///////////
        [HttpDelete("DeleteIActionResultAsyncTask/{id}")]
        public async Task<IActionResult> DeleteIActionResultAsyncTask(int id)
        {
            var song = await Task.FromResult(_dbContext.Songs.Find(id));

            if (song != null)
            {
                await Task.FromResult(_dbContext.Remove(song));
                await Task.FromResult(_dbContext.SaveChanges());

                return await Task.FromResult(StatusCode(200, $"Song Id: {id} successfully deleted."));
            }
            else
            {
                return await Task.FromResult(StatusCode(404, $"Song Id: {id} not found."));
            }
        }
    }
}
