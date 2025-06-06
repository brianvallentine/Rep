using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1471B
{
    public class M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1 : QueryBasis<M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO,
            COD_CLIENTE
            INTO :APOLICES-COD-PRODUTO,
            :APOLICES-COD-CLIENTE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
							,
											COD_CLIENTE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1 Execute(M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1 m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1)
        {
            var ths = m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}