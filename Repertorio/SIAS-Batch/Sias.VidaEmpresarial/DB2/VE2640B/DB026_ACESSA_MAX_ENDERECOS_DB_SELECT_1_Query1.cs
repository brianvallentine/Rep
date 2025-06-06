using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO),0)
            INTO :ENDERECO-OCORR-ENDERECO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							,0)
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.ENDERECO_COD_CLIENTE}'";

            return query;
        }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_COD_CLIENTE { get; set; }

        public static DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1 Execute(DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1 dB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = dB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}