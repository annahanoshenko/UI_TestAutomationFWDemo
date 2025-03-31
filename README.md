I created a page object model for UI automation testing of the site: https://www.demoblaze.com. 
Added automated logic to each page, created order and user entities, and together with the added methods, I used them to reduce code duplication. 
In PageBase, I added GetAlertWithWait, and AcceptAlert methods for correct work with alerts. 
In tests, I conduct positive and negative testing for registration, login, logout, adding and removing a product, and creating an order.
