using Xunit;
using lab7v16;
using System.Collections.Generic;
using System.Linq;

namespace lab7v16.Tests;

public class InMemoryRepositoryTests
{
    [Fact]
    public void Add_ShouldAddNewItem()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        var post = new BlogPost { Id = 1, Title = "Test Title", Content = "Test Content", AuthorId = 5 };

        repo.Add(post);
        var result = repo.GetById(1);

        Assert.NotNull(result);
        Assert.Equal("Test Title", result.Title);
    }

    [Fact]
    public void GetById_ShouldReturnCorrectItem_WhenExists()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        repo.Add(new BlogPost { Id = 1, Title = "Post 1", Content = "Content 1", AuthorId = 1 });

        var result = repo.GetById(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void GetById_ShouldReturnNull_WhenNotExists()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        var result = repo.GetById(99);
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ShouldReturnAllItems()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        repo.Add(new BlogPost { Id = 1, Title = "A", Content = "A", AuthorId = 1 });
        repo.Add(new BlogPost { Id = 2, Title = "B", Content = "B", AuthorId = 2 });

        var results = repo.GetAll().ToList();
        Assert.Equal(2, results.Count);
    }

    [Fact]
    public void Update_ShouldModifyExistingItem()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        repo.Add(new BlogPost { Id = 1, Title = "Old Title", Content = "Old", AuthorId = 1 });

        var item = repo.GetById(1);
        item!.Title = "New Title";
        repo.Update(item);

        var updatedItem = repo.GetById(1);
        Assert.Equal("New Title", updatedItem!.Title);
    }

    [Fact]
    public void Update_ShouldThrowException_KeyNotFound()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        var nonExistent = new BlogPost { Id = 99, Title = "Ghost", Content = "Ghost", AuthorId = 1 };

        Assert.Throws<KeyNotFoundException>(() => repo.Update(nonExistent));
    }

    [Fact]
    public void Delete_ShouldRemoveItem_WhenExists()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        repo.Add(new BlogPost { Id = 1, Title = "Delete Me", Content = "...", AuthorId = 1 });

        repo.Delete(1);
        var result = repo.GetById(1);

        Assert.Null(result);
    }

    [Fact]
    public void Delete_ShouldThrowException_KeyNotFound()
    {
        IRepository<BlogPost> repo = new InMemoryRepository<BlogPost>();
        Assert.Throws<KeyNotFoundException>(() => repo.Delete(999));
    }
}