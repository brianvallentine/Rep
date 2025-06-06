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
    public class M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1 : QueryBasis<M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CEP ,
            COD_ENDERECO
            INTO :ENDERECO-CEP ,
            :ENDERECO-COD-ENDERECO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :WS-COD-CLI-ATU
            AND OCORR_ENDERECO = :WS-OCC-END-ATU
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CEP 
							,
											COD_ENDERECO
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.WS_COD_CLI_ATU}'
											AND OCORR_ENDERECO = '{this.WS_OCC_END_ATU}'
											WITH UR";

            return query;
        }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string WS_COD_CLI_ATU { get; set; }
        public string WS_OCC_END_ATU { get; set; }

        public static M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1 Execute(M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1 m_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1)
        {
            var ths = m_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1();
            var i = 0;
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}