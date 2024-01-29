ApiCSV
-------------------------------------------------------------------------------------------------------------------------------
Overview
This project consists of an API and a console application designed to read CSV data, process it, and store it in a database. The API is built using ASP.NET Core, and the console application provides a command-line interface for interacting with the data.

API Features

  -CsvController
The CsvController is responsible for handling CSV data operations. It includes the following endpoints:

GET /api/Csv/Test: A test endpoint for checking the functionality of CSV data operations.

  -OrganizationsController
The OrganizationsController manages CRUD operations for organizations. It includes the following endpoints:

GET /api/Organizations/get-organizations: Retrieve a list of all organizations.
GET /api/Organizations/{organizationId}: Retrieve information about a specific organization.
POST /api/Organizations/add-organization: Add a new organization.
PUT /api/Organizations/{organizationId}: Update information about a specific organization.
DELETE /api/Organizations/{organizationId}: Delete a specific organization.

  -StatisticController
The StatisticController provides statistical information about organizations. It includes the following endpoints:

GET /api/Statistic/organizationsWithMostEmployees: Retrieve organizations with the most employees.
GET /api/Statistic/organizations-count-by-country: Retrieve statistics on the number of organizations per country.


Console Application Features
The console application provides a command-line interface for interacting with the API. It includes the following features:

Add Organization: Add a new organization by providing relevant details.
Display Organizations: View a list of all organizations or details of a specific organization.
Update Organization: Modify information about a specific organization.
Delete Organization: Remove a specific organization.
Display Statistics: View statistics such as organizations with the most employees and the number of organizations per country.

Dependencies
ASP.NET Core
Entity Framework Core
CsvHelper
Quartz (commented out in Program.cs)
