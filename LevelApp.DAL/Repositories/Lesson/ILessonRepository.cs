﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LevelApp.Crosscutting.Helpers.PaginatedList;
using LevelApp.DAL.Models.Core;
using LevelApp.DAL.Repositories.Base;

namespace LevelApp.DAL.Repositories.Lesson
{
    public interface ILessonRepository : IBaseRepository<Models.Core.Lesson, int>
    {
        Task<IPaginatedList<Models.Core.Lesson>> GetPaginatedLessonsAsync(
            int pageIndex, 
            int pageSize, 
            Expression<Func<AppUserLesson, bool>> userLessonFilter = null, 
            Expression<Func<Models.Core.Lesson, bool>> lessonFilter = null,
            Func<IQueryable<Models.Core.Lesson>, IOrderedQueryable<Models.Core.Lesson>> orderBy = null);
    }
}