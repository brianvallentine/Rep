using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0972B
{
    public class R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            VALUES ( 'VA0972B' ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            'VA' ,
            'VA0512B' ,
            0,
            0,
            :SISTEMAS-DATA-MOV-ABERTO ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :RELATORI-NUM-APOLICE,
            0,
            :RELATORI-NUM-PARCELA,
            :RELATORI-NUM-CERTIFICADO,
            0,
            :RELATORI-COD-SUBGRUPO ,
            0,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0972B' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 'VA' , 'VA0512B' , 0, 0, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.RELATORI_NUM_APOLICE)}, 0, {FieldThreatment(this.RELATORI_NUM_PARCELA)}, {FieldThreatment(this.RELATORI_NUM_CERTIFICADO)}, 0, {FieldThreatment(this.RELATORI_COD_SUBGRUPO)} , 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }

        public static void Execute(R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 r2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = r2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}