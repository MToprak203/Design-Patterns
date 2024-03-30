// Creating individual contributors
var developer1 = new IndividualContributor("John Doe");
var developer2 = new IndividualContributor("Jane Smith");

// Creating departments
var development = new Department("Development");
var marketing = new Department("Marketing");

// Adding components to departments
development.AddComponent(developer1);
development.AddComponent(developer2);
marketing.AddComponent(new IndividualContributor("Chris Brown"));
marketing.AddComponent(new IndividualContributor("Diana Johnson"));

// Creating company structure
var company = new Department("Company");
company.AddComponent(development);
company.AddComponent(marketing);

// Display the organizational hierarchy
company.DisplayHierarchy(1);