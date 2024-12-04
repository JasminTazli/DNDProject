# User Management 

**Users** 

The ESG Tracker system defines two primary user categories:Guest Users and Registered Users. 

**Guest Users** are Nilfisk employees who access the platform without logging in. They have limited functionality, such as only viewing general ESG KPI's or the about page shared by the organization. 

**Registered Users** include admin who must log in to access their features. The admin has access to the "Add / Edit Data page", 
where the admin can either; edit, add or delete data in the different tables. 

## Login Functionality 

**AuthController.cs:**

![image](https://github.com/user-attachments/assets/4c1a8f0f-c31e-41f2-bb8a-22bea5bba504)

This controller handles the login request and generates a JWT token upon successful authentication. 

**AuthService.cs:**

![image](https://github.com/user-attachments/assets/53e06753-9948-4a38-a281-e202118561d2)

This service validates the user credentials and registers new users.

**IAuthService.cs:**

![image](https://github.com/user-attachments/assets/4647317a-d569-4726-820a-51eb783e1c77)

This interface defines the methods for user validation and registration.

**Login.razor** 

![image](https://github.com/user-attachments/assets/5c26b51a-ba71-4158-84c4-68a38e97dbb8)

This component handles the login form and calls the LoginAsync method from the IAuthService.

**CustomAuthProvider.cs:**

![image](https://github.com/user-attachments/assets/32ff9519-d736-4dbb-acd7-c3daf07d9d00)

This class provides the authentication state to the Blazor components.

**JwtAuthService.cs:**
- Properties
  - Jwt: Stores the JWT token.
  - OnAuthStateChanged: An action that gets invoked when the authentication state changes.
    
- Methods
  - LoginAsync: This method handles the login process. It creates a UserLoginDto object with the provided username and password.
    Serializes the object to JSON and sends it to the server via an HTTP POST request. If the response is successful, it extracts the JWT token from the response and caches it.
    It then creates a ClaimsPrincipal from the JWT and invokes OnAuthStateChanged.
    
![image](https://github.com/user-attachments/assets/70009347-b52a-42fc-87f2-d27bed90b603)

  - CreateClaimsPrincipal This method creates a ClaimsPrincipal from the JWT token. It first checks if there is a cached token and uses it if available. It adds the JWT token to the HTTP
    client's authorization header. Parses the claims from the JWT and creates a ClaimsIdentity and ClaimsPrincipal.
    
![image](https://github.com/user-attachments/assets/e57b21b3-d321-41a8-8e68-c372774370b5)


## Access to ressources between different actors
As mentioned abve, only the admin can see the "Add / Edit Data Page" and only the admin has access to it where the admin can either; edit, add or delete data in the different tables.
When you are not logged in and using it as a regular Nilfisk Employee wanting to just see the data, the "Add / Edit Data Page" is not 
visible as it should only be the admin that has access to it. 

![image](https://github.com/user-attachments/assets/75b9c268-48d0-444d-a96e-c20215a4c412)

![image](https://github.com/user-attachments/assets/46653188-1d2d-4f4b-b1cd-b7c4c63f9824)

