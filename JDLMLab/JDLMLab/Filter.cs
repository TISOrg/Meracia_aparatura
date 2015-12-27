using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class Filter
    {
        private enum returnType
        {
            rok,
            nazov,
            datum,
            typ,
            id
        }
        
        private string rok;
        private string nazov;
        private string typ;
        private string datum;

        //public returnType ReturnType
        //{
        //    get
        //    {
        //        return returnType;
        //    }
        //    set
        //    {

        //    }
        //}

        public string Rok {
            get {
               return rok;
            }
            
            set {
                typ = "";
                datum = "";
                nazov = "";
                rok = value;

            }
        }
        public string Nazov
        {
            get
            {
                return nazov;
            }
            set
            {
                typ = "";
                datum = ""; 
                nazov = value;
            }
        }
        public string Datum
        {
            get
            {
                return datum;
            }
            set
            {
                typ = "";
                datum = value;
            }
        }
        public string Typ
        {
            get
            {
                return typ;
            }
            set
            {

                typ = value;
            }
        }


    }
}
