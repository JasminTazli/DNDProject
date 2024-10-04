## How we worked with RESTful web API with code examples
In developing our RESTful web API, we have constructed a structure that allows for seamless interaction with our EsgData model, which encapsulates key attributes related to environmental, social, and governance (ESG) metrics. The architecture relies heavily on the Entity Framework Core (EF Core) to facilitate database operations, making it straightforward to implement the necessary Create, Read, Update, and Delete (CRUD) functionalities.

The foundational component of our API is the EsgData model. This class serves as a representation of the data structure, encapsulating essential properties like Id, CompanyName, CarbonFootprint, WaterUsage, EmployeeSatisfaction, and ReportingDate. Here’s a code snippet that illustrates this model:

```namespace ESGApi;

public class EsgData

{
    public int Id { get; set; }
    
    public string CompanyName { get; set; }
    
    public double CarbonFootprint { get; set; }
    
    public double WaterUsage { get; set; }
    
    public int EmployeeSatisfaction { get; set; }
    
    public DateTime ReportingDate { get; set; }
}
```
Next, the EsgContext class acts as a bridge between the application and the database, using EF Core to map our model to a database table. It is defined as follows:

```
using Microsoft.EntityFrameworkCore;
namespace ESGApi;
public class EsgContext : DbContext
{
    public EsgContext(DbContextOptions<EsgContext> options)
        : base(options)
    {
    }   
public DbSet<EsgData> EsgData { get; set; } = null!;
}
```
By leveraging an in-memory database through EF Core, we can effectively develop and test the API without the overhead of managing a persistent database. The in-memory option allows to focus on functionality without the complexities of data persistence during the early stages of development.

The core functionality of the API resides in the EsgDataController. This controller is responsible for managing the HTTP requests, and it includes methods for each of the CRUD operations. Here’s an example of  the POST request to create a new EsgData entry is handled: 
```
// POST: api/EsgData
[HttpPost]
public async Task<ActionResult<EsgData>> PostEsgData(EsgData esgData)
{
    _context.EsgData.Add(esgData);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetEsgData", new { id = esgData.Id }, esgData);
}
```

## Overview of our web API endpoints
The API exposes several endpoints that correspond to different operations, which can be summarized as follows:

GET: api/EsgData
- Description: Retrieves a list of all EsgData entries.
- Response Type: ActionResult<IEnumerable<EsgData>>

GET: api/EsgData/{id}
- Description: Fetches a specific EsgData entry identified by the given ID.
- Response Type: ActionResult<EsgData>

PUT: api/EsgData/{id}
- Description: Updates an existing EsgData entry with the provided ID.
- Parameters: An EsgData object and the ID of the entry to update.

POST: api/EsgData
- Description: Creates a new EsgData entry.
- Parameters: An EsgData object containing the data to create.

DELETE: api/EsgData/{id}
- Description: Deletes a specific EsgData entry based on the provided ID.
- Response Type: Returns NoContent() upon successful deletion.

## Current Use of File Storage for Data
At this stage, our implementation leverages an in-memory database for storing data, which is great for development and testing.


## Conclusion
In summary, our RESTful web API, developed using ASP.NET Core and Entity Framework Core, provides a structured approach to managing EsgData. Through API endpoints, we can perform all CRUD operations efficiently. 

Although our current setup utilizes an in-memory database for ease of development, integrating file storage solutions for data persistence can enhance the reliability of our application. 
For future development of our application, we plan to incorporate more detailed ESG data. 

Currently, we have five data attributes, which serve as examples of how the final version might look.

