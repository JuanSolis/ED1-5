using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jira_2._0.Utils;
using jira_2._0.Models;

namespace jira_2._0.Models
{
    enum cellState
    {
        vacio, ocupado, borrado
    }

    public class HashCell
    {
        public int hashTableLenght = 50;
        public string key { get; set; }
        public Task taskDetails { get; set; }

        internal cellState state;

         public HashCell()
        {
            state = cellState.vacio;
        }

        public int HashF(string cadena, int intento)
        {

            int suma = 0;
            int indice = 0;
            foreach (var posicion in cadena)
            {
                char posicionChar = posicion;
                suma = suma + posicionChar + intento;
            }

            indice = (suma + intento) % hashTableLenght;

            return indice;
        }

        public void insertEmptyCells ()
        {
            for (int i = 0; i < hashTableLenght; i++)
            {
                HashCell hashtest = new HashCell();
                hashtest.taskDetails =null;
                hashtest.key = null;
                hashtest.state = cellState.vacio;
                Storage.Instance.hashTable.Add(hashtest);
            }
        }

        public bool insert(string key, Task task)
        {
            int i = 0;
            int indice = 0;
            bool ocupado = false;

            while (ocupado == false)
            {
                indice = HashF(key, i);

                if (Storage.Instance.hashTable[indice].state == cellState.vacio)
                {
                    
                    Storage.Instance.hashTable[indice].key = key;
                    Storage.Instance.hashTable[indice].taskDetails = task;
                    Storage.Instance.hashTable[indice].state = cellState.ocupado;
                    ocupado = true;
                    return true;
                }
                else
                {
                    if (Storage.Instance.hashTable[indice].key == key)
                    {
                        break;
                    }
                    else
                    {
                        i++;
                    }

                }
         
            }
            return false;
        }

      
    }
}