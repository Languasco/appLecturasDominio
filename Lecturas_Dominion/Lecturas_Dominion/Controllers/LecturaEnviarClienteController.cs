﻿using DSIGE.Modelo;
using DSIGE.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = OfficeOpenXml;
using Style = OfficeOpenXml.Style;


namespace DSIGE.Web.Controllers
{
    public class LecturaEnviarClienteController : Controller
    {
        //
        // GET: /LecturaEnviarCliente/

        public ActionResult Inicio()
        {
            return View();
        }



        public ActionResult Enviar_trabajos()
        {
            return View();
        }


        public static string _Serialize(object value, bool ignore = false)
        {
            var SerializerSettings = new JsonSerializerSettings()
            {
                MaxDepth = Int32.MaxValue,
                NullValueHandling = (ignore == true ? NullValueHandling.Ignore : NullValueHandling.Include)
            };
            return JsonConvert.SerializeObject(value, Formatting.Indented, SerializerSettings);
        }

        public ActionResult FotosLectura(string id_lectura, string opcion)
        {
            return new ContentResult
            {
                Content = MvcApplication._Serialize(
                        new Cls_Negocio_AsignarOrdenTrabajo().NListaFotos(Convert.ToInt32(id_lectura), Convert.ToInt32(opcion))
                    , true),
                ContentType = "application/json"
            };
        }
        
        [HttpPost]
        public string ListandoObservaciones(int TipoServicio)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaObservaciones(TipoServicio);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string set_anulandoFoto(int idLectura)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_set_anulandoFoto(idLectura, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }



        [HttpPost]
        public string ListandoObservacionesLecturas()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaObservacionesLectura();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoObservacionesCortes()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaObservacionesCortes();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string ListandoObservacionesCortesResultado()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaObservacionesCortesResultado();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string ListandoObservacionesReconexion()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaObservacionesReconexion();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoObservacionesReconexionResultado()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaObservacionesReconexionResultado();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }




