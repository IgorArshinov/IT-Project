using System;
using System.Collections.Generic;
using System.Linq;
using LiminoAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LiminoAPI.Data.Repositories
{
    public class ExerciseRepository : BaseRepository<Exercise>
    {
        public ExerciseRepository(AppDbContext context) : base(context)
        {
           
        }
        public override IEnumerable<Exercise> GetAll()
        {
            return  Context.Set<Exercise>().Include(x => x.Answers).AsEnumerable();
        }
        public override IEnumerable<Exercise> GetAllWhere(Func<Exercise, bool> property)
        {
            return Context.Set<Exercise>().Include(x => x.Answers).Where(property).AsEnumerable();
        }
        
        public override long Add(Exercise exercise)
        {
            Context.Set<Exercise>().Add(exercise);
            Context.SaveChanges();
            return exercise.Id;
        }
        public override void Delete(Exercise exercise)
        {
            Context.Set<Exercise>().Remove(exercise);
            Context.SaveChanges();
        }
        public override Exercise GetById(long id)
        {
            return Context.Set<Exercise>().Include(x => x.Answers).FirstOrDefault(x => x.Id == id);
        }
        public override Exercise Update(Exercise exercise)
        {
            Context.Set<Exercise>().Update(exercise);
            Context.SaveChanges();

            return exercise;
        }
    }
}