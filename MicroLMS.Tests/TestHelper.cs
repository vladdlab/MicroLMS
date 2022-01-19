using Microsoft.EntityFrameworkCore;
using MicroLMS.Infrastructure;
using MicroLMS.Infrastructure.Repositories;

namespace MicroLMS.Tests;

public class TestHelper
{
    private readonly MicroLMSContext _context;

    public TestHelper()
    {
        var builder = new DbContextOptionsBuilder<MicroLMSContext>();
        builder.UseInMemoryDatabase("microLMS");
        var dbContextOptions = builder.Options;
        _context = new MicroLMSContext(dbContextOptions);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    public DisciplineRepository DisciplineRepository => new DisciplineRepository(_context);
    public MicroLMSContext MicroLMSContext => _context;
}