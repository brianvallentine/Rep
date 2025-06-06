using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP01B
{
    public class R3210_LE_FORNECEDOR_DB_SELECT_1_Query1 : QueryBasis<R3210_LE_FORNECEDOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            F.INSC_PREFEITURA AS 'INSCRICAO MUNICIPAL' ,
            F.INSC_ESTADUAL AS 'INSCRICAO ESTADUAL' ,
            F.OPT_SIMPLES_FED AS 'OPTANTE SIMPLES FERERAL' ,
            F.OPT_SIMPLES_MUN AS 'OPTANTE SIMPLES MUNICIPAL'
            INTO
            :FORNECED-INSC-PREFEITURA,
            :FORNECED-INSC-ESTADUAL,
            :FORNECED-OPT-SIMPLES-FED,
            :FORNECED-OPT-SIMPLES-MUN
            FROM SEGUROS.FORNECEDORES F
            WHERE COD_FORNECEDOR = :SINISHIS-COD-PREST-SERVICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											F.INSC_PREFEITURA AS INSCRICAOMUNICIPAL 
							,
											F.INSC_ESTADUAL AS INSCRICAOESTADUAL 
							,
											F.OPT_SIMPLES_FED AS OPTANTESIMPLESFERERAL 
							,
											F.OPT_SIMPLES_MUN AS OPTANTESIMPLESMUNICIPAL
											FROM SEGUROS.FORNECEDORES F
											WHERE COD_FORNECEDOR = '{this.SINISHIS_COD_PREST_SERVICO}'";

            return query;
        }
        public string FORNECED_INSC_PREFEITURA { get; set; }
        public string FORNECED_INSC_ESTADUAL { get; set; }
        public string FORNECED_OPT_SIMPLES_FED { get; set; }
        public string FORNECED_OPT_SIMPLES_MUN { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }

        public static R3210_LE_FORNECEDOR_DB_SELECT_1_Query1 Execute(R3210_LE_FORNECEDOR_DB_SELECT_1_Query1 r3210_LE_FORNECEDOR_DB_SELECT_1_Query1)
        {
            var ths = r3210_LE_FORNECEDOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3210_LE_FORNECEDOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3210_LE_FORNECEDOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.FORNECED_INSC_PREFEITURA = result[i++].Value?.ToString();
            dta.FORNECED_INSC_ESTADUAL = result[i++].Value?.ToString();
            dta.FORNECED_OPT_SIMPLES_FED = result[i++].Value?.ToString();
            dta.FORNECED_OPT_SIMPLES_MUN = result[i++].Value?.ToString();
            return dta;
        }

    }
}