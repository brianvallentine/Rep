using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R3290_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R3290_10_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA
            ( NUM_CERTIFICADO ,
            COD_OPERACAO ,
            COD_FONTE ,
            NUM_PROPOSTA ,
            DTMVFDCAP ,
            NUM_PARCELA ,
            QUANT_TIT_CAPITALI ,
            VAL_CUSTO_CAPITALI ,
            SITUACAO ,
            NRTITFDCAP ,
            NRMSCAP ,
            NUM_SEQUENCIA ,
            TIMESTAMP ,
            CODPRODU )
            VALUES
            ( :V0BILH-NUMBIL ,
            1 ,
            :V0BILH-FONTE,
            0 ,
            :V1SIST-DTMOVABE ,
            0 ,
            1 ,
            :V1BILC-VALMAX,
            '1' ,
            :MOVFEDCA-NRTITFDCAP ,
            0 ,
            0 ,
            CURRENT TIMESTAMP ,
            :V1BILP-CODPRODU )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( {FieldThreatment(this.V0BILH_NUMBIL)} , 1 , {FieldThreatment(this.V0BILH_FONTE)}, 0 , {FieldThreatment(this.V1SIST_DTMOVABE)} , 0 , 1 , {FieldThreatment(this.V1BILC_VALMAX)}, '1' , {FieldThreatment(this.MOVFEDCA_NRTITFDCAP)} , 0 , 0 , CURRENT TIMESTAMP , {FieldThreatment(this.V1BILP_CODPRODU)} )";

            return query;
        }
        public string V0BILH_NUMBIL { get; set; }
        public string V0BILH_FONTE { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1BILC_VALMAX { get; set; }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string V1BILP_CODPRODU { get; set; }

        public static void Execute(R3290_10_INSERT_DB_INSERT_1_Insert1 r3290_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r3290_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3290_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}