using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0716S
{
    public class R1100_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R1100_10_INSERT_DB_INSERT_1_Insert1>
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
            ( :MOVFEDCA-NUM-CERTIFICADO ,
            1 ,
            :FONTES-COD-FONTE ,
            0 ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            0 ,
            1 ,
            :MOVFEDCA-VAL-CUSTO-CAPITALI ,
            '1' ,
            :MOVFEDCA-NRTITFDCAP ,
            0 ,
            :MOVFEDCA-NUM-SEQUENCIA ,
            CURRENT TIMESTAMP ,
            :PRODUVG-COD-PRODUTO )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( {FieldThreatment(this.MOVFEDCA_NUM_CERTIFICADO)} , 1 , {FieldThreatment(this.FONTES_COD_FONTE)} , 0 , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 0 , 1 , {FieldThreatment(this.MOVFEDCA_VAL_CUSTO_CAPITALI)} , '1' , {FieldThreatment(this.MOVFEDCA_NRTITFDCAP)} , 0 , {FieldThreatment(this.MOVFEDCA_NUM_SEQUENCIA)} , CURRENT TIMESTAMP , {FieldThreatment(this.PRODUVG_COD_PRODUTO)} )";

            return query;
        }
        public string MOVFEDCA_NUM_CERTIFICADO { get; set; }
        public string FONTES_COD_FONTE { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string MOVFEDCA_VAL_CUSTO_CAPITALI { get; set; }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string MOVFEDCA_NUM_SEQUENCIA { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }

        public static void Execute(R1100_10_INSERT_DB_INSERT_1_Insert1 r1100_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r1100_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}