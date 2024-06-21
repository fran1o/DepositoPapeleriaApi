using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepositoLibreria.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Articulos
            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "Id", "NombreArt", "Descripcion", "Codigo", "Precio", "Stock" },
                values: new object[,] {
              { 1, "Cuaderno Univ", "Cuaderno rayado", 123456, 5.99, 100 },
{ 2, "Lápiz HB", "Lápiz grafito HB", 987654, 0.99, 500 },
{ 3, "Plumón Marc", "Plumón punta fina", 456789, 1.49, 200 },
{ 4, "Bolígrafo Gel", "Bolígrafo gel", 246810, 1.29, 300 },
{ 5, "Papel A4", "Papel impresora", 135792, 9.99, 50 },
{ 6, "Goma Borrar", "Goma plástica", 112233, 0.49, 1000 },
{ 7, "Regla 30cm", "Regla plástica", 369258, 0.79, 400 },
{ 8, "Libreta Notas", "Libreta tapa dura", 159357, 3.49, 150 },
{ 9, "Tijeras Escol", "Tijeras punta red", 785412, 1.99, 200 },
{ 10, "Cinta Adhes", "Cinta adhesiva", 951753, 2.29, 300 },
{ 11, "Cuaderno Peq", "Cuaderno rayado", 223456, 3.99, 100 },
{ 12, "Lápiz 2B", "Lápiz grafito 2B", 887654, 1.09, 500 },
{ 13, "Plumón Perm", "Plumón permanente", 556789, 1.59, 200 },
{ 14, "Bolígrafo Az", "Bolígrafo azul", 346810, 1.19, 300 },
{ 15, "Papel Carta", "Papel impresora", 235792, 10.99, 50 },
{ 16, "Goma Dura", "Goma plástica", 212233, 0.59, 1000 },
{ 17, "Regla Met 30cm", "Regla metálica", 469258, 1.79, 400 },
{ 18, "Libreta Peq", "Libreta tapa dura", 259357, 2.49, 150 },
{ 19, "Tijeras Gran", "Tijeras acero", 885412, 2.99, 200 },
{ 20, "Cinta Ancha", "Cinta adhesiva", 851753, 3.29, 300 },
{ 21, "Cuaderno Dib", "Cuaderno dibujo", 323456, 6.99, 100 },
{ 22, "Lápiz 4B", "Lápiz grafito 4B", 787654, 1.19, 500 },
{ 23, "Plumón Fluor", "Plumón fluoresc", 656789, 1.69, 200 },
{ 24, "Bolígrafo Ne", "Bolígrafo negro", 446810, 1.09, 300 },
{ 25, "Papel Oficio", "Papel impresora", 335792, 11.99, 50 },
{ 26, "Goma Negra", "Goma plástica", 312233, 0.69, 1000 },
{ 27, "Regla Madera", "Regla madera", 569258, 0.99, 400 },
{ 28, "Libreta Bocs", "Libreta bocetos", 359357, 4.49, 150 },
{ 29, "Tijeras Tela", "Tijeras cortar", 985412, 4.99, 200 },
{ 30, "Cinta Doble", "Cinta adhesiva", 751753, 2.59, 300 },
{ 31, "Cuaderno Mat", "Cuaderno cuadric", 423456, 5.49, 100 },
{ 32, "Lápiz 6B", "Lápiz grafito 6B", 687654, 1.29, 500 },
{ 33, "Plumón Met", "Plumón metálico", 756789, 1.79, 200 },
{ 34, "Bolígrafo Ve", "Bolígrafo verde", 546810, 1.39, 300 },
{ 35, "Papel Recicl", "Papel reciclado", 435792, 9.49, 50 },
{ 36, "Goma Arte", "Goma de arte", 412233, 0.79, 1000 },
{ 37, "Regla Flex 30", "Regla flexible", 669258, 1.29, 400 },
{ 38, "Libreta Camp", "Libreta resistente", 459357, 5.49, 150 },
{ 39, "Tijeras Telas", "Tijeras telas", 185412, 3.99, 200 },
{ 40, "Cinta Colores", "Cinta adhesiva", 651753, 2.99, 300 },
{ 41, "Cuaderno Viaj", "Cuaderno viaje", 523456, 4.99, 100 },
{ 42, "Lápiz Colores 1", "Lápices colores", 587654, 5.99, 500 },
{ 43, "Plumón Vidrio", "Plumón vidrio", 856789, 2.49, 200 },
{ 44, "Bolígrafo Ro", "Bolígrafo rojo", 646810, 1.49, 300 },
{ 45, "Papel Foto", "Papel fotográfico", 535792, 14.99, 50 },
{ 46, "Goma Milán", "Goma Milán", 512233, 0.89, 1000 },
{ 47, "Regla Plás 15", "Regla plástica", 769258, 0.59, 400 },
{ 48, "Libreta Adhes", "Libreta adhesiva", 559357, 3.99, 150 },
{ 49, "Tijeras Infan", "Tijeras niños", 285412, 1.29, 200 },
{ 50, "Cinta Embal", "Cinta embalaje", 551753, 1.99, 300 },
{ 51, "Cuaderno Lab", "Cuaderno lab", 623456, 7.49, 100 },
{ 52, "Lápiz Carbon", "Lápiz carbon", 487654, 2.99, 500 },
{ 53, "Plumón Ropa", "Plumón ropa", 956789, 3.49, 200 },
{ 54, "Bolígrafo Ret", "Bolígrafo retra", 746810, 1.59, 300 },
{ 55, "Papel Blanco", "Papel blanco", 635792, 8.99, 60 },
{ 56, "Goma Azul", "Goma azul", 612233, 0.79, 900 },
{ 57, "Regla Acrílic", "Regla acrílica", 869258, 1.09, 450 },
{ 58, "Libreta Espi", "Libreta espiral", 659357, 4.59, 180 },
{ 59, "Tijeras Plás", "Tijeras plástica", 385412, 2.49, 250 },
{ 60, "Cinta Mask", "Cinta masking", 651753, 1.69, 350 },
{ 61, "Cuaderno Tap", "Cuaderno tapas", 723456, 6.49, 110 },
{ 62, "Lápiz Gris", "Lápiz gris", 787654, 1.09, 520 },
{ 63, "Plumón Color", "Plumón colores", 956789, 1.99, 210 },
{ 64, "Bolígrafo Ros", "Bolígrafo rosa", 846810, 1.19, 320 },
{ 65, "Papel Roll", "Papel en rollo", 735792, 12.99, 70 },
{ 66, "Goma Blanca", "Goma blanca", 712233, 0.89, 1050 },
{ 67, "Regla Met", "Regla metálica", 969258, 1.59, 480 },
{ 68, "Libreta Liso", "Libreta lisa", 859357, 3.59, 160 },
{ 69, "Tijeras Peq", "Tijeras pequeñas", 485412, 1.69, 230 },
{ 70, "Cinta Papel", "Cinta papel", 851753, 1.79, 300 },
{ 71, "Cuaderno Eco", "Cuaderno recicl", 523457, 5.49, 90 },
{ 72, "Lápiz Colores", "Lápiz de colores", 187654, 6.99, 450 },
{ 73, "Plumón Art", "Plumón artístico", 256789, 2.59, 220 },
{ 74, "Bolígrafo Gr", "Bolígrafo gris", 346811, 1.29, 280 },
{ 75, "Papel Cuad", "Papel cuadricul", 235793, 9.89, 55 },
{ 76, "Goma Verde", "Goma verde", 212234, 0.69, 950 },
{ 77, "Regla Inox", "Regla inoxidable", 569259, 1.89, 370 },
{ 78, "Libreta A5", "Libreta tamaño A5", 459358, 3.99, 140 },
{ 79, "Tijeras Ciz", "Tijeras cizalla", 285413, 3.49, 210 },
{ 80, "Cinta Sella", "Cinta selladora", 751754, 1.89, 310 }
});

            // TiposMovimientos
            migrationBuilder.InsertData(
                table: "TiposMovimientos",
                columns: new[] { "Id", "Nombre", "esIncremento" },
                values: new object[,] {
                {1,"Compra", false },
                {2,"Venta", true },
                {3,"Devolución", false }
                });

            // Usuarios - Admins
            // Password: admin123 
            // 240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9 hash SHA3 de admin123
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre", "Apellido", "Email", "Password", "Discriminator" },
                values: new object[,] {
                    { 1, "Super", "Admin", "superadmin@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Encargado" },
                    { 2, "Usuario Test", "Uno", "usuario-1@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" },
                    { 3, "Usuario Test 2", "Dos", "usuario-2@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" },
                    { 4, "Admin", "Master", "admin@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Encargado" },
                    { 5, "John", "Doe", "john.doe@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" },
                    { 6, "Jane", "Smith", "jane.smith@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" },
                    { 7, "David", "Johnson", "david.johnson@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" },
                    { 8, "Emily", "Brown", "emily.brown@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" },
                    { 9, "Michael", "Williams", "michael.williams@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" },
                    { 10, "Sarah", "Taylor", "sarah.taylor@gmail.com", "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", "Usuario" }
                });


            // Movimientos
            migrationBuilder.InsertData(
                table: "Movimientos",
                columns: new[] { "Id", "FechaMov", "ArticuloMovId", "TipoMovId", "UsuarioId", "Cantidad" },
                values: new object[,] {
             { 1, DateTime.Now, 1, 1, 1, 10 },
    { 2, DateTime.Now, 2, 2, 2, 5 },
    { 3, DateTime.Now, 3, 3, 3, 7 },
    { 4, DateTime.Now, 4, 1, 4, 8 },
    { 5, DateTime.Now, 5, 2, 5, 6 },
    { 6, DateTime.Now, 6, 3, 6, 10 },
    { 7, DateTime.Now, 7, 1, 7, 3 },
    { 8, DateTime.Now, 8, 2, 8, 15 },
    { 9, DateTime.Now, 9, 3, 9, 12 },
    { 10, DateTime.Now, 10, 1, 10, 9 },
    { 11, DateTime.Now, 1, 2, 1, 11 },
    { 12, DateTime.Now, 2, 3, 2, 13 },
    { 13, DateTime.Now, 3, 1, 3, 14 },
    { 14, DateTime.Now, 4, 2, 4, 20 },
    { 15, DateTime.Now, 5, 3, 5, 25 },
    { 16, DateTime.Now, 6, 1, 6, 18 },
    { 17, DateTime.Now, 7, 2, 7, 22 },
    { 18, DateTime.Now, 8, 3, 8, 16 },
    { 19, DateTime.Now, 9, 1, 9, 9 },
    { 20, DateTime.Now, 10, 2, 10, 30 },
    { 21, DateTime.Now, 1, 3, 1, 7 },
    { 22, DateTime.Now, 2, 1, 2, 5 },
    { 23, DateTime.Now, 3, 2, 3, 8 },
    { 24, DateTime.Now, 4, 3, 4, 3 },
    { 25, DateTime.Now, 5, 1, 5, 5 },
    { 26, DateTime.Now, 6, 2, 6, 10 },
    { 27, DateTime.Now, 7, 3, 7, 15 },
    { 28, DateTime.Now, 8, 1, 8, 9 },
    { 29, DateTime.Now, 9, 2, 9, 20 },
    { 30, DateTime.Now, 10, 3, 10, 25 }
});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