        [HttpPost]
        public string ActualizandoLecturasRelecturas(int cod_lectura, string DatoModificar, string campoModificar)
        {
            string loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Set_ActualizandoLecturasRelecturas(cod_lectura, DatoModificar,campoModificar);
                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string ActualizandoCortesReconexiones(int cod_Cortelectura, string DatoModificar, string campoModificar, string comentarioCorte)
        {
            string loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Set_ActualizandoCortesReconexiones(cod_Cortelectura, DatoModificar, campoModificar , comentarioCorte,((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



        [HttpPost]
        public string ListandoFotosDescargar(string List_codigos, int servicio, int flag_multiple)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_DescargaFoto(List_codigos, servicio, flag_multiple, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string ListandoFotosDescargar_sinObservacion(string List_codigos, int servicio, int flag_multiple)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_DescargaFoto_sinObservacion(List_codigos, servicio, flag_multiple, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string ListandoFotosDescargar_new(int local , int servicio, string fecha_asignacion, int id_supervisor , int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_DescargaFoto_new(local, servicio, fecha_asignacion, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string ListandoFotosDescargar_new_SinObservacion(int local, int servicio, string fecha_asignacion, int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_DescargaFoto_new_sinObservacion(local, servicio, fecha_asignacion, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



        [HttpPost]
        public string ListandoPendientes(string fechaAsigna, int TipoServicio)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaVisualizacionesPendientes(fechaAsigna, TipoServicio);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string Listando_Detalles_Pendientes(int TipoServicio, string id_operario,string id_estado,string fechaAsigna)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaVisualizacionesPendientes_Detallado(TipoServicio, id_operario, id_estado, fechaAsigna);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }



        [HttpPost]
        public string ListandoLecturaEnviarCliente(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, string tipoCliente, int id_supervisor, int id_operario_supervisor, int SuministrosMasivos)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaLecturaEnviarCliente(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, id_local, id_tipo_servicio, estado, suministro, medidor, tecnico, fechaAsignacion, tipoCliente, id_supervisor, id_operario_supervisor, SuministrosMasivos,((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        /// <summary>
        ///  DESCARGAR ARCHIVOS
        /// </summary>
        [HttpPost]
        public string ListaPreEnvio(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.ListaPreEnvioExcelTexto(id_local,id_tipo_servicio,estado,fechaAsignacion);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        public FileInfo eliminarFiles(string _ruta) {
            FileInfo _file = new FileInfo(_ruta);
            if (_file.Exists)
            {
                _file.Delete();
                _file = new FileInfo(_ruta);
            }
            return _file;
        }
               

        //nuevo formato
        public string DescargaExcel_PreEnvio_CortesReconexiones(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, int id_supervisor, int id_operario_supervisor)
        {
            Int32 _fila = 2;
            string _servidor = "";
            String _ruta;
            string ruta_descarga = ConfigurationManager.AppSettings["Archivos"];
            int index = 0;
            string numerocontratoUltimo = "";

            try
            {

                _servidor = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id + "DescargaExcel_PreEnvio" + id_tipo_servicio + ".xlsx";
                _ruta = Path.Combine(Server.MapPath("~/Temp") + "\\" + _servidor);

                FileInfo _file = eliminarFiles(_ruta);
                string cadenaCnx = System.Configuration.ConfigurationManager.ConnectionStrings["dataSige"].ConnectionString;

                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_S_LECTURA_ENVIAR_CLIENTE_PRE_ENVIO_CORTE_RECO", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@empresa", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = id_tipo_servicio;
                        cmd.Parameters.Add("@idLocal", SqlDbType.Int).Value = id_local;
                        cmd.Parameters.Add("@suministro", SqlDbType.VarChar).Value = suministro;
                        cmd.Parameters.Add("@medidor", SqlDbType.VarChar).Value = medidor;
                        cmd.Parameters.Add("@tecnicoAsignado", SqlDbType.Int).Value = tecnico;
                        cmd.Parameters.Add("@estadoAsignacion", SqlDbType.Int).Value = estado;
                        cmd.Parameters.Add("@fechaAsignacion", SqlDbType.VarChar).Value = fechaAsignacion;

                        cmd.Parameters.Add("@id_supervisor", SqlDbType.Int).Value = id_supervisor;
                        cmd.Parameters.Add("@id_operario_supervisor", SqlDbType.Int).Value = id_operario_supervisor;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                            if (dt_detalle.Rows.Count <= 0)
                            {
                                return _Serialize("0|No hay informacion para mostrar.", true);
                            }
                            else
                            {
                                var nombreExcel = "";
                                index = 0;

                                if (id_tipo_servicio == 3)
                                {
                                    nombreExcel = "CORTES";

                                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                                    {
                                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add(nombreExcel);
                                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                                        index += 1; 

                                        oWs.Cells[1, index].Value = "Clase de aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Fecha de aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Hora de aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Documento de bloqueo"; index += 1;
                                        oWs.Cells[1, index].Value = "Ubicación de medidor "; index += 1;
                                        oWs.Cells[1, index].Value = "Cta.Contr."; index += 1;

                                        oWs.Cells[1, index].Value = "Nombre interlocutor"; index += 1;
                                        oWs.Cells[1, index].Value = "Clase cuenta"; index += 1;
                                        oWs.Cells[1, index].Value = "Deuda Soles"; index += 1;
                                        oWs.Cells[1, index].Value = "Cantidad de recibos"; index += 1;
                                        oWs.Cells[1, index].Value = "Instalación"; index += 1;
                                        oWs.Cells[1, index].Value = "N°Ser.Me."; index += 1;

                                        oWs.Cells[1, index].Value = "Dirección de Instal."; index += 1;
                                        oWs.Cells[1, index].Value = "Distrito de Instal."; index += 1;
                                        oWs.Cells[1, index].Value = "Unidad de Lectura"; index += 1;
                                        oWs.Cells[1, index].Value = "Ejecutante"; index += 1;

                                        oWs.Cells[1, index].Value = "Orden"; index += 1;
                                        oWs.Cells[1, index].Value = "Creado por"; index += 1;

                                        oWs.Cells[1, index].Value = "Status de sistema"; index += 1;
                                        oWs.Cells[1, index].Value = "Cód.codificación"; index += 1;
                                        oWs.Cells[1, index].Value = "Codificación"; index += 1;
                                        oWs.Cells[1, index].Value = "Contador"; index += 1;

                                        oWs.Cells[1, index].Value = "tcos"; index += 1;
                                        oWs.Cells[1, index].Value = "HORA"; index += 1;
                                        oWs.Cells[1, index].Value = "LECTURA "; index += 1;
                                        oWs.Cells[1, index].Value = "IMPOSIBILIDAD "; index += 1;
                                        oWs.Cells[1, index].Value = "OBSERVACION "; index += 1;

                                        foreach (DataRow oBj in dt_detalle.Rows)
                                        {
                                            index = 1;
                                            
                                            oWs.Cells[_fila, index].Value = oBj["claseAviso"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["aviso"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["fechaAviso"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["horaAviso_corte"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["docBloqueo"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["ubicacion_Medidor"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Style.Numberformat.Format = "###0";
                                            oWs.Cells[_fila, index].Value =Convert.ToDouble(oBj["ctaContrato"]); index += 1;


                                            oWs.Cells[_fila, index].Value = oBj["nombreInterlocutor"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["claseCuenta"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["Deuda_Soles"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["cantRecibos"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["instalacion"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Style.Numberformat.Format = "###0";
                                            oWs.Cells[_fila, index].Value = Convert.ToDouble(oBj["nroSerieMedidor"]); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["direcInstalacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["distritoInstalacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["unidadLectura"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["Ejecutante"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["orden"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["creadoPor"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["estatusSistema"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["codCodificacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["codificacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["contador"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["tcos"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["hora"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["lectura"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["imposibilidad"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["Observacion_corte"].ToString(); index += 1;

                                            _fila++;
                                        }

                                        oWs.Row(1).Style.Font.Bold = true;
                                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                                        for (int i = 1; i <= 28; i++)
                                        {
                                            oWs.Column(i).AutoFit();
                                        }

                                        oEx.Save();
                                    }
                                }
                                else
                                {
                                    nombreExcel = "RECONEXIONES";
                                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                                    {
                                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add(nombreExcel);
                                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                                        index = 1;
                                        oWs.Cells[1, index].Value = "Primera Reconexión "; index += 1;

                                        oWs.Cells[1, index].Value = "Clase de aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Fecha de aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Hora de aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Documento de bloqueo"; index += 1;
                                        oWs.Cells[1, index].Value = "Ubicacion de Medidor"; index += 1;
                                        oWs.Cells[1, index].Value = "Cta.Contr."; index += 1;

                                        oWs.Cells[1, index].Value = "Nombre interlocutor"; index += 1;
                                        oWs.Cells[1, index].Value = "Clase cuenta"; index += 1;
                                        oWs.Cells[1, index].Value = "Aviso"; index += 1;
                                        oWs.Cells[1, index].Value = "Cantidad de recibos"; index += 1;
                                        oWs.Cells[1, index].Value = "Instalación"; index += 1;
                                        oWs.Cells[1, index].Value = "N°Ser.Me."; index += 1;

                                        oWs.Cells[1, index].Value = "Dirección de Instal."; index += 1;
                                        oWs.Cells[1, index].Value = "Distrito de Instal."; index += 1;
                                        oWs.Cells[1, index].Value = "Unidad de Lectura"; index += 1;
                                        oWs.Cells[1, index].Value = "Ejecutante"; index += 1;

                                        oWs.Cells[1, index].Value = "Orden"; index += 1;
                                        oWs.Cells[1, index].Value = "Creado por"; index += 1;
                                        oWs.Cells[1, index].Value = "Contador"; index += 1;
                                        oWs.Cells[1, index].Value = "Estado Instalación"; index += 1;
                                        oWs.Cells[1, index].Value = "Status de usuario"; index += 1;

                                        oWs.Cells[1, index].Value = "Status de sistema"; index += 1;
                                        oWs.Cells[1, index].Value = "Codificación"; index += 1;
                                        oWs.Cells[1, index].Value = "Cód.codificación"; index += 1;

                                        oWs.Cells[1, index].Value = "tcos"; index += 1;
                                        oWs.Cells[1, index].Value = "Fecha"; index += 1;

                                        oWs.Cells[1, index].Value = "HORA"; index += 1;
                                        oWs.Cells[1, index].Value = "LECTURA "; index += 1;
                                        oWs.Cells[1, index].Value = "IMPOSIBILIDAD "; index += 1;
                                        oWs.Cells[1, index].Value = "NOMBRE DEL CLIENTE"; index += 1;
                                        oWs.Cells[1, index].Value = "OBSERVACION "; index += 1;
                                        
                                        oWs.Cells[1, index].Value = "Hora Inicio "; index += 1;
                                        oWs.Cells[1, index].Value = "Hora Termino "; index += 1;

                      

                                        foreach (DataRow oBj in dt_detalle.Rows)
                                        {
                                            index = 1;

                                            oWs.Cells[_fila, index].Value = oBj["primeraReconexion"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["claseAviso"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["aviso"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["fechaAviso"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["horaAviso_corte"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["docBloqueo"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["ubicacion_Medidor"].ToString(); index += 1;

                                            numerocontratoUltimo = oBj["ctaContrato"].ToString();

                                            oWs.Cells[_fila, index].Style.Numberformat.Format = "###0";
                                            oWs.Cells[_fila, index].Value = Convert.ToDouble(oBj["ctaContrato"]); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["nombreInterlocutor"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["claseCuenta"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["aviso"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["cantRecibos"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["instalacion"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Style.Numberformat.Format = "###0";
                                            oWs.Cells[_fila, index].Value = Convert.ToDouble(oBj["nroSerieMedidor"]); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["direcInstalacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["distritoInstalacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["unidadLectura"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["Ejecutante"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["orden"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["creadoPor"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["contador"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["estadoInstalacion"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["estatusUsuario"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["estatusSistema"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["codificacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["codCodificacion"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["tcos"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["fechaTrabajo"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["hora"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["lectura"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["imposibilidad"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["nombreCliente"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["Observacion_corte"].ToString(); index += 1;

                                            oWs.Cells[_fila, index].Value = oBj["horaInicio"].ToString(); index += 1;
                                            oWs.Cells[_fila, index].Value = oBj["horaTermino"].ToString(); index += 1;

                                            _fila++;
                                        }

                                        oWs.Row(1).Style.Font.Bold = true;
                                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                                        for (int i = 1; i <= 35; i++)
                                        {
                                            oWs.Column(i).AutoFit();
                                        }

                                        oEx.Save();
                                    }
                                }

                                return _Serialize("1|" + ruta_descarga + _servidor, true);

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                numerocontratoUltimo = numerocontratoUltimo;
                return _Serialize("0|" + ex.Message, true);
            }
        }




        [HttpPost]
        public string DescargaExcel_PreEnvio_xxxxxx(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, int id_supervisor, int id_operario_supervisor)
        {
            Int32 _fila = 2;
            string _servidor;
            String _ruta;

            try
            {
                List<Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio> _lista = new List<Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio>();

                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                _lista = obj_negocio.Capa_Negocio_DescargaExcel_PreEnvio(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, id_local, id_tipo_servicio, estado, suministro, medidor, tecnico, fechaAsignacion, id_supervisor, id_operario_supervisor);

                if (_lista.Count == 0)
                {
                    return _Serialize("0|No hay informacion para mostrar.", true);
                }

                //_servidor = String.Format("{0:ddMMyyyy_hhmmss}.xlsx", DateTime.Now);
                _servidor = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id + "DescargaExcel_PreEnvio" + id_tipo_servicio + ".xlsx";
                _ruta = Path.Combine(Server.MapPath("~/Temp") + "\\" + _servidor);

                FileInfo _file = new FileInfo(_ruta);
                if (_file.Exists)
                {
                    _file.Delete();
                    _file = new FileInfo(_ruta);
                }

                if (id_tipo_servicio == 3) // cortes
                {
                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                    {
                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("Importar");
                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                        oWs.Cells[1, 1].Value = "Clase de aviso";
                        oWs.Cells[1, 2].Value = "Aviso";
                        oWs.Cells[1, 3].Value = "Fecha de aviso";
                        oWs.Cells[1, 4].Value = "Documento de bloqueo";
                        oWs.Cells[1, 5].Value = "Cta.Contr.";

                        oWs.Cells[1, 6].Value = "Nombre interlocutor";
                        oWs.Cells[1, 7].Value = "Clase cuenta";
                        oWs.Cells[1, 8].Value = "Deuda Soles";
                        oWs.Cells[1, 9].Value = "Cantidad de recibos";
                        oWs.Cells[1, 10].Value = "Instalación";
                        oWs.Cells[1, 11].Value = "N°Ser.Me.";

                        oWs.Cells[1, 12].Value = "Dirección de Instal.";
                        oWs.Cells[1, 13].Value = "Distrito de Instal.";
                        oWs.Cells[1, 14].Value = "Unidad de Lectura";
                        oWs.Cells[1, 15].Value = "Ejecutante";

                        oWs.Cells[1, 16].Value = "Orden";
                        oWs.Cells[1, 17].Value = "Creado por";

                        oWs.Cells[1, 18].Value = "Status de sistema";
                        oWs.Cells[1, 19].Value = "Cód.codificación";
                        oWs.Cells[1, 20].Value = "Codificación";
                        oWs.Cells[1, 21].Value = "Contador";

                        oWs.Cells[1, 22].Value = "tcos";
                        oWs.Cells[1, 23].Value = "HORA";
                        oWs.Cells[1, 24].Value = "LECTURA ";
                        oWs.Cells[1, 25].Value = "IMPOSIBILIDAD ";

                        foreach (Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio oBj in _lista)
                        {


                            oWs.Cells[_fila, 1].Value = oBj.claseAviso;
                            oWs.Cells[_fila, 2].Value = oBj.aviso;
                            oWs.Cells[_fila, 3].Value = oBj.fechaAviso;
                            oWs.Cells[_fila, 4].Value = oBj.docBloqueo;
                            oWs.Cells[_fila, 5].Value = oBj.ctaContrato;
                            oWs.Cells[_fila, 6].Value = oBj.nombreInterlocutor;

                            oWs.Cells[_fila, 7].Value = oBj.claseCuenta;
                            oWs.Cells[_fila, 8].Value = oBj.Deuda_Soles;
                            oWs.Cells[_fila, 9].Value = oBj.cantRecibos;
                            oWs.Cells[_fila, 10].Value = oBj.instalacion;
                            oWs.Cells[_fila, 11].Value = oBj.nroSerieMedidor;

                            oWs.Cells[_fila, 12].Value = oBj.direcInstalacion;
                            oWs.Cells[_fila, 13].Value = oBj.distritoInstalacion;
                            oWs.Cells[_fila, 14].Value = oBj.unidadLectura;
                            oWs.Cells[_fila, 15].Value = oBj.Ejecutante;

                            oWs.Cells[_fila, 16].Value = oBj.orden;
                            oWs.Cells[_fila, 17].Value = oBj.creadoPor;

                            oWs.Cells[_fila, 18].Value = oBj.estatusSistema;
                            oWs.Cells[_fila, 19].Value = oBj.codCodificacion;
                            oWs.Cells[_fila, 20].Value = oBj.codificacion;
                            oWs.Cells[_fila, 21].Value = oBj.contador;

                            oWs.Cells[_fila, 22].Value = oBj.tcos;
                            oWs.Cells[_fila, 23].Value = oBj.hora;
                            oWs.Cells[_fila, 24].Value = oBj.lectura;
                            oWs.Cells[_fila, 25].Value = oBj.imposibilidad;
                            _fila++;
                        }

                        oWs.Row(1).Style.Font.Bold = true;
                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                        //oWs.Column(1).Style.Font.Bold = true;

                        for (int i = 1; i <= 25; i++)
                        {
                            oWs.Column(i).AutoFit();
                        }

                        oEx.Save();
                    }
                }
                else if (id_tipo_servicio == 4) // Reconexion
                {

                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                    {
                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("Importar");
                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));


                        oWs.Cells[1, 1].Value = "Clase de aviso";
                        oWs.Cells[1, 2].Value = "Aviso";
                        oWs.Cells[1, 3].Value = "Fecha de aviso";
                        oWs.Cells[1, 4].Value = "Documento de bloqueo";
                        oWs.Cells[1, 5].Value = "Cta.Contr.";

                        oWs.Cells[1, 6].Value = "Nombre interlocutor";
                        oWs.Cells[1, 7].Value = "Clase cuenta";
                        oWs.Cells[1, 8].Value = "Aviso";
                        oWs.Cells[1, 9].Value = "Cantidad de recibos";
                        oWs.Cells[1, 10].Value = "Instalación";
                        oWs.Cells[1, 11].Value = "N°Ser.Me.";

                        oWs.Cells[1, 12].Value = "Dirección de Instal.";
                        oWs.Cells[1, 13].Value = "Distrito de Instal.";
                        oWs.Cells[1, 14].Value = "Unidad de Lectura";
                        oWs.Cells[1, 15].Value = "Ejecutante";

                        oWs.Cells[1, 16].Value = "Orden";
                        oWs.Cells[1, 17].Value = "Creado por";
                        oWs.Cells[1, 18].Value = "Contador";
                        oWs.Cells[1, 19].Value = "Estado Instalación";
                        oWs.Cells[1, 20].Value = "Status de usuario";

                        oWs.Cells[1, 21].Value = "Status de sistema";
                        oWs.Cells[1, 22].Value = "Codificación";
                        oWs.Cells[1, 23].Value = "Cód.codificación";

                        oWs.Cells[1, 24].Value = "tcos";
                        oWs.Cells[1, 25].Value = "HORA";
                        oWs.Cells[1, 26].Value = "LECTURA ";
                        oWs.Cells[1, 27].Value = "IMPOSIBILIDAD ";
                        oWs.Cells[1, 28].Value = "NOMBRE DEL CLIENTE";

                        foreach (Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio oBj in _lista)
                        {



                            oWs.Cells[_fila, 1].Value = oBj.claseAviso;
                            oWs.Cells[_fila, 2].Value = oBj.aviso;
                            oWs.Cells[_fila, 3].Value = oBj.fechaAviso;
                            oWs.Cells[_fila, 4].Value = oBj.docBloqueo;
                            oWs.Cells[_fila, 5].Value = oBj.ctaContrato;
                            oWs.Cells[_fila, 6].Value = oBj.nombreInterlocutor;

                            oWs.Cells[_fila, 7].Value = oBj.claseCuenta;
                            oWs.Cells[_fila, 8].Value = oBj.aviso;
                            oWs.Cells[_fila, 9].Value = oBj.cantRecibos;
                            oWs.Cells[_fila, 10].Value = oBj.instalacion;
                            oWs.Cells[_fila, 11].Value = oBj.nroSerieMedidor;

                            oWs.Cells[_fila, 12].Value = oBj.direcInstalacion;
                            oWs.Cells[_fila, 13].Value = oBj.distritoInstalacion;
                            oWs.Cells[_fila, 14].Value = oBj.unidadLectura;

                            oWs.Cells[_fila, 15].Value = oBj.Ejecutante;
                            oWs.Cells[_fila, 16].Value = oBj.orden;
                            oWs.Cells[_fila, 17].Value = oBj.creadoPor;
                            oWs.Cells[_fila, 18].Value = oBj.contador;
                            oWs.Cells[_fila, 19].Value = oBj.estadoInstalacion;

                            oWs.Cells[_fila, 20].Value = oBj.estatusUsuario;
                            oWs.Cells[_fila, 21].Value = oBj.estatusSistema;

                            oWs.Cells[_fila, 22].Value = oBj.codificacion;
                            oWs.Cells[_fila, 23].Value = oBj.codCodificacion;
                            oWs.Cells[_fila, 24].Value = oBj.tcos;

                            oWs.Cells[_fila, 25].Value = oBj.hora;
                            oWs.Cells[_fila, 26].Value = oBj.lectura;
                            oWs.Cells[_fila, 27].Value = oBj.imposibilidad;
                            oWs.Cells[_fila, 28].Value = oBj.nombreCliente;
                            _fila++;
                        }

                        oWs.Row(1).Style.Font.Bold = true;
                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                        //oWs.Column(1).Style.Font.Bold = true;

                        for (int i = 1; i <= 28; i++)
                        {
                            oWs.Column(i).AutoFit();
                        }

                        oEx.Save();
                    }
                }

                return _Serialize("1|" + _servidor, true);


            }
            catch (Exception ex)
            {
                return _Serialize("0|" + ex.Message, true);
            }
        }


        [HttpPost]
        public string DescargaExcel_PreEnvio(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, int  id_supervisor, int id_operario_supervisor)
        {
            Int32 _fila = 2;
            string _servidor ="";
            String _ruta;
            string ruta_descarga = ConfigurationManager.AppSettings["Archivos"];

            try
            {
                List<Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio> _lista = new List<Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio>();

                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                _lista = obj_negocio.Capa_Negocio_DescargaExcel_PreEnvio(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, id_local, id_tipo_servicio, estado, suministro, medidor, tecnico, fechaAsignacion, id_supervisor, id_operario_supervisor);
                
                if (_lista.Count == 0)
                {
                    return _Serialize("0|No hay informacion para mostrar.", true);
                }
 
               if (id_tipo_servicio==1 || id_tipo_servicio==2 || id_tipo_servicio == 9)  // lecturas relecturasY RECLAMOS
                {
                    _servidor = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id + "DescargaExcel_PreEnvio" + id_tipo_servicio + ".xlsx";
                    _ruta = Path.Combine(Server.MapPath("~/Temp") + "\\" + _servidor);

                    FileInfo _file = eliminarFiles(_ruta);

                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                    {
                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("Importar");
                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                        oWs.Cells[1, 1].Value = "ITEM";
                        oWs.Cells[1, 2].Value = "INSTALACIÓN";
                        oWs.Cells[1, 3].Value = "EQUIPO";
                        oWs.Cells[1, 4].Value = "MEDIDOR";
                        oWs.Cells[1, 5].Value = "CTA.CTO";
                        oWs.Cells[1, 6].Value = "FECHA PLAN LECTURA";
                        oWs.Cells[1, 7].Value = "FECHA REAL DE LECTURA";
                        oWs.Cells[1, 8].Value = "HORA DE LECTURA REAL";
                        oWs.Cells[1, 9].Value = "LECTURA";
                        oWs.Cells[1, 10].Value = "NOTA DE LECTURISTA";
                        oWs.Cells[1, 11].Value = "CÓDIGO DE COMENTARIO";
                        oWs.Cells[1, 12].Value = "COMENTARIO";
                        oWs.Cells[1, 13].Value = "CODIGO DE LECTOR";
                        oWs.Cells[1, 14].Value = "DESPLAZAMIENTO";
                        oWs.Cells[1, 15].Value = "FOTO";

                        int acu = 0;

                        foreach (Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio oBj in _lista)
                        {
                            acu = acu + 1;
                            oWs.Cells[_fila, 1].Value = acu;
                            oWs.Cells[_fila, 2].Value = oBj.nroInstalacion_lectura;
                            oWs.Cells[_fila, 3].Value = oBj.nroEquipo_lectura;
                            oWs.Cells[_fila, 4].Value = oBj.medidor_lectura;
                            oWs.Cells[_fila, 5].Value = oBj.CuentaContrato;
                            oWs.Cells[_fila, 6].Value = oBj.FechaPlanLectura;
                            oWs.Cells[_fila, 7].Value = oBj.FechaRealLectura;

                            oWs.Cells[_fila, 8].Value = oBj.HoraLecturaReal;
                            oWs.Cells[_fila, 8].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            oWs.Cells[_fila, 8].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center; // alinear texto 

                            oWs.Cells[_fila, 9].Value = oBj.Lectura;
                            oWs.Cells[_fila, 9].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            oWs.Cells[_fila, 9].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto 

                            oWs.Cells[_fila, 10].Value = oBj.NotaLecturista;
                            oWs.Cells[_fila, 11].Value = oBj.CodigoComentario;
                            oWs.Cells[_fila, 12].Value = oBj.Comentario;
                            oWs.Cells[_fila, 13].Value = oBj.CodigoLector;
                            oWs.Cells[_fila, 13].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            oWs.Cells[_fila, 13].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center; // alinear texto 

                            oWs.Cells[_fila, 14].Value = oBj.desplazamiento;
                            oWs.Cells[_fila, 15].Value = oBj.tieneFoto;
                            
                            _fila++;
                        }

                        oWs.Row(1).Style.Font.Bold = true;
                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                        for (int i = 1; i < 15; i++)
                        {
                            oWs.Column(i).AutoFit();
                        }                         

                        oEx.Save();
                    }
                }
                        
                 return _Serialize("1|" + ruta_descarga + _servidor, true);

 
            }
            catch (Exception ex)
            {
                return _Serialize("0|" + ex.Message, true);
            }
        }

        
        [HttpPost]
        public string DescargaExcel_EnviarCliente(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, int id_supervisor, int id_operario_supervisor)
        {
            Int32 _fila = 2;
            string _servidor;
            String _ruta;
            string resultado = "";
            string ruta_descarga = ConfigurationManager.AppSettings["Archivos"];

            try
            {

               
                List<Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio> _lista = new List<Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio>();

                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                _lista = obj_negocio.Capa_Negocio_DescargaExcel_EnvioCliente(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, id_local, id_tipo_servicio, estado, suministro, medidor, tecnico, fechaAsignacion);

                if (_lista.Count == 0)
                {
                    return _Serialize("-1|No hay informacion para mostrar.", true);
                }

                //_servidor = String.Format("{0:ddMMyyyy_hhmmss}.xlsx", DateTime.Now);
                _servidor = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id + "DescargaExcel_EnviarCliente" + id_tipo_servicio + ".xlsx";
                _ruta = Path.Combine(Server.MapPath("~/Temp") + "\\" + _servidor);

                FileInfo _file = new FileInfo(_ruta);
                if (_file.Exists)
                {
                    _file.Delete();
                    _file = new FileInfo(_ruta);
                }

                if (id_tipo_servicio == 1 || id_tipo_servicio == 2)  // lecturas relecturas
                {
                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                    {
                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("Importar");
                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                        for (int i = 1; i <= 13; i++)
                        {
                            oWs.Cells[1, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            oWs.Cells[1, i].Style.Font.Size = 9; //letra tamaño   
                            oWs.Cells[1, i].Style.Font.Bold = true; //Letra negrita 
                        }

                        oWs.Cells[1, 1].Value = "ITEM";
                        oWs.Cells[1, 2].Value = "INSTALACIÓN";
                        oWs.Cells[1, 3].Value = "EQUIPO";
                        oWs.Cells[1, 4].Value = "MEDIDOR";
                        oWs.Cells[1, 5].Value = "CTA.CTO";
                        oWs.Cells[1, 6].Value = "FECHA PLAN LECTURA";
                        oWs.Cells[1, 7].Value = "FECHA REAL DE LECTURA";
                        oWs.Cells[1, 8].Value = "HORA DE LECTURA REAL";
                        oWs.Cells[1, 9].Value = "LECTURA";
                        oWs.Cells[1, 10].Value = "NOTA DE LECTURISTA";
                        oWs.Cells[1, 11].Value = "CÓDIGO DE COMENTARIO";
                        oWs.Cells[1, 12].Value = "COMENTARIO";
                        oWs.Cells[1, 13].Value = "CODIGO DE LECTOR";

                        int acu = 0;

                        foreach (Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio oBj in _lista)
                        {

                            for (int i = 1; i <= 13; i++)
                            {
                                oWs.Cells[_fila, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            }
                            acu = acu + 1;
                            oWs.Cells[_fila, 1].Value = acu;
                            oWs.Cells[_fila, 2].Value = oBj.nroInstalacion_lectura;
                            oWs.Cells[_fila, 3].Value = oBj.nroEquipo_lectura;
                            oWs.Cells[_fila, 4].Value = oBj.medidor_lectura;
                            oWs.Cells[_fila, 5].Value = oBj.CuentaContrato;
                            oWs.Cells[_fila, 6].Value = oBj.FechaPlanLectura;
                            oWs.Cells[_fila, 7].Value = oBj.FechaRealLectura;
                            oWs.Cells[_fila, 8].Value = oBj.HoraLecturaReal;
                            oWs.Cells[_fila, 8].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            oWs.Cells[_fila, 8].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center; // alinear texto 


                            oWs.Cells[_fila, 9].Value = oBj.Lectura;
                            oWs.Cells[_fila, 9].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            oWs.Cells[_fila, 9].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto 

                            oWs.Cells[_fila, 10].Value = oBj.NotaLecturista;
                            oWs.Cells[_fila, 11].Value = oBj.CodigoComentario;
                            oWs.Cells[_fila, 12].Value = oBj.Comentario;
                            oWs.Cells[_fila, 13].Value = oBj.CodigoLector;
                            oWs.Cells[_fila, 13].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            oWs.Cells[_fila, 13].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center ; // alinear texto 
                            _fila++;
                        }

                        oWs.Cells.Style.Font.Size = 8; //letra tamaño  

                        oWs.Row(1).Style.Font.Bold = true;
                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                        oWs.Column(1).Style.Font.Bold = true;

                        for (int i = 1; i <= 13; i++)
                        {
                            oWs.Column(i).AutoFit();
                        }  

                        oEx.Save();
                    }
                }
                else if (id_tipo_servicio == 3) // cortes
                {
                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                    {
                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("Importar");
                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                        for (int i = 1; i <= 13; i++)
                        {
                            oWs.Cells[1, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            oWs.Cells[1, i].Style.Font.Size = 9; //letra tamaño   
                            oWs.Cells[1, i].Style.Font.Bold = true; //Letra negrita 
                        }

                        oWs.Cells[1, 1].Value = "Unidad de Lectura";
                        oWs.Cells[1, 2].Value = "Ejecutante";
                        oWs.Cells[1, 3].Value = "Orden";
                        oWs.Cells[1, 4].Value = "Creado por";
                        oWs.Cells[1, 5].Value = "Status de sistema";
                        oWs.Cells[1, 6].Value = "Cód.codificación";
                        oWs.Cells[1, 7].Value = "Codificación";
                        oWs.Cells[1, 8].Value = "Contador";
                        oWs.Cells[1, 9].Value = "tcos";
                        oWs.Cells[1, 10].Value = "HORA";
                        oWs.Cells[1, 11].Value = "LECTURA";
                        oWs.Cells[1, 12].Value = "IMPOSIBILIDAD";
                        oWs.Cells[1, 13].Value = "OBSERVACIONES";

                        foreach (Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio oBj in _lista)
                        {

                            for (int i = 1; i <= 13; i++)
                            {
                                oWs.Cells[_fila, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //oWs.Cells[_fila, i].Style.Font.Size = 8; //letra tamaño   
                            }

                            oWs.Cells[_fila, 1].Value = oBj.unidadLectura;
                            oWs.Cells[_fila, 2].Value = oBj.ejecutante;
                            oWs.Cells[_fila, 3].Value = oBj.orden;
                            oWs.Cells[_fila, 4].Value = oBj.creado;

                            oWs.Cells[_fila, 5].Value = oBj.estatusSistema;
                            oWs.Cells[_fila, 6].Value = oBj.codCodificacion;
                            oWs.Cells[_fila, 7].Value = oBj.codificacion;
                            oWs.Cells[_fila, 8].Value = oBj.contador;

                            oWs.Cells[_fila, 9].Value = oBj.tcos;
                            oWs.Cells[_fila, 10].Value = oBj.hora;
                            oWs.Cells[_fila, 11].Value = oBj.lectura;
                            oWs.Cells[_fila, 12].Value = oBj.imposibilidad;
                            oWs.Cells[_fila, 13].Value = oBj.observacion;
                            _fila++;
                        }

                        oWs.Cells.Style.Font.Size = 8; //letra tamaño  
                        oWs.Row(1).Style.Font.Bold = true;
                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;
 
                        oWs.Column(1).AutoFit();
                        oWs.Column(2).AutoFit();
                        oWs.Column(3).AutoFit();
                        oWs.Column(4).AutoFit();
                        oWs.Column(5).AutoFit();
                        oWs.Column(6).AutoFit();
                        oWs.Column(7).AutoFit();
                        oWs.Column(8).AutoFit();
                        oWs.Column(9).AutoFit();
                        oWs.Column(10).AutoFit();
                        oWs.Column(11).AutoFit();
                        oWs.Column(12).AutoFit();
                        oWs.Column(13).AutoFit();

                        oEx.Save();
                    }
                }
                else if (id_tipo_servicio == 4) // Reconexion
                {

                    using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                    {
                        Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("Importar");
                        oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                        for (int i = 1; i <= 28; i++)
                        {
                            oWs.Cells[1, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            oWs.Cells[1, i].Style.Font.Size = 9; //letra tamaño   
                            oWs.Cells[1, i].Style.Font.Bold = true; //Letra negrita 
                        }

                        oWs.Cells[1, 1].Value = "Clase de aviso";
                        oWs.Cells[1, 2].Value = "Aviso";
                        oWs.Cells[1, 3].Value = "Fecha de aviso";
                        oWs.Cells[1, 4].Value = "Documento de bloqueo";
                        oWs.Cells[1, 5].Value = "Cta.Contr.";

                        oWs.Cells[1, 6].Value = "Nombre interlocutor";
                        oWs.Cells[1, 7].Value = "Clase cuenta";
                        oWs.Cells[1, 8].Value = "Aviso";
                        oWs.Cells[1, 9].Value = "Cantidad de recibos";
                        oWs.Cells[1, 10].Value = "Instalación";
                        oWs.Cells[1, 11].Value = "N°Ser.Me.";

                        oWs.Cells[1, 12].Value = "Dirección de Instal.";
                        oWs.Cells[1, 13].Value = "Distrito de Instal.";
                        oWs.Cells[1, 14].Value = "Unidad de Lectura";
                        oWs.Cells[1, 15].Value = "Ejecutante";

                        oWs.Cells[1, 16].Value = "Orden";
                        oWs.Cells[1, 17].Value = "Creado por";
                        oWs.Cells[1, 18].Value = "Contador";
                        oWs.Cells[1, 19].Value = "Estado Instalación";
                        oWs.Cells[1, 20].Value = "Status de usuario";

                        oWs.Cells[1, 21].Value = "Status de sistema";
                        oWs.Cells[1, 22].Value = "Codificación";
                        oWs.Cells[1, 23].Value = "Cód.codificación";

                        oWs.Cells[1, 24].Value = "tcos";
                        oWs.Cells[1, 25].Value = "HORA";
                        oWs.Cells[1, 26].Value = "LECTURA ";
                        oWs.Cells[1, 27].Value = "IMPOSIBILIDAD ";
                        oWs.Cells[1, 28].Value = "NOMBRE DEL CLIENTE";

                        foreach (Cls_Entidad_AsignaOrdenTrabajo.LecturaEnvio oBj in _lista)
                        {
                            
                            for (int i = 1; i <= 28; i++)
                            {
                                oWs.Cells[_fila, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            }

                            oWs.Cells[_fila, 1].Value = oBj.claseAviso;
                            oWs.Cells[_fila, 2].Value = oBj.aviso;
                            oWs.Cells[_fila, 3].Value = oBj.fechaAviso;
                            oWs.Cells[_fila, 4].Value = oBj.docBloqueo;
                            oWs.Cells[_fila, 5].Value = oBj.ctaContrato;
                            oWs.Cells[_fila, 6].Value = oBj.nombreInterlocutor;

                            oWs.Cells[_fila, 7].Value = oBj.claseCuenta;
                            oWs.Cells[_fila, 8].Value = oBj.aviso;
                            oWs.Cells[_fila, 9].Value = oBj.cantRecibos;
                            oWs.Cells[_fila, 10].Value = oBj.instalacion;
                            oWs.Cells[_fila, 11].Value = oBj.nroSerieMedidor;

                            oWs.Cells[_fila, 12].Value = oBj.direcInstalacion;
                            oWs.Cells[_fila, 13].Value = oBj.distritoInstalacion;
                            oWs.Cells[_fila, 14].Value = oBj.unidadLectura;

                            oWs.Cells[_fila, 15].Value = oBj.Ejecutante;
                            oWs.Cells[_fila, 16].Value = oBj.orden;
                            oWs.Cells[_fila, 17].Value = oBj.creadoPor;
                            oWs.Cells[_fila, 18].Value = oBj.contador;
                            oWs.Cells[_fila, 19].Value = oBj.estadoInstalacion;

                            oWs.Cells[_fila, 20].Value = oBj.estatusUsuario;
                            oWs.Cells[_fila, 21].Value = oBj.estatusSistema;

                            oWs.Cells[_fila, 22].Value = oBj.codificacion;
                            oWs.Cells[_fila, 23].Value = oBj.codCodificacion;
                            oWs.Cells[_fila, 24].Value = oBj.tcos;

                            oWs.Cells[_fila, 25].Value = oBj.hora;
                            oWs.Cells[_fila, 26].Value = oBj.lectura;
                            oWs.Cells[_fila, 27].Value = oBj.imposibilidad;
                            oWs.Cells[_fila, 28].Value = oBj.nombreCliente;
                            _fila++;
                        }

                        oWs.Cells.Style.Font.Size = 8; //letra tamaño  

                        oWs.Row(1).Style.Font.Bold = true;
                        oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                        oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

 
                        oWs.Column(1).AutoFit();
                        oWs.Column(2).AutoFit();
                        oWs.Column(3).AutoFit();
                        oWs.Column(4).AutoFit();
                        oWs.Column(5).AutoFit();
                        oWs.Column(6).AutoFit();
                        oWs.Column(7).AutoFit();
                        oWs.Column(8).AutoFit();
                        oWs.Column(9).AutoFit();
                        oWs.Column(10).AutoFit();
                        oWs.Column(11).AutoFit();
                        oWs.Column(12).AutoFit();
                        oWs.Column(13).AutoFit();
                        oWs.Column(14).AutoFit();
                        oWs.Column(15).AutoFit();
                        oWs.Column(16).AutoFit();
                        oWs.Column(17).AutoFit();
                        oWs.Column(18).AutoFit();
                        oWs.Column(19).AutoFit();
                        oWs.Column(20).AutoFit();
                        oWs.Column(21).AutoFit();
                        oWs.Column(22).AutoFit();
                        oWs.Column(23).AutoFit();
                        oWs.Column(24).AutoFit();
                        oWs.Column(25).AutoFit();
                        oWs.Column(26).AutoFit();
                        oWs.Column(27).AutoFit();
                        oWs.Column(28).AutoFit();
                        oEx.Save();
                    }
                }

                return _Serialize("1|" + ruta_descarga +  _servidor, true);


            }
            catch (Exception ex)
            {
                return _Serialize("0|" + ex.Message, true);
            }
        }

 
        [HttpPost]
        public string Previsualizacion(string fechamovil, int tipoServicio, List<int> List_codigos)
        {

            object loDatos = null;
            try
            {
                var usuario = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id;
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_UpdateFechaAplicativoMovilLectura(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, fechamovil, usuario, tipoServicio, List_codigos);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string UpdateFechaAplicativoMovilLectura(string fechamovil, int tipoServicio, List<int> List_codigos)
        {
   

            object loDatos = null;
            try
            {
                var usuario = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id;
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_UpdateFechaAplicativoMovilLectura(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, fechamovil, usuario, tipoServicio, List_codigos);
                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



        [HttpPost]
        public string ListandoEstadosLectura()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaEstadosLectura();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string ListandoEstadosAll()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_estadosAll();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public ActionResult DescargaListaPreVisualizaEnvio(string fechamovil, int tipoServicio, List<int> List_codigos)
        {
           

            string tituloHoja = "";
            //if (__b == "1")
            //{
            //    tituloHoja = "EnvioAlCliente";
            //}
            //else
            //{
                tituloHoja = "PreVisualizaEnvioAlCliente";
            //}
            Int32 _fila = 2;
            String _servidor;
            String _ruta;

            //if (__a.Length == 0)
            //{
            //    return View();
            //}

            _servidor = String.Format("{0:ddMMyyyy_hhmmss}.xlsx", DateTime.Now);
            _ruta = Path.Combine(Server.MapPath("/Lecturas/Temp"), _servidor);

            FileInfo _file = new FileInfo(_ruta);
            if (_file.Exists)
            {
                _file.Delete();
                _file = new FileInfo(_ruta);
            }

            using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
            {

                List<EnvioTrabajoCliLecReLec> _lista = new NEnvioTrabajoCliLecReLec().NListaPreVisualizLecturaEnvioCliente(fechamovil, tipoServicio, List_codigos);

                Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add(tituloHoja);

                oWs.Cells[1, 1].Value = "ORDEN";
                //oWs.Cells[1, 2].Value = "SECTOR";
                oWs.Cells[1, 2].Value = "ZONA";
               // oWs.Cells[1, 4].Value = "CORRELATIVO";
                oWs.Cells[1, 3].Value = "SUMINISTRO";
                oWs.Cells[1, 4].Value = "MEDIDOR";
                oWs.Cells[1, 5].Value = "LECTURA";
                oWs.Cells[1, 6].Value = "CODIGO";
                oWs.Cells[1, 7].Value = "OBSERVACIONES";
                oWs.Cells[1, 8].Value = "DIRECCION";
                oWs.Cells[1, 9].Value = "MARCA";
                //oWs.Cells[1, 12].Value = "BLOCK";
                oWs.Cells[1, 10].Value = "NOMBRE DEL LECTURISTA";
                oWs.Cells[1, 11].Value = "FECHA DE LECTURA";
                oWs.Cells[1, 12].Value = "CONFIRMACION DE LECTURA";
                oWs.Cells[1, 13].Value = "FOTO";

                foreach (EnvioTrabajoCliLecReLec oBj in _lista)
                {
                    oWs.Cells[_fila, 1].Value = oBj.corre;
                   // oWs.Cells[_fila, 2].Value = (oBj.lecSeccionLectura);
                    oWs.Cells[_fila, 2].Value = (oBj.zonaLectura);
                   // oWs.Cells[_fila, 4].Value = (oBj.lecCorrelativo);
                    oWs.Cells[_fila, 3].Value = (oBj.suministroLectura);
                    oWs.Cells[_fila, 4].Value = (oBj.medidorLectura);
                    oWs.Cells[_fila, 5].Value = (oBj.lecMovil);
                    oWs.Cells[_fila, 6].Value = (oBj.idlecObs);
                    oWs.Cells[_fila, 7].Value = (oBj.obsLectura);
                    oWs.Cells[_fila, 8].Value = (oBj.dirLectura);
                    oWs.Cells[_fila, 9].Value = (oBj.lecMarcaMedidor);
                    //oWs.Cells[_fila, 12].Value = (oBj.blockLectura);
                    oWs.Cells[_fila, 10].Value = (oBj.ope_nombre);
                    oWs.Cells[_fila, 11].Value = (oBj.fecLectura);
                    oWs.Cells[_fila, 12].Value = (oBj.confirLectura);
                    oWs.Cells[_fila, 13].Value = (oBj.foto);
                    _fila++;
                }

                oWs.Row(1).Style.WrapText = true;
                oWs.Row(1).Style.Font.Bold = true;
                oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;
                oWs.Column(1).Style.Font.Bold = true;
                oWs.Column(1).AutoFit();
                oWs.Column(2).AutoFit();
                oWs.Column(3).AutoFit();
                oWs.Column(4).AutoFit();
                oWs.Column(5).AutoFit();
                oWs.Column(6).AutoFit();
                oWs.Column(7).AutoFit();
                oWs.Column(8).AutoFit();
                oWs.Column(9).AutoFit();
                oWs.Column(10).AutoFit();
                oWs.Column(11).AutoFit();
                oWs.Column(12).AutoFit();
                oWs.Column(13).AutoFit();
                //oWs.Column(14).AutoFit();
                //oWs.Column(15).AutoFit();
                //oWs.Column(16).AutoFit();
                oEx.Save();
            }

            return new ContentResult
            {
                Content = "{ \"__a\": \"" + _servidor + "\" }",
                ContentType = "application/json"
            };
        }


        //Validacion de Lecturas

        public ActionResult ValidacionLectura_inicio()
        {
            return View();
        }

        [HttpPost]
        public string ListandoLecturaEnviarCliente_Validacion(int estado, string fechaAsignacion,  string estado_new, int resultado, int id_supervisor, int id_operario_supervisor, int servicio)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaLecturaEnviarCliente_Validacion(estado,  fechaAsignacion,  estado_new,resultado, id_supervisor, id_operario_supervisor, servicio);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        
        [HttpPost]
        public string DescargaExcel_ValidacionLectura(  int estado,  string fechaAsignacion,   string estado_new, int resultadoNew, int id_supervisor, int id_operario_supervisor, int idServicio)
        {
            Int32 _fila = 2;
            string _servidor;
            String _ruta;
            string ruta_descarga = ConfigurationManager.AppSettings["Archivos"];

            try
            {

                List<Cls_Entidad_AsignaOrdenTrabajo.validacion> _lista = new List<Cls_Entidad_AsignaOrdenTrabajo.validacion>();

                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                _lista = obj_negocio.Capa_Negocio_Get_ListaLecturaEnviarCliente_Validacion(estado, fechaAsignacion, estado_new, resultadoNew, id_supervisor, id_operario_supervisor, idServicio);

                if (_lista.Count == 0)
                {
                    return _Serialize("0|No hay informacion para mostrar.", true);
                }

               _servidor = String.Format("{0:ddMMyyyy_hhmmss}.xlsx", DateTime.Now);
                _ruta = Path.Combine(Server.MapPath("~/Temp") + "\\ValidacionLecturas" + _servidor);

                FileInfo _file = new FileInfo(_ruta);
                if (_file.Exists)
                {
                    _file.Delete();
                    _file = new FileInfo(_ruta);
                }

                using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                {
                    Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("ValidacionLecturas");
                    oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));
                    
                    oWs.Cells[1, 1].Value = "Orden";
                    oWs.Cells[1, 2].Value = "Cuenta Contrato";
                    oWs.Cells[1, 3].Value = "Medidor";
                    oWs.Cells[1, 4].Value = "Lecturista";
                    oWs.Cells[1, 5].Value = "Foto";
                    oWs.Cells[1, 6].Value = "Lectura Actual";

                    oWs.Cells[1, 7].Value = "Obs._Lectura";
                    oWs.Cells[1, 8].Value = "Consumo Actual";
                    oWs.Cells[1, 9].Value = "Porcentaje";
                    oWs.Cells[1, 10].Value = "Lectura Anterior";
                    oWs.Cells[1, 11].Value = "Promedio 2 meses";
                    oWs.Cells[1, 12].Value = "Consumo 01 ";
                    oWs.Cells[1, 13].Value = "Consumo 02";
                    oWs.Cells[1, 14].Value = "Resultados";
 
                    int acu = 0;

                    foreach (Cls_Entidad_AsignaOrdenTrabajo.validacion oBj in _lista)
                    {
                        acu = acu + 1;

                        for (int i = 1; i <= 14; i++)
                        {
                            //oWs.Cells[_fila, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
 
                        }

                        oWs.Cells[_fila, 1].Value = acu;
                        oWs.Cells[_fila, 2].Value = oBj.suministro_lectura;
                        oWs.Cells[_fila, 3].Value = oBj.medidor_lectura;
                        oWs.Cells[_fila, 4].Value = oBj.operario;

                        oWs.Cells[_fila, 5].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center; // alinear texto
                        oWs.Cells[_fila, 5].Value = oBj.foto;

                        oWs.Cells[_fila, 6].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto
                        oWs.Cells[_fila, 6].Value = oBj.lectura_movil;
                        oWs.Cells[_fila, 7].Value = oBj.descripcion_observacion;

                        oWs.Cells[_fila, 8].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto
                        oWs.Cells[_fila, 8].Value = oBj.Consu_act;

                        oWs.Cells[_fila, 9].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto
                        oWs.Cells[_fila, 9].Value = oBj.Porcen;

                        oWs.Cells[_fila, 10].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto
                        oWs.Cells[_fila, 10].Value = oBj.L_ant;

                        oWs.Cells[_fila, 11].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto
                        oWs.Cells[_fila, 11].Value = oBj.Prom_3mes;

                        oWs.Cells[_fila, 12].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto
                        oWs.Cells[_fila, 12].Value = oBj.Consu_01;
 
                        oWs.Cells[_fila, 13].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear texto
                        oWs.Cells[_fila, 13].Value = oBj.Consu_02;
                        oWs.Cells[_fila, 14].Value = oBj.resultado;
                        oWs.Cells[_fila, 13].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center; // alinear texto

                        _fila++;
                    }

                    oWs.Cells.Style.Font.Size = 8; //letra tamaño  
                    oWs.Row(1).Style.Font.Bold = true;
                    oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                    oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                    oWs.Column(1).Style.Font.Bold = true;

                    for (int i = 1; i <=14; i++)
                    {
                        oWs.Column(i).AutoFit();
                    }

                    oEx.Save();
                }


                return _Serialize("1|" + ruta_descarga + "ValidacionLecturas" + _servidor, true);


            }
            catch (Exception ex)
            {

                return _Serialize("0|" + ex.Message, true);
            }

        }


        [HttpPost]
        public string DescargarArchivoTexto_EnvioCliente(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_negocio_DescargarArchivoTexto_EnvioCliente(id_local, id_tipo_servicio, estado, fechaAsignacion, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

 
        [HttpPost]
        public string DescargarArchivoTexto_CorteReconexiones(int id_tipo_servicio, int estado,int tecnico, string fechaAsignacion, int tipo)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_negocio_DescargarArchivoTexto_CortesReconexiones(id_tipo_servicio, estado, fechaAsignacion, tecnico, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, tipo);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string Proceso_Recepcion_lecturas(int servicio, string fechaAsigna)
        {
            string loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Set_procesarRecepcionLecturas(servicio, fechaAsigna, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



        [HttpPost]
        public string Proceso_RecepcionTrabajos(int servicio, string fechaAsigna)
        {
            string loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Set_procesarRecepcion_Trabajos(servicio, fechaAsigna, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string Proceso_Verificacion_Porcentaje(string List_codigos, int servicio)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Proceso_Verificacion_Porcentaje(List_codigos, servicio);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string ListandoServicios()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaServicio_new();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string ListandoLectura_EnviarCliente(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, string tipoCliente, int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaLectura_EnviarCliente(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, id_local, id_tipo_servicio, estado, suministro, medidor, tecnico, fechaAsignacion, tipoCliente, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string get_alertas_lecturas(string fecha_asignacion)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_Alertas_lecturas(fecha_asignacion, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string Proceso_Actualizar_lecturas(int id_lectura, string valor_lectura)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Proceso_actualizar_lecturas(id_lectura, valor_lectura, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string Proceso_Almacenar_lecturas()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Proceso_almacenar_lecturas(((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



        [HttpPost]
        public string set_cambiarfoto(HttpPostedFileBase file, int idfotoLectura, string nombrefotoLectura)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                string extension = System.IO.Path.GetExtension(file.FileName); 

                string[] obj_foto = nombrefotoLectura.Split('_');
                string nameFoto = DateTime.Now.ToString("HH:mm:ss.FFF").Replace(":", "");
                nameFoto = nameFoto.Replace(".", "");

                //--- formateando el nuevo nombre-----
                string nombrefinal = obj_foto[0] + "_" + obj_foto[1] + "_" + obj_foto[2] + "_" + nameFoto + extension;

                //---- guardando la imagen ---
                string fileLocation = Server.MapPath("~/Content/foto/foto") + "\\" + nombrefinal;
                file.SaveAs(fileLocation);

                if (System.IO.File.Exists(fileLocation))
                {
                    loDatos = obj_negocio.Capa_Negocio_cambiarfoto(((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, idfotoLectura,  nombrefinal);
                    return _Serialize(loDatos, true);
                }
                else {
                    loDatos = new
                    {
                        ok = false,
                        mensaje = "Error: No se pudo guardar la foto en el servidor"
                    };

                    return _Serialize(loDatos, true);
                }
            }
            catch (Exception ex)
            {
                loDatos = new
                {
                    ok = false,
                    mensaje = ex.Message
                };
                return _Serialize(loDatos, true);
            }
        }



        [HttpPost]
        public string set_cambiarfoto_Lecturas(HttpPostedFileBase file, int idfotoLectura, string nombrefotoLectura)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                string extension = System.IO.Path.GetExtension(file.FileName);

                string[] obj_foto = nombrefotoLectura.Split('_');
                string nameFoto = DateTime.Now.ToString("HH:mm:ss.FFF").Replace(":", "");
                nameFoto = nameFoto.Replace(".", "");

                //--- formateando el nuevo nombre-----
                string nombrefinal = obj_foto[0] + "_" + obj_foto[1] + "_" + obj_foto[2] + "_" + nameFoto + extension;

                //---- guardando la imagen ---
                string fileLocation = Server.MapPath("~/Content/foto/foto") + "\\" + nombrefinal;
                file.SaveAs(fileLocation);

                if (System.IO.File.Exists(fileLocation))
                {
                    loDatos = obj_negocio.Capa_Negocio_cambiarfoto_Lectura(((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, idfotoLectura, nombrefinal);
                    return _Serialize(loDatos, true);          
                }
                else
                {
                    loDatos = new
                    {
                        ok = false,
                        mensaje = "Error: No se pudo guardar la foto en el servidor"
                    };

                    return _Serialize(loDatos, true);
                }
            }
            catch (Exception ex)
            {
                loDatos = new
                {
                    ok = false,
                    mensaje = ex.Message
                };
                return _Serialize(loDatos, true);
            }
        }





        [HttpPost]
        public string Proceso_Almacenar_lecturas_vacias()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Proceso_almacenar_lecturas_vacias(((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string set_generando_relectura(int id_servicio, string fecha_Asignacion)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_set_generando_relectura(id_servicio, fecha_Asignacion, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id );
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string DescargarArchivoTexto_EnvioCliente_relectura(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_negocio_DescargarArchivoTexto_EnvioCliente_relectura(id_local, id_tipo_servicio, estado, fechaAsignacion, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



        [HttpPost]
        public string download_liquidacionOrdenTrabajo( int id_tipo_servicio, int estado, string suministro, string medidor, string fechaInicial, string fechaFinal, string tipoCliente, int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_download_liquidacionOT( id_tipo_servicio, estado, suministro, medidor, fechaInicial, fechaFinal, tipoCliente, id_supervisor, id_operario_supervisor, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id );
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string DescargarArchivoTexto_EnvioCliente_new(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion, int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_negocio_DescargarArchivoTexto_EnvioCliente_new(id_local, id_tipo_servicio, estado, fechaAsignacion, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string DescargaExcel_macros(int idServicio, int idEstado, string fechaAsignacion, int tipoMacro)
        {
            object loDatos = null;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();

                if (tipoMacro == 1)
                {
                    loDatos = obj_negocio.Capa_Negocio_DescargaExcel_macros_ordenes(idServicio, idEstado, fechaAsignacion, tipoMacro, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                }
                if (tipoMacro == 2)
                {
                    loDatos = obj_negocio.Capa_Negocio_DescargaExcel_macros_operaciones(idServicio, idEstado, fechaAsignacion, tipoMacro, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                }

                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


    }
}
