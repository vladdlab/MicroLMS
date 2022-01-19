using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MicroLMS.Domain;
using MicroLMS.Infrastructure.Repositories;
using Xunit;

namespace MicroLMS.Tests.DisciplineRepositoryTests
{
    public class IndexTest
    {
        private readonly TestHelper _testHelper;
        private readonly DisciplineRepository _disciplineRepository;

        private readonly IList<Discipline> _disciplines;

        public IndexTest()
        {
            _testHelper = new TestHelper();
            _disciplineRepository = _testHelper.DisciplineRepository;

            Discipline discipline1 = new Discipline()
            {
                Name = "Math"
            };
            Discipline discipline2 = new Discipline()
            {
                Name = "Chemistry"
            };
            _disciplines = new List<Discipline>() {discipline1, discipline2};
            _testHelper.MicroLMSContext.Disciplines.AddRange(_disciplines);
            _testHelper.MicroLMSContext.SaveChanges();
        }

        [Fact]
        public void IndexSurvey()
        {
            var res = _disciplineRepository.GetDisciplinesAsync().Result;
            foreach (var survey in _disciplines)
            {
                Assert.Contains(survey, res);
            }
        }
    }
}