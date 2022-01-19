using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MicroLMS.Domain;
using MicroLMS.Infrastructure.Repositories;
using Xunit;

namespace MicroLMS.Tests.DisciplineRepositoryTests
{
    public class DeleteTest
    {
        private readonly TestHelper _testHelper;
        private readonly DisciplineRepository _disciplineRepository;

        private readonly Discipline _discipline;

        public DeleteTest()
        {
            _testHelper = new TestHelper();
            _disciplineRepository = _testHelper.DisciplineRepository;

            _discipline = new Discipline()
            {
                Id = Guid.NewGuid(),
                Name = "Math",
            };
            _testHelper.MicroLMSContext.Disciplines.Add(_discipline);
            _testHelper.MicroLMSContext.SaveChanges();
        }

        [Fact]
        public void GetSurvey()
        {
            var result = _disciplineRepository.DeleteDisciplineAsync(_discipline.Id).Result;
            Assert.True(result);
        }
    }
}