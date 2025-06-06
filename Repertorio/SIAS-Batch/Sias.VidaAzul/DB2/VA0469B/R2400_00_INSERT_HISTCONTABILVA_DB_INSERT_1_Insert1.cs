using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 : QueryBasis<R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIST_CONT_PARCELVA
            (NUM_CERTIFICADO,
            NUM_PARCELA,
            NUM_TITULO,
            OCORR_HISTORICO,
            NUM_APOLICE,
            COD_SUBGRUPO,
            COD_FONTE,
            NUM_ENDOSSO,
            PREMIO_VG,
            PREMIO_AP,
            DATA_MOVIMENTO,
            SIT_REGISTRO,
            COD_OPERACAO,
            TIMESTAMP,
            DTFATUR)
            VALUES (:RELATORI-NUM-CERTIFICADO,
            :RELATORI-NUM-PARCELA,
            :COBHISVI-NUM-TITULO,
            :COBHISVI-OCORR-HISTORICO,
            :RELATORI-NUM-APOLICE,
            :RELATORI-COD-SUBGRUPO,
            :PROPOVA-COD-FONTE,
            0,
            :WHOST-PRM-VG,
            :WHOST-PRM-AP,
            :WHOST-DATA-CRED,
            '0' ,
            :COBHISVI-COD-OPERACAO,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_CONT_PARCELVA (NUM_CERTIFICADO, NUM_PARCELA, NUM_TITULO, OCORR_HISTORICO, NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_ENDOSSO, PREMIO_VG, PREMIO_AP, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, TIMESTAMP, DTFATUR) VALUES ({FieldThreatment(this.RELATORI_NUM_CERTIFICADO)}, {FieldThreatment(this.RELATORI_NUM_PARCELA)}, {FieldThreatment(this.COBHISVI_NUM_TITULO)}, {FieldThreatment(this.COBHISVI_OCORR_HISTORICO)}, {FieldThreatment(this.RELATORI_NUM_APOLICE)}, {FieldThreatment(this.RELATORI_COD_SUBGRUPO)}, {FieldThreatment(this.PROPOVA_COD_FONTE)}, 0, {FieldThreatment(this.WHOST_PRM_VG)}, {FieldThreatment(this.WHOST_PRM_AP)}, {FieldThreatment(this.WHOST_DATA_CRED)}, '0' , {FieldThreatment(this.COBHISVI_COD_OPERACAO)}, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string COBHISVI_OCORR_HISTORICO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string WHOST_PRM_VG { get; set; }
        public string WHOST_PRM_AP { get; set; }
        public string WHOST_DATA_CRED { get; set; }
        public string COBHISVI_COD_OPERACAO { get; set; }

        public static void Execute(R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 r2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1)
        {
            var ths = r2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}