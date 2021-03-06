﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutomatZeStosem
{
    static class TabelkaGUI
    {
        public static void dodajRzad(DataGridView tabelka, string nazwaRzedu)
        {
            if (tabelka.ColumnCount == 0) throw new Exception("Najpierw dodaj kolumny!");
            DataGridViewRow row = new DataGridViewRow();
            row.HeaderCell.Value = nazwaRzedu;
            tabelka.Rows.Add(row);
        }

        public static void dodajKolumne(DataGridView tabelka, string nazwaKolumny)
        {
            tabelka.Columns.Add(nazwaKolumny, nazwaKolumny);
        }

        public static void usunOstatniRzad(DataGridView tabelka)
        {
            int liczbaRzedow = tabelka.Rows.Count;
            liczbaRzedow -= 2;
            if (liczbaRzedow == -1) // tylko jeden rząd
            {
                throw new Exception("Nie możesz usunąć ostatniego rzędu!");
            }
            if (liczbaRzedow < 0) throw new Exception("Brak rzędów!");
            tabelka.Rows.RemoveAt(tabelka.Rows[liczbaRzedow].Index);
        }

        public static void usunOstatniaKolumne(DataGridView tabelka)
        {
            int liczbaKolumn = tabelka.Columns.Count;
            liczbaKolumn -= 1;
            if (liczbaKolumn < 0) throw new Exception("Brak kolumn!");
            tabelka.Columns.RemoveAt(tabelka.Columns[liczbaKolumn].Index);
        }

        public static void zaznaczKomorke(DataGridView tabelka, int x, int y)
        {
            try
            {
                tabelka.CurrentCell = tabelka[x, y];
                tabelka.Refresh();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("x = " + x.ToString() + ", y = " + y.ToString(), e);
            }
        }

        public static void wpiszTekst(DataGridView tabelka, int x, int y, string tekst)
        {
            try
            {
                tabelka[x, y].Value = tekst;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("x = " + x.ToString() + ", y = " + y.ToString(), e);
            }
        }

        public static bool czyIstniejeRzad(DataGridView tabelka, string nazwaRzedu)
        {
            foreach (DataGridViewRow rzad in tabelka.Rows)
            {
                if (rzad.HeaderCell.Value == null) continue;
                if (rzad.HeaderCell.Value.ToString() == nazwaRzedu) return true;
            }
            return false;
        }

        public static bool czyIstniejeKolumna(DataGridView tabelka, string nazwaKolumny)
        {
            foreach (DataGridViewRow rzad in tabelka.Rows)
            {
                if (rzad.HeaderCell.Value.ToString() == nazwaKolumny) return true;
            }
            return false;
        }

        public static int pobierzLiczbeStanow(DataGridView tabelka)
        {
            return tabelka.Columns.Count;
        }

        public static int pobierzIndeksZnaku(DataGridView tabelka, string znak)
        {
            for (int i=0; i<tabelka.Rows.Count; i++)
            {
                if (tabelka.Rows[i].HeaderCell.Value.ToString() == znak) return i;
            }

            return -1;
        }

        public static List<char> pobierzListeZnakow(DataGridView tabelka)
        {
            List<char> ret = new List<char>();
            foreach (DataGridViewRow rzad in tabelka.Rows)
            {
                ret.Add(Char.Parse(rzad.HeaderCell.Value.ToString()));
            }
            return ret;
        }
    }
}
