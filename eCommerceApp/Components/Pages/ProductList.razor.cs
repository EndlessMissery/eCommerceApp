using eCommerceApp.DB;
using eCommerceApp.DB.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Components.Pages;

public partial class ProductList : ComponentBase
{
    [Parameter] public List<Product> Products { get; set; } = new();

    public EventCallback onProductSelected {get; set;}
    

private AppDbContext _context { get; set; }

    [Inject] public IDbContextFactory<AppDbContext> DbContextFactory { get; set; }

    protected override void OnInitialized()
    {
        _context = DbContextFactory.CreateDbContext();

        base.OnInitialized();
    }

    public async Task SelectProduct(Product product)
    {
        await onProductSelected.InvokeAsync(product);
    }
    public async Task LoadProducts()
    {
        Products = await _context.Products.ToListAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            await LoadProducts();
        }
}

}