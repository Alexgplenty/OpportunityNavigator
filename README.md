Opportunity Navigator
Overview

Opportunity Navigator is an AI-powered opportunity intelligence prototype that helps sales and customer success teams identify and prioritise high-value prospects based on website engagement behaviour.

The solution combines raw weblog data, generated purchase behavioural signals with Azure OpenAI to generate contextual opportunity briefs that help sales users understand:

Who is showing buying intent
What topics they are interested in
Why they should be prioritised
Suggested next actions

The prototype was developed as part of an AI Solutions Architect technical exercise.

Key Features
Opportunity Prioritisation

The application analyses visitor engagement data and calculates an overall purchase intent score based on:

Knowledge Centre visits
AI-related page visits
Product page visits
Sales page visits
Corporate page visits
Partner page visits
Legal page visits
Career page visits
Opportunity Profiles

Each opportunity includes:

Account identifier (an IP address of the visitor)
Company name
Country
Industry
Intent score
Detailed behavioural metrics
AI Opportunity Briefs

You can search for opportunities by IP address, Company Name, Country or Industry by typing in the search bar. To retrieve all opportunities, delete all text from the search bar.

Using Azure OpenAI, the solution generates natural-language opportunity summaries that:

Interpret behavioural signals
Identify buying intent
Highlight relevant interests
Recommend engagement strategies

Solution Architecture
Website Engagement Data (CSV generated from Excel)
              │
              ▼
     CsvOpportunityService (Top opportunities generated from SQL server stored procedure)
              │
              ▼
      Opportunity Navigator
              │
              ▼
     Opportunity Profile
              │
              ▼
      Prompt Generation
              │
              ▼
        Azure OpenAI
              │
              ▼
     AI Opportunity Brief

Technology Stack

Front End
ASP.NET Core Blazor (.NET 10)
Back End
ASP.NET Core
C#
AI
Azure OpenAI
GPT-based chat completion model (GPT 4.0)
Hosting
Docker
Render
Source Control
GitHub
Running Locally
Prerequisites
.NET 10 SDK
Azure OpenAI resource
Azure OpenAI deployment
Configuration

Create an appsettings.json file containing:

{
  "AzureOpenAI": {
    "Endpoint": "https://your-resource.openai.azure.com/",
    "ApiKey": "YOUR_API_KEY",
    "DeploymentName": "YOUR_DEPLOYMENT"
  }
}

Run
dotnet restore
dotnet build
dotnet run


Browse to:

https://localhost:xxxx

Deployment

The application is containerised using Docker and currently deployed to Render.

Deployment workflow:

Visual Studio
    ↓
GitHub
    ↓
Render
    ↓
Docker Build
    ↓
Live Application


Environment variables are configured using a linked Render Environment Group.

Required variables:

AzureOpenAI__Endpoint
AzureOpenAI__ApiKey
AzureOpenAI__DeploymentName

Data Source

The deployed demonstration version uses a CSV-backed repository which is baked into the runtime app for simplicity:

Data/Opportunities.csv


This approach:

Simplifies deployment
Removes database dependencies
Enables rapid demonstration
Reduces infrastructure overhead

The design can be extended to support:

SQL Server
Azure SQL
Data Lake
CRM integrations
Marketing automation platforms
Future Enhancements
Real-time website activity ingestion
Lead scoring models
Opportunity trend analysis
Multi-tenant architecture
Retrieval-Augmented Generation (RAG)
Account-based recommendation engine

Author

Alex Plenty

AI Solutions Architect Technical Exercise

## Live Demo

https://opportunitynavigator.onrender.com
