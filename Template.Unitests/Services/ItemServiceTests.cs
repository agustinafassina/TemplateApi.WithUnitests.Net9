using TemplateApi.Services.Implementations;
using TemplateApi.Services.Dto;

namespace TemplateApi.Unitests.Services
{
    public class ItemServiceTests
    {
        private ItemService _service;

        public ItemServiceTests()
        {
            _service = new ItemService();
        }

        [Fact]
        public void GetAllItems_ReturnsInitialItems()
        {
            var result = _service.GetAllItems();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, i => i.Name == "Item 1");
            Assert.Contains(result, i => i.Name == "Item 2");
        }

        [Fact]
        public void GetItemById_ExistingId_ReturnsCorrectItem()
        {
            var item = _service.GetItemById(1);

            Assert.NotNull(item);
            Assert.Equal(1, item.Id);
            Assert.Equal("Item 1", item.Name);
        }

        [Fact]
        public void GetItemById_NonExistingId_ReturnsNull()
        {
            var item = _service.GetItemById(999);

            Assert.Null(item);
        }

        [Fact]
        public void CreateItem_AddsNewItemAndReturnsIt()
        {
            var newItemDto = new ItemCreateDto { Name = "Nuevo Item" };
            var newItem = _service.CreateItem(newItemDto);

            Assert.NotNull(newItem);
            Assert.Equal("Nuevo Item", newItem.Name);
            Assert.True(newItem.Id > 2);

            var allItems = _service.GetAllItems();
            Assert.Contains(allItems, i => i.Name == "Nuevo Item");
        }
    }
}