var builder = DistributedApplication.CreateBuilder(args);

var productAPI = builder.AddProject<Projects.E2E_ProductService>("apiservice-product");
var orderAPI = builder.AddProject<Projects.E2E_OrderService>("apiservice-order");

builder.AddProject<Projects.Complete_Project_E2E>("webfrontend")
    .WithReference(productAPI)
    .WithReference(orderAPI);

builder.Build().Run();
