// See https://aka.ms/new-console-template for more information




List<string> archivo = Directory.GetFiles(@"C:\tl1_tp8_2023-danielsj1996").ToList();

foreach (string archivos in archivo)
{
    string nombreArchivo = Path.GetFileName(archivos);
    string extension = Path.GetExtension(archivos);

    Console.WriteLine($"Nombre: {nombreArchivo}, Extension: {extension}");
}
string csvRuta = Path.Combine(@"C:\tl1_tp8_2023-danielsj1996", "index.csv");
GuardarArchivosCSV(archivo, csvRuta);


Console.WriteLine($"El listado de archivos se ha guardado en el archivo '{csvRuta}'.");


static void GuardarArchivosCSV(List<string> files, string csvRuta)
{
    using (StreamWriter writer = new StreamWriter(csvRuta))
    {
        writer.WriteLine("Indice,Nombre,Extension");

        for (int i = 0; i < files.Count; i++)
        {
            string nombreArchivo = Path.GetFileName(files[i]);
            string extension = Path.GetExtension(files[i]);

            writer.WriteLine($"{i + 1} -- {nombreArchivo} -- {extension}");
        }
    }
}
