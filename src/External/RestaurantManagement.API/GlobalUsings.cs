﻿global using Serilog;
global using MediatR;
global using System.Net;
global using System.Text;
global using System.Reflection;
global using RestaurantManagement.API;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.OData;
global using RestaurantManagement.API.Bases;
global using RestaurantManagement.Application;
global using Microsoft.AspNetCore.OData.Query;
global using Serilog.Sinks.SystemConsole.Themes;
global using Microsoft.AspNetCore.OData.Results;
global using Microsoft.AspNetCore.OutputCaching;
global using Microsoft.AspNetCore.Authorization;
global using RestaurantManagement.Infrastructure;
global using RestaurantManagement.Domain.Entities;
global using RestaurantManagement.Application.Models;
global using RestaurantManagement.Application.Exceptions;
global using RestaurantManagement.Application.Models.Dtos;
global using Microsoft.AspNetCore.OData.Routing.Controllers;
//global using RestaurantManagement.Application.Features.Images.Commands.CreateImage;
global using RestaurantManagement.Application.Features.Authentications.Commands.Login;
//global using RestaurantManagement.Application.Features.Files.Commands.SaveImageCommand;
global using RestaurantManagement.Application.Features.Addresses.Commands.UpdateAddress;
global using RestaurantManagement.Application.Features.Addresses.Commands.CreateAddress;
global using RestaurantManagement.Application.Features.Addresses.Commands.DeleteAddress;
global using RestaurantManagement.Application.Features.Authentications.Commands.Register;
global using RestaurantManagement.Application.Features.Categories.Commands.CreateCategory;
global using RestaurantManagement.Application.Features.Categories.Commands.DeleteCategory;
global using RestaurantManagement.Application.Features.Categories.Commands.UpdateCategory;
global using RestaurantManagement.Application.Features.Addresses.Queries.GetAddressesListQuery;
global using RestaurantManagement.Application.Features.Addresses.Queries.GetAddressDetailsQuery;
global using RestaurantManagement.Application.Features.Categories.Queries.GetCategoriesListQuery;
global using RestaurantManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery;
global using RestaurantManagement.Application.Features.Contacts.Commands.CreateContact;
global using RestaurantManagement.Application.Features.Contacts.Commands.DeleteContact;
global using RestaurantManagement.Application.Features.Contacts.Commands.UpdateContact;
global using RestaurantManagement.Application.Features.Contacts.Queries.GetContactDetailsQuery;
global using RestaurantManagement.Application.Features.Contacts.Queries.GetContactsListQuery;
global using RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipe;
global using RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeAddon;
global using RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeSize;
global using RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeAddonsList;
global using RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeDetails;
global using RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeSizesList;
global using RestaurantManagement.Application.Features.Recipes.Queries.GetRecipesList;
global using RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipe;
global using RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeAddon;
global using RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeSize;
global using RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipe;
global using RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeAddon;
global using RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeSize;
global using RestaurantManagement.Application.Features.Locations.Commands.CreateLocation;
global using RestaurantManagement.Application.Features.Locations.Commands.DeleteLocation;
global using RestaurantManagement.Application.Features.Locations.Commands.UpdateLocation;
global using RestaurantManagement.Application.Features.Locations.Queries.GetLocationDetails;
global using RestaurantManagement.Application.Features.Locations.Queries.GetLocationsList;
global using RestaurantManagement.Application.Features.Statuses.Commands.CreateStatus;
global using RestaurantManagement.Application.Features.Statuses.Commands.DeleteStatus;
global using RestaurantManagement.Application.Features.Statuses.Commands.UpdateStatus;
global using RestaurantManagement.Application.Features.Statuses.Queries.GetStatusDetails;
global using RestaurantManagement.Application.Features.Statuses.Queries.GetStatusesList;
global using RestaurantManagement.Application.Features.Sales.Commands.CreateSalesHeader;
global using RestaurantManagement.Application.Features.Sales.Commands.DeleteSalesHeader;
global using RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderDetails;
global using RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderList;
global using RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderSalesLinesList;
global using RestaurantManagement.Application.Features.Sales.Commands.UpdateSalesHeader;