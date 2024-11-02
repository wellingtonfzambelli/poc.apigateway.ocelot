# About
This project demonstrates how to implement an API Gateway using .NET 8 and Ocelot.

It includes two example Minimal APIs that are mapped through Ocelot to illustrate a simple, flexible API Gateway setup.

# Stacks of this project
- .NET 8
- Minimal Api
- Ocelot Api Gateway
- Postman  (for API testing)

# Project structure
![image](https://github.com/user-attachments/assets/8f0691e4-203f-4344-874f-13769ff92426)

# Catalog Api
I created the Catalog Api with static data and some methods to be exposed using localhost and the port 7240
![image](https://github.com/user-attachments/assets/f1793d8f-eb60-4a9e-b01b-671dcaf61f6a)
![image](https://github.com/user-attachments/assets/5c6b8330-d96b-448a-a1b5-5685a14d8580)

# Client Api
I created another api called Client with some methods using localhost and the port 5138
![image](https://github.com/user-attachments/assets/8696bd4e-0478-43ee-becc-f83e5a822763)
![image](https://github.com/user-attachments/assets/5286090e-ee4d-40de-a573-1424c3c3d5aa)

# Ocelot
Setting up program.cs
![image](https://github.com/user-attachments/assets/d4dab176-4789-4145-9f13-5a0a3f2c32bb)

setting up ocelot.json
![image](https://github.com/user-attachments/assets/f8394550-0e92-4e6a-92be-10484919b5b7)

# Postman sending request to Ocelot Api Gateway
![image](https://github.com/user-attachments/assets/aad40bd6-33be-480d-89d9-613385993494)

Ocelot Rate Limit
![image](https://github.com/user-attachments/assets/97f02cb1-df70-4e4b-b05b-76ff16a029ce)

