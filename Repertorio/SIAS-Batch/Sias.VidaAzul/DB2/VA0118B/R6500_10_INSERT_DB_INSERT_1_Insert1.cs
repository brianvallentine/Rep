using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class R6500_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R6500_10_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PARCEL_FED_CAP_VA
            ( NRTITFDCAP ,
            NUM_PARCELA ,
            VAL_CUSTO_TITULO ,
            DTFATUR ,
            DATA_MOVIMENTO ,
            SITUACAO ,
            NRMFDCAP ,
            TIMESTAMP )
            VALUES
            ( :MOVFEDCA-NRTITFDCAP ,
            0 ,
            :PARFEDCA-VAL-CUSTO-TITULO ,
            :SISTEMA-DTMOVABE ,
            :SISTEMA-DTMOVABE ,
            '1' ,
            0 ,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCEL_FED_CAP_VA ( NRTITFDCAP , NUM_PARCELA , VAL_CUSTO_TITULO , DTFATUR , DATA_MOVIMENTO , SITUACAO , NRMFDCAP , TIMESTAMP ) VALUES ( {FieldThreatment(this.MOVFEDCA_NRTITFDCAP)} , 0 , {FieldThreatment(this.PARFEDCA_VAL_CUSTO_TITULO)} , {FieldThreatment(this.SISTEMA_DTMOVABE)} , {FieldThreatment(this.SISTEMA_DTMOVABE)} , '1' , 0 , CURRENT TIMESTAMP )";

            return query;
        }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string PARFEDCA_VAL_CUSTO_TITULO { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }

        public static void Execute(R6500_10_INSERT_DB_INSERT_1_Insert1 r6500_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r6500_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6500_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}