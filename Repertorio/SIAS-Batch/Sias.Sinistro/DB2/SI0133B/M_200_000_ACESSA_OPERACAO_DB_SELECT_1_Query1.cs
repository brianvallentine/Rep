using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1 : QueryBasis<M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_OPERACAO
            INTO :GEOPERAC-DES-OPERACAO
            FROM SEGUROS.GE_OPERACAO
            WHERE IDE_SISTEMA = 'SI'
            AND COD_OPERACAO = :GEOPERAC-COD-OPERACAO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DES_OPERACAO
											FROM SEGUROS.GE_OPERACAO
											WHERE IDE_SISTEMA = 'SI'
											AND COD_OPERACAO = '{this.GEOPERAC_COD_OPERACAO}'";

            return query;
        }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string GEOPERAC_COD_OPERACAO { get; set; }

        public static M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1 Execute(M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1 m_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1)
        {
            var ths = m_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}