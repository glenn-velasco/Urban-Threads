# eCommerce_BiliBits - Product and Review Models

This project is an e-commerce platform where users can view products, leave reviews, and rate products on a scale of 1-5 stars. The models include `Product` and `ProductReviews`, which are integrated with **ASP.NET Core Identity** for user management and authentication.

### Key Sections:
- **Introduction**: Describes the purpose and functionality of the project.
- **Prerequisites**: Lists required tools and technologies for running the project.
- **Installation Steps**: Provides a step-by-step guide for setting up the project locally.
- **Model Overview**: Explains the `Product` and `ProductReviews` models, including key fields and their purposes.
- **Testing the Review System**: Gives instructions for testing the product review functionality.
- **Troubleshooting**: Helps resolve common issues users may face.
- **Notes**: Provides additional information on constraints and setup.

## Features:
- **Product Model**: Represents a product with attributes like name, description, price, and image.
- **Product Reviews Model**: Allows users to submit reviews with a rating (1-5 stars) and a comment for each product.
- **ASP.NET Core Identity Integration**: Uses Identity for handling user authentication and associating reviews with specific users.

---

## Prerequisites:
- [.NET 8 or higher](https://dotnet.microsoft.com/download)
- [SQL Server] (VS Built In MSSQL Server)
- [Visual Studio 2022 or VS Code](https://code.visualstudio.com/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

---

## Installation Steps:

### 1. Clone the repository:
```bash
git clone https://github.com/your-repo/eCommerce_BiliBits.git
```

### 2. Navigate to the project directory:
```bash
cd eCommerce_BiliBits
```

### 4. Configure the database connection:

- Edit appsettings.json to set up your database connection string. For example, use the following configuration for SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=eCommerce_BiliBits;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 5. Create the database schema:
- Run the following command to create the database schema via EF Core migrations:
```
bash
dotnet ef database update
```

- or (Package Manage Console)

```bash
Update-Database

```

### 6. Run the application:
    - To run the application locally:
   CTRL SHIFT + B TO BUILD
   F5 TO RUN
### Model Overview:
Product Model:
```csharp

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "Product image is required")]
    [NotMapped]
    public IFormFile ImageFile { get; set; }

    public virtual ICollection<ProductReviews>? Reviews { get; set; }
}
Purpose: Represents a product in the e-commerce platform.

Key Fields:

Name: The name of the product.

Description: A detailed description of the product.

Price: The price of the product.

ImageUrl: The URL of the product's image.

ImageFile: Used for uploading a product image.

Reviews: Navigation property for related reviews.
```

ProductReviews Model:
```csharp

public class ProductReviews
{
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    public string? UserId { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    [StringLength(1000)]
    public string? Comment { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Product? Product { get; set; }

    [ForeignKey("UserId")]
    public virtual IdentityUser? User { get; set; }
}
Purpose: Represents a review for a product, including a rating (1-5 stars) and a comment.

Key Fields:

ProductId: Foreign key to the product being reviewed.

UserId: Foreign key linking the review to the user who submitted it.

Rating: The rating given to the product (between 1 and 5).

Comment: A textual comment left by the user.

CreatedDate: The date when the review was submitted.

Testing the Review System:
Steps to Test:
Add a Product:

Navigate to the "Add Product" page and fill out the form (name, description, price, and image).

Leave a Review:

Navigate to the product details page.

Select a rating (1-5) and submit a comment.

Check the product page to ensure that the review appears correctly with the star rating.

Verify Review Visibility:

Ensure all reviews for a product are listed, showing the username (or email), rating, comment, and submission date.

Verify that the correct number of stars is filled for each rating.

Troubleshooting:
No Review Displayed: If reviews are not showing up, ensure that the product and review models are correctly related in the database. Run migrations if needed.

Rating Issues: If the rating stars are not displayed correctly, make sure the frontend (HTML/JavaScript) for rendering the stars is set up to reflect the review rating.

Notes:
The Rating field in the ProductReviews model accepts only values between 1 and 5.

The application integrates ASP.NET Core Identity for handling user-specific reviews.

Make sure your database is correctly set up and migrated before testing.
```

If you encounter any issues or need further assistance, feel free to open an issue or contact Glenn Velasco.
