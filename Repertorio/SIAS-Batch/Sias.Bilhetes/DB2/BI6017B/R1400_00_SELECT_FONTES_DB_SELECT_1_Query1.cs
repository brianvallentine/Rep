using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6017B
{
    public class R1400_00_SELECT_FONTES_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FONTE,
            ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP
            INTO :FONTES-NOME-FONTE,
            :FONTES-ENDERECO,
            :FONTES-BAIRRO,
            :FONTES-CIDADE,
            :FONTES-SIGLA-UF,
            :FONTES-CEP
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :BILHETE-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FONTE
							,
											ENDERECO
							,
											BAIRRO
							,
											CIDADE
							,
											SIGLA_UF
							,
											CEP
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.BILHETE_FONTE}'";

            return query;
        }
        public string FONTES_NOME_FONTE { get; set; }
        public string FONTES_ENDERECO { get; set; }
        public string FONTES_BAIRRO { get; set; }
        public string FONTES_CIDADE { get; set; }
        public string FONTES_SIGLA_UF { get; set; }
        public string FONTES_CEP { get; set; }
        public string BILHETE_FONTE { get; set; }

        public static R1400_00_SELECT_FONTES_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_FONTES_DB_SELECT_1_Query1 r1400_00_SELECT_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            dta.FONTES_ENDERECO = result[i++].Value?.ToString();
            dta.FONTES_BAIRRO = result[i++].Value?.ToString();
            dta.FONTES_CIDADE = result[i++].Value?.ToString();
            dta.FONTES_SIGLA_UF = result[i++].Value?.ToString();
            dta.FONTES_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}