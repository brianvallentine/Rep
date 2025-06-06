using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0602B
{
    public class R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_BILHETE ,
            NUM_APOLICE ,
            COD_CLIENTE ,
            OPC_COBERTURA ,
            VAL_RCAP ,
            DATA_QUITACAO ,
            DATA_QUITACAO + 1 YEAR ,
            SITUACAO ,
            TIP_CANCELAMENTO ,
            SIT_SINISTRO
            INTO
            :WS-BILHETE-AUX ,
            :WS-APOLICE-AUX ,
            :WS-CLIENTE-AUX ,
            :WS-OPC-COBERT-AUX ,
            :WS-VAL-RCAP-AUX ,
            :WS-DATA-QUITACAO-AUX ,
            :WS-PROXIMA-DT-QUIT ,
            :WS-SITUACAO ,
            :WS-TIP-CANCELAMENTO ,
            :WS-SIT-SINISTRO
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE = :WS-BILHETE-AUX
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_BILHETE 
							,
											NUM_APOLICE 
							,
											COD_CLIENTE 
							,
											OPC_COBERTURA 
							,
											VAL_RCAP 
							,
											DATA_QUITACAO 
							,
											DATA_QUITACAO + 1 YEAR 
							,
											SITUACAO 
							,
											TIP_CANCELAMENTO 
							,
											SIT_SINISTRO
											FROM SEGUROS.BILHETE
											WHERE NUM_BILHETE = '{this.WS_BILHETE_AUX}'";

            return query;
        }
        public string WS_BILHETE_AUX { get; set; }
        public string WS_APOLICE_AUX { get; set; }
        public string WS_CLIENTE_AUX { get; set; }
        public string WS_OPC_COBERT_AUX { get; set; }
        public string WS_VAL_RCAP_AUX { get; set; }
        public string WS_DATA_QUITACAO_AUX { get; set; }
        public string WS_PROXIMA_DT_QUIT { get; set; }
        public string WS_SITUACAO { get; set; }
        public string WS_TIP_CANCELAMENTO { get; set; }
        public string WS_SIT_SINISTRO { get; set; }

        public static R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1 r1501_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1501_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_BILHETE_AUX = result[i++].Value?.ToString();
            dta.WS_APOLICE_AUX = result[i++].Value?.ToString();
            dta.WS_CLIENTE_AUX = result[i++].Value?.ToString();
            dta.WS_OPC_COBERT_AUX = result[i++].Value?.ToString();
            dta.WS_VAL_RCAP_AUX = result[i++].Value?.ToString();
            dta.WS_DATA_QUITACAO_AUX = result[i++].Value?.ToString();
            dta.WS_PROXIMA_DT_QUIT = result[i++].Value?.ToString();
            dta.WS_SITUACAO = result[i++].Value?.ToString();
            dta.WS_TIP_CANCELAMENTO = result[i++].Value?.ToString();
            dta.WS_SIT_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}