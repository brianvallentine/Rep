using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0055B
{
    public class R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1 : QueryBasis<R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            VALUES ( 'VA0055B' ,
            :SISTEMAS-DATA-MOV-ABERTO,
            'VA' ,
            'VA0469B' ,
            0,
            0,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :PROPOVA-NUM-APOLICE,
            0,
            1,
            :PROPOVA-NUM-CERTIFICADO,
            0,
            :PROPOVA-COD-SUBGRUPO,
            16,
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
				INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0055B' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 'VA' , 'VA0469B' , 0, 0, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.PROPOVA_NUM_APOLICE)}, 0, 1, {FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, 0, {FieldThreatment(this.PROPOVA_COD_SUBGRUPO)}, 16, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }

        public static void Execute(R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1 r2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1)
        {
            var ths = r2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}