using System;
using System.Collections.Generic;
using System.Linq;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LiminoAPI.Data.Repositories
{
    public class ExerciseSeriesRepository : IExerciseSeriesRepository
    {
        protected readonly AppDbContext Context;
        
        public ExerciseSeriesRepository(AppDbContext context)
        {
            Context = context;
        }
        
        public ExerciseSeries Add(ExerciseSeries exerciseSeries)
        {
            Context.Set<ExerciseSeries>().Add(exerciseSeries);
            Context.SaveChanges();
            
            return exerciseSeries;
        }

        public void Delete(long id)
        {
            Context.Set<ExerciseSeries>().Remove(Context.Set<ExerciseSeries>().FirstOrDefault(x => x.Id == id));
            Context.SaveChanges();
        }

        public  IEnumerable<ExerciseSeries> GetAll()
        {
            return  Context.Set<ExerciseSeries>().Include(series => series.ExerciseSeriesExercises).AsEnumerable();
        }

        public ExerciseSeries GetById(long id)
        {
            return Context.Set<ExerciseSeries>().FirstOrDefault(x => x.Id == id);
        }

        public ExerciseSeries GetByCode(long code)
        {
            return Context.Set<ExerciseSeries>().Include(series => series.ExerciseSeriesExercises).AsEnumerable().FirstOrDefault(x => x.Code == code);
        }


        public ExerciseSeries Update(ExerciseSeries exerciseSeries)
        {
            Context.Set<ExerciseSeries>().Update(exerciseSeries);
            Context.SaveChanges();

            return exerciseSeries;
        }
    }
}