using System.Diagnostics;
using System.Net.NetworkInformation;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;



Console.WriteLine("this if from program.cs");


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<mainDbContext>(options =>
options.UseSqlServer(""));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHsts();
}




using (var connection = new SqliteConnection("Data Source=hello.db"))
{
    connection.Open();
    //insert data
    using var cmd = connection.CreateCommand();

    cmd.CommandText = "DROP TABLE IF EXISTS cars";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY,
            name TEXT, price INT)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Skoda',9000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volvo',29000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Bentley',350000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Citroen',21000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Hummer',41400)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volkswagen',21600)";
    cmd.ExecuteNonQuery();

    Console.WriteLine("Table cars created");

    //retrive data

    cmd.CommandText = "SELECT * FROM cars LIMIT 5";

    var reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        Debug.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetInt32(2)}");
    }

}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
