using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(COD_ENDERECO)
            INTO :ENDERECO-COD-ENDERECO:VIND-CODENDER
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE
            AND OCORR_ENDERECO = :ENDERECO-OCORR-ENDERECO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(COD_ENDERECO)
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.ENDERECO_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.ENDERECO_OCORR_ENDERECO}'";

            return query;
        }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string VIND_CODENDER { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_COD_CLIENTE { get; set; }

        public static R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 Execute(R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 r0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            dta.VIND_CODENDER = string.IsNullOrWhiteSpace(dta.ENDERECO_COD_ENDERECO) ? "-1" : "0";
            return dta;
        }

    }
}