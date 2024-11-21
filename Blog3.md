# 3 Web Application
When logged on to the Web Application the user is greeted with “Hello ..” 
![34821681-4f67-4915-a15f-6169e5f02540](https://github.com/user-attachments/assets/2bcb3a42-1e06-40ec-ab2f-41b631fed696)

Next the user can click on ESG Data in the navigation bar. 
When this is clicked the ESG Data is displayed and the user can click on the specific data / KPI that they want to view. 
![62be3d58-d98b-4363-bac8-9c8003153498](https://github.com/user-attachments/assets/d3fbf028-28c7-4df2-9425-433d627858e9)

`code`
@page "/esgdata"

<PageTitle>ESG Data</PageTitle>

<h1>ESG Data</h1>

<p>Vælg en kategori nedenfor for at se specifikke data:</p>

<ul>
    <li><NavLink href="/carbonfootprint">Carbon Footprint</NavLink></li>
    <li><NavLink href="/gasemission">Gas Emission</NavLink></li>
</ul>

@if (esgData == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>
                <th>Carbon Footprint (CO₂)</th>
                <th>Gas Emissions (kg)</th>
                <th>Summary</th>
                <th>Recommendations</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var data in esgData)
            {
                <tr>
                    <td>@data.Date.ToShortDateString()</td>
                    <td>@data.CarbonFootprint</td>
                    <td>@data.GasEmissions</td>
                    <td>@data.Summary</td>
                    <td>@data.Recommendation</td>
                    <td>
                        <button @onclick="() => DeleteData(data.Id)">Delete</button>
                    </td>
                </tr>
            }
        </tbody>
    </table>
    <button @onclick="ShowAddForm">Add New ESG Data</button>
}

@if (showAddForm)
{
    <EditForm Model="newEsgData" OnValidSubmit="AddData">
        <DataAnnotationsValidator />
        <div>
            <label>Date: <InputDate @bind-Value="newEsgData.Date" /></label>
        </div>
        <div>
            <label>Carbon Footprint (CO₂): <InputNumber @bind-Value="newEsgData.CarbonFootprint" /></label>
        </div>
        <div>
            <label>Gas Emissions (kg): <InputNumber @bind-Value="newEsgData.GasEmissions" /></label>
        </div>
        <div>
            <label>Summary: <InputText @bind-Value="newEsgData.Summary" /></label>
        </div>
        <div>
            <label>Recommendation: <InputText @bind-Value="newEsgData.Recommendation" /></label>
        </div>
        <button type="submit">Add</button>
        <button type="button" @onclick="HideAddForm">Cancel</button>
    </EditForm>
}

@code {
    private List<EsgData>? esgData;
    private EsgData newEsgData = new();
    private bool showAddForm = false;

    [Inject]
    private HttpClient Http { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        esgData = await Http.GetFromJsonAsync<List<EsgData>>("EsgData");
    }

    private async Task DeleteData(int id)
    {
        await Http.DeleteAsync($"EsgData/{id}");
        await LoadData();
    }

    private async Task AddData()
    {
        await Http.PostAsJsonAsync("EsgData", newEsgData);
        newEsgData = new EsgData(); // Reset form
        showAddForm = false;
        await LoadData();
    }

    private void ShowAddForm()
    {
        showAddForm = true;
    }

    private void HideAddForm()
    {
        showAddForm = false;
    }

    private class EsgData
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int CarbonFootprint { get; set; }
        public int GasEmissions { get; set; }
        public string? Summary { get; set; }
        public string? Recommendation { get; set; }
    }
}
`code`

When "Gas Emissions" is clicked the user gets an overview of the date, the exact gas emission, a summary of "is it good or bad" and a recommendation to what the company can do in order to either improve or if they are on the right track. 
![b855487d-8d4c-4811-84e4-17947a06fb1e](https://github.com/user-attachments/assets/4bcf6171-f240-4350-966b-7839b2854fa1)

The same goes for "Carbon Footprint", when this is clicked the user gets an overview of the Carbon foorprint. 
![17f3501a-9cd0-488d-a561-9323ff711334](https://github.com/user-attachments/assets/e6d02a9a-4d4c-475e-afef-97e719a81d1b)

The key requirement that was fulfilled with this web application is 

*"As a manager, I want to access a user-friendly dashboard in Blazor where I can see ESG key metrics over time and receive recommendations for improvements, 
so I can better meet ESG standards and requirements."*

This requirement is fulfilled becase the user gets an overview of the environmental data. 
However, at current time there is space for improvement to make it more user-friendly. 

