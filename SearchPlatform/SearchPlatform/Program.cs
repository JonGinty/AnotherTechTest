using SearchPlatform;
using SearchPlatform.Utilities;
using SearchService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add search services
builder.Services.AddSingleton<IEnumerable<UserItem>>(new PlaceholderDataLoader().LoadItems())
                .AddSingleton<IItemRepository<UserItem>, UserItemRepository>()
                .AddTransient<ISearchService<UserItem>, SearchService<UserItem>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
