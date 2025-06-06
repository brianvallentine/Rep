using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005S
{
    public class M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1 : QueryBasis<M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_PESSOA ,
            TIPO_PESSOA ,
            SIGLA_PESSOA
            INTO :BI0005L-S-NOME-PESSOA ,
            :BI0005L-S-TIPO-PESSOA ,
            :BI0005L-S-SIGLA-PESSOA :VIND-FILLER
            FROM SEGUROS.PESSOA
            WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME_PESSOA 
							,
											TIPO_PESSOA 
							,
											SIGLA_PESSOA
											FROM SEGUROS.PESSOA
											WHERE COD_PESSOA = '{this.BI0005L_E_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string BI0005L_S_NOME_PESSOA { get; set; }
        public string BI0005L_S_TIPO_PESSOA { get; set; }
        public string BI0005L_S_SIGLA_PESSOA { get; set; }
        public string VIND_FILLER { get; set; }
        public string BI0005L_E_COD_PESSOA { get; set; }

        public static M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1 Execute(M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1 m_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = m_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.BI0005L_S_NOME_PESSOA = result[i++].Value?.ToString();
            dta.BI0005L_S_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.BI0005L_S_SIGLA_PESSOA = result[i++].Value?.ToString();
            dta.VIND_FILLER = string.IsNullOrWhiteSpace(dta.BI0005L_S_SIGLA_PESSOA) ? "-1" : "0";
            return dta;
        }

    }
}