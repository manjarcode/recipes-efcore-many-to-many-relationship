# Receta de Relación many to many en EF core

Vamos a Crear una relación N a N entre Post e Images

Para a hacerlo vamos a necesitar una entidad intermedia: PostImage

```
public class PostImageEntity {
	public Guid PostId { get; set; }
	
	public PostEntity Post { get; set; }
	
	public Guid ImageId { get; set; }
	
	public ImageEntity Image { get; set; }
}
```


Ahora vemos la entidad Post

```
public class PostEntity
{
	public Guid Id { get; set; }

	public IEnumerable<PostImagesEntity> Images { get; set; }

	public string Title { get; set; }

	public string Body { get; set; }

	public string Description { get; set; }
}
```

Y la entidad Image

```
public class ImageEntity
{
	public Guid Id { get; set; }

	public string Path { get; set; }

	public int Width { get; set; }

	public int Height { get; set; }

	public IEnumerable<PostImagesEntity> Posts { get; set; }
}
```

Finalmente hay que especificar la clave primaria de la tabla intermedia PostImagesEntity, lo haremos sobreescribiendo el método OnModelCreating del Contexto

```
public class Context : DbContext
{
	public Context(DbContextOptions<Context> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<PostImagesEntity>().HasKey(pi => new { pi.PostId, pi.ImageId });
	}

	public DbSet<PostEntity> Posts { get; set; }

	public DbSet<ImageEntity> Images { get; set; }

	public DbSet<PostImagesEntity> PostImages { get; set; }
}
```

Lo hacemos de esta forma para indicar un primary-key compuesta.

Para concluir, definimos un ContextFactory para establecer una connectionstring a la hora de hacer Add-Migration y Update-Database

```
public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
	private const string ConnectionStringLocal = "Server=localhost\\SQLEXPRESS;Database=many-to-many;Trusted_Connection=True;";

	public Context CreateDbContext(string[] args)
	{
		var builder = new DbContextOptionsBuilder<Context>();
		builder.UseSqlServer(ConnectionStringLocal);
		return new Context(builder.Options);
	}
}
```

Finalmente hacemos un Add-Migration + Update-Database y ya tenemos funcionando la base de datos

