using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MicroLMS.Domain;
using MicroLMS.Infrastructure.Repositories;
using Xunit;

namespace MicroLMS.Tests.DisciplineRepositoryTests
{
    public class GetTest
    {
        private readonly TestHelper _testHelper;
        private readonly DisciplineRepository _disciplineRepository;

        private Discipline _discipline;

        public GetTest()
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
            var disciplinePersist = _disciplineRepository.GetDisciplineAsync(_discipline.Id).Result;
            Debug.Assert(disciplinePersist != null, nameof(_discipline) + " != null");

            Assert.Equal(_discipline.Name, disciplinePersist.Name);
        }
    }
}