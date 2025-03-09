# TechChallenge.SDK
Para utilizar adicionar essa linha no program:
builder.Services.RegisterSdkModule(configuration);

E no app settings    "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=ContactsDb;User Id=sa;Password=YourStrong!Password;TrustServerCertificate=True"
   },
