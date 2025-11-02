// See https://aka.ms/new-console-template for more information

using ConsumerRepositoryPattern.InMemoryDataBase;
using ConsumerRepositoryPattern.Repository;
using ConsumerRepositoryPattern.Services;

Console.WriteLine("Hello, World!");

InMemoryDatabase db = new InMemoryDatabase();
db.SeedUser();

var repo = new MyRepository(db);

UserService userService = new UserService(repo);
    userService.GetUserFromPlatform();

