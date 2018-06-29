---
services: cosmos-db, xamarin
platforms: xamarin.forms, dotnet
author: codemillmatt
---

# Azure Cosmos DB - MongoDB API with Xamarin Quick Start

Learn how to use [Azure Cosmos DB](https://msou.co/bk7) with the [MongoDB .NET API](https://msou.co/bla) in a fully MVVM-enabled [Xamarin.Forms](https://msou.co/bk8) application!

![Bit Dev Advocate Learning Cartoon Image](./art/Bit_Learning.png)

## Concepts

This quick start demonstrates the following concepts:

* How to create and configure an Azure Cosmos DB MongoDB database account
* How to use a Xamarin.Forms app with the MongoDB .NET SDK to connect to the Azure Cosmos DB with MongoDB API database.
* How to structure a Xamarin.Forms app with the MVVM pattern
* How to insert, update, and delete records from the Xamarin.Forms app into the Azure Cosmos DB MongoDB database
* How to read and query records from the Azure Cosmos DB MongoDB database within a Xamarin.Forms app

## The Overview

We're going to build a simple todo app using the [Azure Cosmos DB MongoDB API](https://msou.co/blb). Azure Cosmos DB is a multi-model database - that means it supports several different types of underlying database APIs, like MongoDB or [Graph API](https://msou.co/blc) or [SQL](https://msou.co/bld). In this quick start you're going to learn how to use the MongoDB API within the context of a Xamarin.Forms mobile app. You'll see both how to access the database to read and write data and also how to architect an app using the MVVM design pattern.

### Prerequisites

You will need the following in order to run the quick start.

* An active Azure subscription (get a [free one here](https://msou.co/bk3)!)
* Visual Studio with the Mobile Development Workload installed (or Visual Studio for Mac)

## Creating an Azure Cosmos DB MongoDB Database Account

Follow the instructions found in the [documentation here](https://msou.co/bk4) to create an Azure Cosmos DB account using the MongoDB API.

## Xamarin.Forms app

### Solution Structure

* TaskList.Core => This project contains all of the shared code including the Xamarin.Forms UI pages, view models, and database services.
* TaskList.Droid => This project contains the necessary platform code to run the Android app.
* TaskList.iOS => This project contains the necessary platform code to run the iOS app.

### Shared Code Structure

The following files are shared across the iOS and Android projects and are where all of the app logic reside.

* Helpers/APIKeys.cs
  * You must update the connection string within the TaskList.Core/Helpers/APIKeys.cs file before you run the app. See [this page for instructions](https://msou.co/bk5) on how to do so.
* Models/MyTask.cs => This file represents the document to be stored in the MongoDB.
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

There is also a data service class. This class is shared across the view models and is responsible for interacting with the Azure CosmosDB with MongoDB API.

### Interacting with Azure CosmosDB with MongoDB API

Please see [this documentation](https://msou.co/bk6) which reviews the code in-depth of how this app interacts with the Azure Cosmos DB.

## Resources

* [Azure Cosmos DB](https://msou.co/bk7)
* [Xamarin.Forms](https://msou.co/bk8)
* [Azure Cosmos DB MongoDB API Reference](https://msou.co/bk9)