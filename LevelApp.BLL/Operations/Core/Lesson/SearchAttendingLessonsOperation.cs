﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LevelApp.BLL.Base.Operation;
using LevelApp.BLL.Dto.Core.Lesson;
using LevelApp.DAL.Repositories.Lesson;

namespace LevelApp.BLL.Operations.Core.Lesson
{
    public class SearchAttendingLessonsOperation : BaseOperation<LessonSearchParametersDto, LessonSearchResultsDto>
    {
        public override async Task ExecuteValidated()
        {
            var results = await Repository<ILessonRepository>()
                .GetPaginatedLessonsAsync(
                    Parameter.CurrentPage, 
                    Parameter.CardsPerPage, 
                    userLesson => userLesson.UserId == CurrentUserId
                              && (Parameter.IsFavourite != true || userLesson.IsFavourite)
                    && (!Parameter.LessonStatus.HasValue || userLesson.Status == Parameter.LessonStatus.Value),
                    lesson => (string.IsNullOrEmpty(Parameter.SearchLessonText) 
                               || lesson.Name.ToLower().Contains(Parameter.SearchLessonText.ToLower())
                               || lesson.Description.ToLower().Contains(Parameter.SearchLessonText.ToLower())));
            
            OperationResult = new LessonSearchResultsDto()
            {
                SearchResults = Mapper.Map<List<LessonSearchEntryDto>>(results.ToList()),
                TotalPages = results.TotalPages,
                PageIndex = results.PageIndex
            };
            
            await base.ExecuteValidated();
        }
    }
}