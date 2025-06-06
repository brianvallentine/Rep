using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3159S
{
    public class R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1 : QueryBasis<R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-CONTADOR
            FROM SEGUROS.LT_SOLICITA_PARAM
            WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA
            AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01
            AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO
            AND PARAM_DATE02 = :WS-DATA-AUX
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.LT_SOLICITA_PARAM
											WHERE COD_PROGRAMA = '{this.LTSOLPAR_COD_PROGRAMA}'
											AND PARAM_SMINT01 = '{this.LTSOLPAR_PARAM_SMINT01}'
											AND SIT_SOLICITACAO = '{this.LTSOLPAR_SIT_SOLICITACAO}'
											AND PARAM_DATE02 = '{this.WS_DATA_AUX}'
											WITH UR";

            return query;
        }
        public string WS_CONTADOR { get; set; }
        public string LTSOLPAR_SIT_SOLICITACAO { get; set; }
        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_COD_PROGRAMA { get; set; }
        public string WS_DATA_AUX { get; set; }

        public static R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1 Execute(R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1 r1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1)
        {
            var ths = r1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1();
            var i = 0;
            dta.WS_CONTADOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}