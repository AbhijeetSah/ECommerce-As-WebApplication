# ECommerce-As-WebApplication

# Simple E-Commerce system having Clothes,Gadget and Groceries as Product

System Have two types of users


Project is developed in .NET framework
Project is designed in three tiers architecture

Project is using MVC framework for the development of application
Solution(Project) follow from WEB Module -->Business--> Repository each module is defined as project

WebApplication(EcommerceSystem) is consider as main project that link Shared (for connecting module of MVC), Bussiness as Business layer and Repository as physical layer from where we access database

Project is using MS-SQL Server(Microsoft) as database

---------------------------------------------------------------
NOTE:
Database credential
Backup the data base into ms sql server first as backup file is pushed with ECommerceSystem.bak

replace the webconfig from WebApplication(ECommerceSystem) project into Visual Studio inside "<connectionStrings> </connectionStrings>" tag with the connection link below

<add name="DefaultConnection" connectionString=" Data Source=DESKTOP-74V4SS7; Initial Catalog=ECommerceSystem; uid=sa; password=sasa;" providerName="System.Data.SqlClient" />

replace 
Data Source = You machine or serverIP
uid= your server UserId
password = Server login Password


------------------------------------------------------------------
application credential
default user designed for the system for test of the applicatio is
as follow:
userid:
nitesh.pkr1@gmail.com
password:
abc

 


