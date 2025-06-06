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
    public class R1200_00_CONSULTA_DB_SELECT_1_Query1 : QueryBasis<R1200_00_CONSULTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PARAM_INTG01,PARAM_DATE01,
            PARAM_DATE02,PARAM_DATE03,
            PARAM_CHAR01,PARAM_CHAR04
            INTO :LTSOLPAR-PARAM-INTG01
            ,:LTSOLPAR-PARAM-DATE01
            ,:LTSOLPAR-PARAM-DATE02
            ,:LTSOLPAR-PARAM-DATE03
            ,:LTSOLPAR-PARAM-CHAR01
            ,:LTSOLPAR-PARAM-CHAR04
            FROM SEGUROS.LT_SOLICITA_PARAM
            WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA
            AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01
            AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO
            AND :WS-DTINIVIG-PROPOSTA BETWEEN PARAM_DATE01
            AND PARAM_DATE02
            AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PARAM_INTG01
							,PARAM_DATE01
							,
											PARAM_DATE02
							,PARAM_DATE03
							,
											PARAM_CHAR01
							,PARAM_CHAR04
											FROM SEGUROS.LT_SOLICITA_PARAM
											WHERE COD_PROGRAMA = '{this.LTSOLPAR_COD_PROGRAMA}'
											AND PARAM_SMINT01 = '{this.LTSOLPAR_PARAM_SMINT01}'
											AND SIT_SOLICITACAO = '{this.LTSOLPAR_SIT_SOLICITACAO}'
											AND '{this.WS_DTINIVIG_PROPOSTA}' BETWEEN PARAM_DATE01
											AND PARAM_DATE02
											AND COD_PRODUTO = '{this.LTSOLPAR_COD_PRODUTO}'";

            return query;
        }
        public string LTSOLPAR_PARAM_INTG01 { get; set; }
        public string LTSOLPAR_PARAM_DATE01 { get; set; }
        public string LTSOLPAR_PARAM_DATE02 { get; set; }
        public string LTSOLPAR_PARAM_DATE03 { get; set; }
        public string LTSOLPAR_PARAM_CHAR01 { get; set; }
        public string LTSOLPAR_PARAM_CHAR04 { get; set; }
        public string LTSOLPAR_SIT_SOLICITACAO { get; set; }
        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_COD_PROGRAMA { get; set; }
        public string WS_DTINIVIG_PROPOSTA { get; set; }
        public string LTSOLPAR_COD_PRODUTO { get; set; }

        public static R1200_00_CONSULTA_DB_SELECT_1_Query1 Execute(R1200_00_CONSULTA_DB_SELECT_1_Query1 r1200_00_CONSULTA_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_CONSULTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_CONSULTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_CONSULTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTSOLPAR_PARAM_INTG01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_DATE01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_DATE02 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_DATE03 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_CHAR01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_CHAR04 = result[i++].Value?.ToString();
            return dta;
        }

    }
}