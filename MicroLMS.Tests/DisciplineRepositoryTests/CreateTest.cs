using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MicroLMS.Domain;
using MicroLMS.Infrastructure.Repositories;
using Xunit;

namespace MicroLMS.Tests.DisciplineRepositoryTests
{
    public class CreateTest
    {
        private readonly TestHelper _testHelper;
        private readonly DisciplineRepository _disciplineRepository;

        public CreateTest()
        {
            _testHelper = new TestHelper();
            _disciplineRepository = _testHelper.DisciplineRepository;
        }

        [Fact]
        public void AddSurvey()
        {
            Discipline discipline = new Discipline()
            {
                Id = Guid.NewGuid(),
                Name = "Math",
            };
            _disciplineRepository.CreateDisciplineAsync(discipline);
            var disciplinePersist = _testHelper.MicroLMSContext.Disciplines.FindAsync(discipline.Id).Result;

            Debug.Assert(disciplinePersist != null, nameof(disciplinePersist) + " != null");

            Assert.Equal(discipline.Name, disciplinePersist.Name);
        }
    }
}