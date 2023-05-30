# Nextech Exercise

## General Description 

A Web system that connects to the [Hacker News API]("https://github.com/HackerNews/API") and shows the latest stories 

## Requirements 

As from the Email received the requirements are: 

Using the [Hacker News API]("https://github.com/HackerNews/API"), create a solution that allows users to view the newest stories from the feed

Your solution must be developed using an Angular front-end app that calls a C# .NET Core back-end restful API

At a minimum, the front-end UI should consist of:

- A list of the newest stories
- Each list item should include the title and a link to the news article. Watch out for stories that do not have hyperlinks!
- A search feature that allows users to find stories
- A paging mechanism. While we love reading, 200 stories on the page is a bit much.
- Automated tests for your code
 
At a minimum, the back-end API should consist of:

- Usage of dependency injection, it's built-in so why not?
- Caching of the newest stories
- Automated tests for your code


## Assumptions

- The calls to the [Hacker News API]("https://github.com/HackerNews/API") will be made in parallel 
- The cache will be initialiced at the application startup 
- When the Story does not have link, the story will be shown gray and unable to click on it 

## Time 

The time employed for this particular exercise was of about 42 hours

---------------

## Projects

The general Solution consists of two separed projects, one for the Backend (Angular) and another for the Frontend (C#)

### **Back API**

Nextech.Back.Api

Tech: .NET 6.0

#### Layers

- Api: Contains the **Controllers** with the REST Calls. And the Cache Initialization
- Business: The general logic, Server Side Pagination, Cache implementation, Parallelism for client calls,  and Mapping fom Model to DTO
- Client: The calls to the Hacker News API 
- Core: The Core Clases, like Models, DTOs, MappingProfiles, Interfaces, Response and Parameters

### **Front** 

Nextech.Web

Tech: Angular 16, Bootstrap 5.2.3, NG Bootstrap 14.1.1

#### Layers

- Api: 
  - The services that make the calls to the Back end to get tne Stories information
  - the DTO that mimick the Backend DTO and Response
- App: 
  - News: The components that shown the latest Stoies and the seach results
  - Components: General components used in the application
- Environment: Environment variable for the API (Backend) url
- Shared
  - Services: services used thought the application    



