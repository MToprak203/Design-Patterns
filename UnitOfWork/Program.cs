using (var unitOfWork = new UnitOfWork())
{
    var productRepository = unitOfWork.ProductRepository;

    // Adding new products
    productRepository.Add(new Product { Id = 1, Name = "Product 1", Price = 10.99m });
    productRepository.Add(new Product { Id = 2, Name = "Product 2", Price = 20.49m });

    // Updating existing product
    var productToUpdate = productRepository.GetById(1);
    productToUpdate.Price = 15.99m;
    productRepository.Update(productToUpdate);

    // Deleting a product
    var productToDelete = productRepository.GetById(2);
    productRepository.Delete(productToDelete);

    // Saving changes
    unitOfWork.SaveChanges();
}