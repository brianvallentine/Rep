using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0074B
{
    public class R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1 : QueryBasis<R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.AVISOS_SALDOS
            (COD_EMPRESA ,
            BCO_AVISO ,
            AGE_AVISO ,
            TIPO_SEGURO ,
            NUM_AVISO_CREDITO ,
            DATA_AVISO ,
            DATA_MOVIMENTO ,
            SALDO_ATUAL ,
            SIT_REGISTRO ,
            TIMESTAMP)
            VALUES
            (:AVISOSAL-COD-EMPRESA ,
            :AVISOSAL-BCO-AVISO ,
            :AVISOSAL-AGE-AVISO ,
            :AVISOSAL-TIPO-SEGURO ,
            :AVISOSAL-NUM-AVISO-CREDITO ,
            :AVISOSAL-DATA-AVISO ,
            :AVISOSAL-DATA-MOVIMENTO ,
            :AVISOSAL-SALDO-ATUAL ,
            :AVISOSAL-SIT-REGISTRO ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.AVISOS_SALDOS (COD_EMPRESA , BCO_AVISO , AGE_AVISO , TIPO_SEGURO , NUM_AVISO_CREDITO , DATA_AVISO , DATA_MOVIMENTO , SALDO_ATUAL , SIT_REGISTRO , TIMESTAMP) VALUES ({FieldThreatment(this.AVISOSAL_COD_EMPRESA)} , {FieldThreatment(this.AVISOSAL_BCO_AVISO)} , {FieldThreatment(this.AVISOSAL_AGE_AVISO)} , {FieldThreatment(this.AVISOSAL_TIPO_SEGURO)} , {FieldThreatment(this.AVISOSAL_NUM_AVISO_CREDITO)} , {FieldThreatment(this.AVISOSAL_DATA_AVISO)} , {FieldThreatment(this.AVISOSAL_DATA_MOVIMENTO)} , {FieldThreatment(this.AVISOSAL_SALDO_ATUAL)} , {FieldThreatment(this.AVISOSAL_SIT_REGISTRO)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string AVISOSAL_COD_EMPRESA { get; set; }
        public string AVISOSAL_BCO_AVISO { get; set; }
        public string AVISOSAL_AGE_AVISO { get; set; }
        public string AVISOSAL_TIPO_SEGURO { get; set; }
        public string AVISOSAL_NUM_AVISO_CREDITO { get; set; }
        public string AVISOSAL_DATA_AVISO { get; set; }
        public string AVISOSAL_DATA_MOVIMENTO { get; set; }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string AVISOSAL_SIT_REGISTRO { get; set; }

        public static void Execute(R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1 r5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1)
        {
            var ths = r5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}