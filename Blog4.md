# User Management 

**Users** 

The ESG Tracker system defines two primary user categories:Guest Users and Registered Users. 

**Guest Users** are Nilfisk employees who access the platform without logging in. They have limited functionality, such as only viewing general ESG KPI's or the about page shared by the organization. 

**Registered Users** include admin who must log in to access their features. The admin has access to the "Add / Edit Data page", 
where the admin can either; edit, add or edit data in the different tables. 

**Login Functionality**
AuthController.cs:

![image](https://github.com/user-attachments/assets/4c1a8f0f-c31e-41f2-bb8a-22bea5bba504)

This controller handles the login request and generates a JWT token upon successful authentication. 

AuthService.cs:

![image](https://github.com/user-attachments/assets/53e06753-9948-4a38-a281-e202118561d2)

This service validates the user credentials and registers new users.

IAuthService.cs:

![image](https://github.com/user-attachments/assets/4647317a-d569-4726-820a-51eb783e1c77)

This interface defines the methods for user validation and registration.
