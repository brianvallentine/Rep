using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1 : QueryBasis<R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRM_TOTAL,
            DATA_VENCIMENTO ,
            COD_AGENCIA_DEBITO
            INTO
            :HISLANCT-PRM-TOTAL,
            :HISLANCT-DATA-VENCIMENTO ,
            :HISLANCT-COD-AGENCIA-DEBITO
            FROM SEGUROS.HIST_LANC_CTA
            WHERE NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO
            AND NUM_PARCELA = 1
            AND SIT_REGISTRO = '1'
            AND TIPLANC = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRM_TOTAL
							,
											DATA_VENCIMENTO 
							,
											COD_AGENCIA_DEBITO
											FROM SEGUROS.HIST_LANC_CTA
											WHERE NUM_CERTIFICADO = '{this.MOVVGAP_NUM_CERTIFICADO}'
											AND NUM_PARCELA = 1
											AND SIT_REGISTRO = '1'
											AND TIPLANC = '1'
											WITH UR";

            return query;
        }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_DATA_VENCIMENTO { get; set; }
        public string HISLANCT_COD_AGENCIA_DEBITO { get; set; }
        public string MOVVGAP_NUM_CERTIFICADO { get; set; }

        public static R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1 Execute(R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1 r0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1)
        {
            var ths = r0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.HISLANCT_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.HISLANCT_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}