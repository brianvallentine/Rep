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
    public class R6290_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R6290_10_INSERT_DB_INSERT_1_Insert1>
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
            ( :PROPVA-NRCERTIF ,
            1 ,
            :PROPVA-FONTE ,
            0 ,
            :SISTEMA-DTMOVABE ,
            0 ,
            1 ,
            :MOVFEDCA-VAL-CUSTO-CAPITALI ,
            '1' ,
            :MOVFEDCA-NRTITFDCAP ,
            0 ,
            0 ,
            CURRENT TIMESTAMP ,
            :PRODVG-COD-PRODUTO )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( {FieldThreatment(this.PROPVA_NRCERTIF)} , 1 , {FieldThreatment(this.PROPVA_FONTE)} , 0 , {FieldThreatment(this.SISTEMA_DTMOVABE)} , 0 , 1 , {FieldThreatment(this.MOVFEDCA_VAL_CUSTO_CAPITALI)} , '1' , {FieldThreatment(this.MOVFEDCA_NRTITFDCAP)} , 0 , 0 , CURRENT TIMESTAMP , {FieldThreatment(this.PRODVG_COD_PRODUTO)} )";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string MOVFEDCA_VAL_CUSTO_CAPITALI { get; set; }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string PRODVG_COD_PRODUTO { get; set; }

        public static void Execute(R6290_10_INSERT_DB_INSERT_1_Insert1 r6290_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r6290_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6290_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}