using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R3000_10_CONTINUA_DB_SELECT_5_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_MATRICULA ,
            NOME_FUNCIONARIO ,
            ENDERECO_CEF ,
            CIDADE_CEF ,
            SIGLA_UF ,
            CEP ,
            NUM_CPF ,
            COD_ANGARIADOR
            INTO :V1FUNC-NUM-MATRIC ,
            :V1FUNC-NOME-FUN ,
            :V1FUNC-ENDERECO ,
            :V1FUNC-CIDADE ,
            :V1FUNC-SIGLA-UF ,
            :V1FUNC-CEP ,
            :V1FUNC-NUM-CPF ,
            :V1FUNC-COD-ANGAR:VIND-COD-ANGAR
            FROM SEGUROS.V1FUNCIOCEF
            WHERE NUM_MATRICULA = :V0BILH-NUM-MATR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_MATRICULA 
							,
											NOME_FUNCIONARIO 
							,
											ENDERECO_CEF 
							,
											CIDADE_CEF 
							,
											SIGLA_UF 
							,
											CEP 
							,
											NUM_CPF 
							,
											COD_ANGARIADOR
											FROM SEGUROS.V1FUNCIOCEF
											WHERE NUM_MATRICULA = '{this.V0BILH_NUM_MATR}'";

            return query;
        }
        public string V1FUNC_NUM_MATRIC { get; set; }
        public string V1FUNC_NOME_FUN { get; set; }
        public string V1FUNC_ENDERECO { get; set; }
        public string V1FUNC_CIDADE { get; set; }
        public string V1FUNC_SIGLA_UF { get; set; }
        public string V1FUNC_CEP { get; set; }
        public string V1FUNC_NUM_CPF { get; set; }
        public string V1FUNC_COD_ANGAR { get; set; }
        public string VIND_COD_ANGAR { get; set; }
        public string V0BILH_NUM_MATR { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_5_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_5_Query1 r3000_10_CONTINUA_DB_SELECT_5_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_5_Query1();
            var i = 0;
            dta.V1FUNC_NUM_MATRIC = result[i++].Value?.ToString();
            dta.V1FUNC_NOME_FUN = result[i++].Value?.ToString();
            dta.V1FUNC_ENDERECO = result[i++].Value?.ToString();
            dta.V1FUNC_CIDADE = result[i++].Value?.ToString();
            dta.V1FUNC_SIGLA_UF = result[i++].Value?.ToString();
            dta.V1FUNC_CEP = result[i++].Value?.ToString();
            dta.V1FUNC_NUM_CPF = result[i++].Value?.ToString();
            dta.V1FUNC_COD_ANGAR = result[i++].Value?.ToString();
            dta.VIND_COD_ANGAR = string.IsNullOrWhiteSpace(dta.V1FUNC_COD_ANGAR) ? "-1" : "0";
            return dta;
        }

    }
}