# 3 Web Application
When logged on to the Web Application the user is greeted with “Hello ..” 
![34821681-4f67-4915-a15f-6169e5f02540](https://github.com/user-attachments/assets/2bcb3a42-1e06-40ec-ab2f-41b631fed696)

Next the user can click on ESG Data in the navigation bar. 
When this is clicked the ESG Data is displayed and the user can click on the specific data / KPI that they want to view. 
![62be3d58-d98b-4363-bac8-9c8003153498](https://github.com/user-attachments/assets/d3fbf028-28c7-4df2-9425-433d627858e9)

## Code for ESG Data page
![image](https://github.com/user-attachments/assets/66eb9421-2b7a-491d-9016-4da7182bc8d5)
![image](https://github.com/user-attachments/assets/0f46ef61-de86-4c1d-9455-12ee21a0d078)
![image](https://github.com/user-attachments/assets/3e11eefe-d02c-46ca-aef8-a14f8f5c1f76)
![image](https://github.com/user-attachments/assets/4c8fd58e-36b6-4454-8d8f-96da36ca8219)
![image](https://github.com/user-attachments/assets/2a4722b5-00f4-4015-8937-303b2064856c)


When "Gas Emissions" is clicked the user gets an overview of the date, the exact gas emission, a summary of "is it good or bad" and a recommendation to what the company can do in order to either improve or if they are on the right track. 
![b855487d-8d4c-4811-84e4-17947a06fb1e](https://github.com/user-attachments/assets/4bcf6171-f240-4350-966b-7839b2854fa1)

## Code for Gas Emissions page
![image](https://github.com/user-attachments/assets/6d5557d6-89da-48e9-8bb6-593cb98ce353)
![image](https://github.com/user-attachments/assets/4484011b-545f-421c-873a-ae5535e6a588)
![image](https://github.com/user-attachments/assets/98387155-6b50-4b53-a1bc-c32a9fcf685e)


The same goes for "Carbon Footprint", when this is clicked the user gets an overview of the Carbon foorprint. 
![17f3501a-9cd0-488d-a561-9323ff711334](https://github.com/user-attachments/assets/e6d02a9a-4d4c-475e-afef-97e719a81d1b)

The key requirement that was fulfilled with this web application is 

*"As a manager, I want to access a user-friendly dashboard in Blazor where I can see ESG key metrics over time and receive recommendations for improvements, 
so I can better meet ESG standards and requirements."*

This requirement is fulfilled becase the user gets an overview of the environmental data. 
However, at current time there is space for improvement to make it more user-friendly. 

## How Frontend connects with our web service
Our Blazor application and API are connected via an `HttpClient`, configured in `Program.cs` with a base address pointing to the API at `https://localhost:5001/api/`. 
Blazor components can inject this client to send HTTP requests, such as retrieving data using the `GetFromJsonAsync` method. 
Authorization policies like `AdminPolicy` ensure access control, while CORS can be configured in the API to support cross-domain communication. 
Error handling provides a user-friendly response in the production environment, enabling efficient integration between our application and API.

Code Example: 
![image](https://github.com/user-attachments/assets/756d7f03-6d73-44f4-a3e0-d1602a5f8ae9)
