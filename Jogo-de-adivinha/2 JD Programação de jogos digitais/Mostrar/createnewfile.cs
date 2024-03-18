using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class createnewfile : MonoBehaviour
{
    public static void createfile()
    {
        // Variáveis para mostrar o caminho de onde eu quero salvar
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "Valor.txt");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(Variaveis_Globais.Contador_de_kills);
        }
    }

    public static int lerarquivo()
    {
        // Variáveis para mostrar o caminho de onde eu quero salvar
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "Valor.txt");

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                int valorLido;
                if (int.TryParse(content, out valorLido))
                {
                    return valorLido;
                }
                else
                {
                    // Em caso de falha na conversão, retornar um valor padrão
                    return 0;
                }
            }
        }
        else
        {
            // Se o arquivo não existir, retornar um valor padrão
            return 0;
        }
    }
}
