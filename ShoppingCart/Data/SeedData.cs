﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Data
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category fruits = new Category { Name = "Fruits", Slug = "fruits" };
                Category shirts = new Category { Name = "Shirts", Slug = "shirts" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "Apples",
                            Slug = "apples",
                            Description = "Juicy apples",
                            Price = 1.50m,
                            Category = fruits,
                            Image = "apples.jpg",
                            Vendor = "v1"
                        },
                        new Product
                        {
                            Name = "Bananas",
                            Slug = "bananas",
                            Description = "Fresh bananas",
                            Price = 3m,
                            Category = fruits,
                            Image = "bananas.jpg",
                            Vendor = "v1"
                        },
                        new Product
                        {
                            Name = "Watermelon",
                            Slug = "watermelon",
                            Description = "Juicy watermelon",
                            Price = 0.50m,
                            Category = fruits,
                            Image = "watermelon.jpg",
                            Vendor = "v1"
                        },
                        new Product
                        {
                            Name = "Grapefruit",
                            Slug = "grapefruit",
                            Description = "Juicy grapefruit",
                            Price = 2m,
                            Category = fruits,
                            Image = "grapefruit.jpg",
                            Vendor = "v1"
                        },
                        new Product
                        {
                            Name = "White shirt",
                            Slug = "white-shirt",
                            Description = "White shirt",
                            Price = 5.99m,
                            Category = shirts,
                            Image = "white shirt.jpg",
                            Vendor = "v1"
                        },
                        new Product
                        {
                            Name = "Black shirt",
                            Slug = "black-shirt",
                            Description = "Black shirt",
                            Price = 7.99m,
                            Category = shirts,
                            Image = "black shirt.jpg",
                            Vendor = "v1"
                        },
                        new Product
                        {
                            Name = "Yellow shirt",
                            Slug = "yellow-shirt",
                            Description = "Yellow shirt",
                            Price = 11.99m,
                            Category = shirts,
                            Image = "yellow shirt.jpg",
                            Vendor = "v1"
                        },
                        new Product
                        {
                            Name = "Grey shirt",
                            Slug = "grey-shirt",
                            Description = "Grey shirt",
                            Price = 12.99m,
                            Category = shirts,
                            Image = "grey shirt.jpg",
                            Vendor = "v1"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}
