using System;

namespace Listas
{

    class ListaEnlazada
    {
        private class Nodo
        {
            public int dato;
            public Nodo sig;

            public Nodo(int e)
            {
                dato = e;
            }
        }
        Nodo pri;
        public ListaEnlazada()
        {
            pri = null;
        }

        public void InsertaIni(int e)
        {
            Nodo ini = new Nodo(e);
            if (pri != null)
                ini.sig = pri;
            pri = ini;
        }

        public void InsertaFinal(int e)
        {
            if (pri != null)
            {
                Nodo aux = pri;
                while (aux.sig != null)
                {
                    aux = aux.sig;
                }
                aux.sig = new Nodo(e);
                aux.sig.sig = null;
            }
            else
                InsertaIni(e);
        }

        public void VerLista()
        {
            if (pri != null)
            {
                Nodo aux = pri;
                Console.WriteLine();
                while (aux != null)
                {
                    Console.WriteLine(aux.dato);
                    aux = aux.sig;
                }
            }
        }

        private Nodo buscaNodo(int e)
        {
            Nodo aux = pri;
            while (aux.sig != null && aux.dato != e)
            {
                aux = aux.sig;
            }
            if (aux.dato == e)
                return aux;
            else
                return null;
        }

        public bool buscaElto(int e)
        {
            if (buscaNodo(e) == null) return false;
            else return true;
        }

        public int suma()
        {
            int auxi = 0;
            for (Nodo aux = pri; aux != null; aux = aux.sig)
                auxi = auxi + aux.dato;
            return auxi;
        }

        public int cuentaEltos()
        {
            int auxi = 0;
            for (Nodo aux = pri; aux != null; aux = aux.sig)
                auxi++;
            return auxi;
        }

        public int cuentaOcurrencias(int e)
        {
            int auxi = 0;
            for (Nodo aux = pri; aux != null; aux = aux.sig)
                if (aux.dato == e)
                    auxi++;
            return auxi;
        }

        private Nodo nEsimoNodo(int n)
        {
            Nodo aux = pri;
            for(int i = 0; aux != null && i<n; i++)
            {
                aux = aux.sig;
            }
            return aux;
        }

        public int nEsimo(int n)
        {
            return nEsimoNodo(n).dato;
        }

        public void InsertaNesimo(int n, int e)
        {
            Nodo nuevo = new Nodo(e);
            if (n == 0)
                InsertaIni(e);
            else if (n <= cuentaEltos())
                InsertaFinal(e);
            else
            {
                nuevo.sig = nEsimoNodo(n);
                nEsimoNodo(n - 1).sig = nuevo;
            }


        }

        public void BorraElto(int e)
        {
            Nodo aux = pri;
            if (buscaElto(e))
            {
                while (aux.sig.dato != e)
                    aux = aux.sig;
                aux.sig = buscaNodo(e).sig;
            }

        }

        public void BorraTodos(int e)
        {
            while (buscaElto(e))
                BorraElto(e);
        }
    }


    class MainClass
    {
        static void Main()
        {
            ListaEnlazada lista = new ListaEnlazada();
            while (true)
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        lista.InsertaIni(int.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        lista.InsertaFinal(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        lista.VerLista();
                        break;
                    case 4:
                        int i = lista.cuentaOcurrencias(2);
                        Console.WriteLine(i);
                        break;
                }
            }
        }
    }
}