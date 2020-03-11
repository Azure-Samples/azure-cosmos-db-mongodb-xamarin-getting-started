---
page_type: sample
languages:
- csharp
products:
- azure
description: "Learn how to use Azure Cosmos DB with the MongoDB .NET API in a fully MVVM-enabled Xamarin.Forms application!"
urlFragment: azure-cosmos-db-mongodb-xamarin-getting-started
---

# Azure Cosmos DB for MongoDB API with Xamarin Quick Start

Learn how to use [Azure Cosmos DB](https://msou.co/bk7) with the [MongoDB .NET API](https://msou.co/bla) in a fully MVVM-enabled [Xamarin.Forms](https://msou.co/bk8) application!

![Bit Dev Advocate Learning Cartoon Image](./art/Bit_Learning.png)

## Concepts

This quick start demonstrates the following concepts:

* How to create and configure an Azure Cosmos DB for MongoDB API account
* How to use a Xamarin.Forms app with the MongoDB .NET SDK to connect to the Azure Cosmos DB for MongoDB API account.
* How to structure a Xamarin.Forms app with the MVVM pattern
* How to insert, update, and delete records from the Xamarin.Forms app into the Azure Cosmos DB for MongoDB API account.
* How to read and query records from the Azure Cosmos DB for MongoDB API account within a Xamarin.Forms app

## The Overview

We're going to build a simple todo app using the [Azure Cosmos DB for MongoDB API](https://msou.co/blb). Azure Cosmos DB is a fully managed globally distributed, multi-model database service, transparently replicating your data across any number of Azure regions. You can elastically scale throughput and storage, and take advantage of fast, single-digit-millisecond data access using the API of your choice backed by 99.999 SLA. In this quick start you're going to learn how to connect to your the Azure Cosmos DB for MongoDB API account within the context of a Xamarin.Forms mobile app. You'll see both how to access the database to read and write data and also how to architect an app using the MVVM design pattern.

### Prerequisites

You will need the following in order to run the quick start.

* An active Azure subscription (get a [free one here](https://msou.co/bk3)!)
* Visual Studio with the Mobile Development Workload installed (or Visual Studio for Mac)

## Creating an Azure Cosmos DB for MongoDB API Account

Follow the instructions found in the [documentation here](https://msou.co/bk4) to create an Azure Cosmos DB for MongoDB API account.

## Xamarin.Forms app

### Solution Structure

* TaskList.Core => This project contains all of the shared code including the Xamarin.Forms UI pages, view models, and database services.
* TaskList.Droid => This project contains the necessary platform code to run the Android app.
* TaskList.iOS => This project contains the necessary platform code to run the iOS app.

### Shared Code Structure

The following files are shared across the iOS and Android projects and are where all of the app logic reside.

* Helpers/APIKeys.cs
  * You must update the connection string within the TaskList.Core/Helpers/APIKeys.cs file before you run the app. See [this page for instructions](https://msou.co/bk5) on how to do so.
* Models/MyTask.cs => This file represents the document to be stored.
* Pages/SearchTaskListPage.xaml => UI for searching tasks based on date
* Pages/TaskDetailPage.xaml => UI for entering task details and saving
* Pages/TaskListPage.xaml => UI for viewing a list of tasks.
* Services/MongoService.cs => this contains **all** data access code.
* ViewModels/BaseViewModel.cs => provides common functionality for the rest of the view models
* ViewModels/SearchTaskViewModel.cs => view model for SearchTaskListPage.xaml, providing search app logic
* ViewModels/TaskDetailViewModel.cs => view model for TaskDetailPage.xaml, providing individual task view and save app logic
* ViewModels/TaskListViewModel.cs => view model for TaskListPage.xaml, providing app logic to list all tasks

### MVVM

This app employs the MVVM pattern. Each page located in the Pages directory is responsible for displaying data and collecting user interaction. Each of those pages also has exactly one corresponding view model. That view model is reponsible for interacting with any services and providing app logic used to display data, handle user the user events, and save the data. Databinding and commanding is used to pass data and events between the pages and view models.

There is also a data service class. This class is shared across the view models and is responsible for interacting with the Azure CosmosDB for MongoDB API.

### Interacting with Azure CosmosDB for MongoDB API

Please see [this documentation](https://msou.co/bk6) which reviews the code in-depth of how this app interacts with the Azure Cosmos DB.

## Resources

* [Azure Cosmos DB](https://msou.co/bk7)
* [Xamarin.Forms](https://msou.co/bk8)
* [Azure Cosmos DB for MongoDB API Reference](https://msou.co/bk9)
