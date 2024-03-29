﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SedenaServices.Models.Clases;
using SedenaServices.Models;
using System.Web.Http.Cors;
namespace SedenaServices.Controllers
{
    [EnableCors(headers: "*", origins: "*", methods: "*")]
    public class ArmaController : ApiController
    {

        [HttpGet]
        // localhost/api/Doctor
        public IEnumerable<ArmaCLS> listaArma()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<ArmaCLS> listarArma = (from arm in bd.Arma
                                                         select new ArmaCLS
                                                         {
                                                             id_Arma = (int)arm.Id_Arma,
                                                             caracteristicas =arm.Caracteristicas
                                                         }).ToList();
                return listarArma;
            }
        }

        [HttpPut]
        public int eliminarArma(int id_Disparo)
        {
            int respuesta = 0;
            return respuesta;

        }
        // localhost/api/Doctor/
        [HttpPost]
        public int agregarArma(int id_arma, string caracteristicas)
        {
            Arma oArma = new Arma();
            oArma.Id_Arma = id_arma;
            oArma.Caracteristicas = caracteristicas;
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    bd.Arma.InsertOnSubmit(oArma);
                    bd.SubmitChanges();
                    respuesta = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta = 0;
            }
            return respuesta;
        }

        // localhost/api/Doctor/?iidDoctor=
        [HttpGet]
        public IEnumerable<ArmaCLS> RecuperarArma(int id_arma)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<ArmaCLS> listarArma = (from arm in bd.Arma
                                                         where arm.Id_Arma == id_arma
                                                         select new ArmaCLS
                                                         {
                                                             id_Arma = arm.Id_Arma,
                                                             caracteristicas=arm.Caracteristicas
                                                         }).ToList();
                return listarArma;
            }
        }

    }
}
