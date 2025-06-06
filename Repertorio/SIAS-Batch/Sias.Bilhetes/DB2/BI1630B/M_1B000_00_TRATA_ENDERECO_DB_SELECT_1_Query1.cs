using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO), 0)
            INTO :WS-OCC-END-ATU
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :WS-COD-CLI-ATU
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							, 0)
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.WS_COD_CLI_ATU}'
											WITH UR";

            return query;
        }
        public string WS_OCC_END_ATU { get; set; }
        public string WS_COD_CLI_ATU { get; set; }

        public static M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1 Execute(M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1 m_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = m_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_OCC_END_ATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}