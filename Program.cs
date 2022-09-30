Console.WriteLine();

E_commerce db = new E_commerce();

List<Customer> customers = db.Customers.ToList<Customer>();

if (customers.Count == 0)
{
    Customer customer = new Customer();
    customer.Name = "Giulio";
    customer.Surname = "Rossi";
    customer.Email = "giulio@rossi.it";
    db.Add(customer);
    customer = new Customer();
    customer.Name = "Mario";
    customer.Surname = "Biondi";
    customer.Email = "mario@biondi.it";
    db.Add(customer);
    db.SaveChanges();
    customers = db.Customers.ToList<Customer>();
}

List<Employee> employees = db.Employees.ToList<Employee>();

if (employees.Count == 0)
{
    Employee employee = new Employee();
    employee.Name = "Luigi";
    employee.Surname = "Bianchi";
    employee.Level = "Capo Reparto";
    db.Add(employee);
    employee = new Employee();
    employee.Name = "Gino";
    employee.Surname = "Pino";
    employee.Level = "Stagista";
    db.Add(employee);
    db.SaveChanges();
    employees = db.Employees.ToList<Employee>();
}

List<Product> products = db.Products.ToList<Product>();

if (products.Count == 0)
{
    Product product = new Product();
    product.Name = "Scrivania";
    product.Description = "Una bella scrivania";
    product.Price = 129.99;
    db.Add(product);
    product = new Product();
    product.Name = "Lampada LED";
    product.Description = "Una bella lampada";
    product.Price = 29.99;
    db.Add(product);
    db.SaveChanges();
    products = db.Products.ToList<Product>();
}

Order order = new Order();
order.Date = DateTime.Now;
order.Customer = db.Customers.Where(customer => customer.CustomerId == 1).First();
order.Employee = db.Employees.Where(employee => employee.EmployeeId == 1).First();
order.Products = new List<Product>();
order.Products.Add(db.Products.Where(product => product.ProductId == 1).First());
order.Products.Add(db.Products.Where(product => product.ProductId == 2).First());
order.Status = "In lavorazione";
double amount = 0;
foreach (Product product in order.Products)
{
    amount += product.Price;
}
order.Amount = amount;
db.Add(order);
db.SaveChanges();
Payment payment = new Payment();
payment.Amount = amount;
payment.Order = order;
payment.Date = DateTime.Now;
payment.Status = "Accettato";
db.Add(payment);
db.SaveChanges();
List<Order> orders = db.Orders.ToList<Order>();

