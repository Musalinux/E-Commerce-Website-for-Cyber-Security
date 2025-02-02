# CyberMusa - E-Commerce Website for Cybersecurity Products

## Table of Contents
1. [Introduction](#introduction)
2. [Success Criteria](#success-criteria)
3. [Design Process](#design-process)
   - [Sitemap](#sitemap)
   - [Design Planning and Stages](#design-planning-and-stages)
4. [Features and Components](#features-and-components)
   - [Home Page](#home-page)
   - [Products Page](#products-page)
   - [Contact Us Page](#contact-us-page)
   - [Login and Register Pages](#login-and-register-pages)
   - [Add to Cart Page](#add-to-cart-page)
   - [Payment Page](#payment-page)
   - [Order Confirmation Page](#order-confirmation-page)
   - [Admin Page](#admin-page)
5. [Testing and Evaluation](#testing-and-evaluation)
6. [Conclusion](#conclusion)
7. [References](#references)

---

## Introduction
CyberMusa is an e-commerce website designed to host top-rated cybersecurity products such as WiFi routers, Flippers, RubberDucky, and more. The website is developed using **ASP.NET Core Razor Pages**, **CSS**, **HTML**, **JavaScript**, and **C#**, with a focus on mitigating common security threats like **XSS**, **CSRF**, and **SQL injection**.

The website features:
- A **home page** with star-rated products.
- A **login page** for users to place orders and track them.
- An **admin page** for authorized admins to manage products and make necessary changes.

---

## Success Criteria
The following table outlines the key functionalities implemented in the project:

| **Success Criteria**       | **Priority** | **Implemented?**                                                                 |
|----------------------------|--------------|----------------------------------------------------------------------------------|
| Website Navigation         | Required     | Yes, using a simple nav bar in `_layouts.cshtml`.                                |
| Home Page                  | Required     | Yes.                                                                             |
| Account Control            | Optional     | Yes.                                                                             |
| About Us Page              | Required     | Yes, present in the Nav Bar.                                                     |
| Contact Page               | Required     | Yes.                                                                             |
| Login Page                 | Required     | Yes, implemented using ASP.NET Identity.                                         |
| User Registration Page     | Required     | Yes, implemented using ASP.NET Identity.                                         |
| Cart Page                  | Required     | Yes.                                                                             |
| Wishlist Page              | Required     | No.                                                                              |
| Order History Page         | Required     | No.                                                                              |
| Cart and Wishlist Icon     | Required     | Partial. Wishlist icon not implemented.                                          |
| Admin Page                 | Required     | Yes, admins can update product details, delete products, and add new products.   |
| Place Order Page           | Required     | Yes, includes a payment page.                                                    |
| Order Confirmation Page    | Optional     | Yes, redirects to the products page after confirmation.                          |
| Database                   | Required     | Yes, using a local MySQL database created via migrations.                        |

---

## Design Process
### Sitemap
The sitemap outlines the structure of the website, including all navigation bar items and their associated pages.

![image](https://github.com/user-attachments/assets/3337e76e-ac94-4ebe-b53e-472151ce59d5)


### Design Planning and Stages
1. **Initial Planning Phase**: 
   - IDE: Visual Studio 2022.
   - Tech Stack: ASP.NET Core Razor Pages, C#, JavaScript, HTML, CSS, MySQL.
   
2. **Competitive Analysis**: 
   - Analyzed e-commerce websites like Amazon, Flipkart, and Etsy for design inspiration.
   
3. **Set Up Visual Studio 2022**: 
   - Installed Visual Studio 2022 and used ASP.NET Core Razor Pages Empty Framework.
   
4. **Created a Sample Sitemap**: 
   - Used visualization tools to create a sitemap based on the wireframe.
   
5. **Front-End Development**: 
   - Developed using HTML, CSS, and Bootstrap. Pages include Home, About Us, Products, and Admin.
   
6. **Database Creation**: 
   - Created models (`products.cs`, `CartProducts.cs`) and performed migrations to create a MySQL database.
   
7. **Back-End Development**: 
   - Coded in C# for functionalities like product management, cart, and payment.
   
8. **Shopping Cart**: 
   - Implemented using C#. Users can add, update, and remove products from the cart.
   
9. **Payment Gateway**: 
   - Created a simple payment page (`payments.cshtml`) for entering card details.
   
10. **Admin Panel**: 
    - Created an admin page (`admin.cshtml`) for managing products.
   
11. **Login and Registration Pages**: 
    - Implemented using ASP.NET Identity.

---

## Features and Components
### Home Page
The home page is the landing page, divided into four sections:
1. **Carousel Section**: Displays three images with titles and descriptions.

![image](https://github.com/user-attachments/assets/6d94d832-3cc7-4099-b413-e63511ea2a18)

2. **About Us Section**: Provides a brief overview of the website.

![image](https://github.com/user-attachments/assets/94a3bfe4-4a5e-41ed-be72-6453b68269b4)

4. **Our Services Section**: Lists the services offered.
5. **Featured Products Section**: Displays products with a rating of 4 and above.

### Products Page
Displays products in a card format. Users can hover over products to highlight them.

![image](https://github.com/user-attachments/assets/ac026144-76ba-4a72-869a-5ce85cbbf0bb)


### Contact Us Page
Includes contact information (phone, email, business hours) and a Google Map integration.

![image](https://github.com/user-attachments/assets/8a1aefc3-10a4-44f0-a6c2-0159051e71e6)


### Login and Register Pages
- **Login Page**: Allows registered users to access their accounts.

![image](https://github.com/user-attachments/assets/e3f29363-74bf-4f6f-b877-79987831c5e8)

- **Register Page**: Allows new users to create an account.

![image](https://github.com/user-attachments/assets/533d6a56-8afc-4b58-bb62-8b99ae523554)


### Add to Cart Page
Users can add products to the cart, update quantities, and proceed to payment.

![image](https://github.com/user-attachments/assets/bbf48d79-0d14-422c-8cb3-942d1726ee56)

![image](https://github.com/user-attachments/assets/f7792cfb-51da-4ad3-8939-76035985f8e3)

### Payment Page
Users enter card details to complete the purchase. The cart is cleared upon confirmation.

![image](https://github.com/user-attachments/assets/1f51e2ad-2f2b-4d2f-8c4f-f87c58d67531)


### Order Confirmation Page
Displays a confirmation message and redirects users to the home page.

![image](https://github.com/user-attachments/assets/bdd60794-f94c-487c-a328-495fc0d53326)


### Admin Page
Allows admins to add, update, and delete products.

1) Admin Dashboard

![image](https://github.com/user-attachments/assets/d46fb837-b437-4940-98bf-7d022862b766)

2) Add Products Page

![image](https://github.com/user-attachments/assets/e1adbc3b-0429-4a8f-8b79-ccf8f726796a)

3) Manage Products Page

![image](https://github.com/user-attachments/assets/23a8ef6d-ba86-4a2e-81bc-8195a1e4e886)


---

## Testing and Evaluation
The website was tested with multiple sample users and admins. Key functionalities like the login page, payment page, and admin page were evaluated. The payment gateway works with dummy data, and further security practices can be implemented for real-world use.

---

## Conclusion
CyberMusa is a fully functional e-commerce website tailored for cybersecurity products. It incorporates security best practices and provides a user-friendly interface for customers and admins. The website is expandable, allowing for the addition of new products and features in the future.

---

## References
- [ASP.NET Core Razor Pages Tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-8.0&tabs=visual-studio)
- [Learn Razor Pages](https://www.learnrazorpages.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [W3Schools](https://www.w3schools.com/html/html_css.asp)
- [Bootstrap](https://getbootstrap.com/)
- [Font Awesome](https://fontawesome.com/icons)
- [MySQL](https://www.mysql.com/)
- [Amazon](https://www.amazon.com/)
- [Flipkart](https://www.flipkart.com/)
- [Etsy](https://www.etsy.com/uk/)
