var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Deadline_Api>("deadline-api");

builder.Build().Run();
