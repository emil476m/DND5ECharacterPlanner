var builder = DistributedApplication.CreateBuilder(args);

var dndDb = builder.AddPostgres("dnd-postgres").AddDatabase("DND5EDb");
var userDb = builder.AddPostgres("user-postgres").AddDatabase("UserDb");
var characterDb = builder.AddPostgres("character-postgres").AddDatabase("CharacterDb");

// TODO: uncomment as each service is wired up to Aspire
// var userService = builder.AddProject<Projects.UserService_Api>("userservice")
//     .WithReference(userDb).WaitFor(userDb);
//
// var dnd5eHandler = builder.AddProject<Projects.DND5EHandler_Api>("dnd5ehandler")
//     .WithReference(dndDb).WaitFor(dndDb);
//
// var characterHandler = builder.AddProject<Projects.CharacterHandler_Api>("characterhandler")
//     .WithReference(characterDb).WaitFor(characterDb)
//     .WithReference(dnd5eHandler);
//
// builder.AddProject<Projects.Gateway_Api>("gateway")
//     .WithReference(userService)
//     .WithReference(dnd5eHandler)
//     .WithReference(characterHandler);

builder.Build().Run();
