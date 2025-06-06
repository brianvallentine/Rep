using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE (MAX(OCORR_ENDERECO),0)
            INTO :WHOST-OCORR-ENDERECO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :WHOST-COD-CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE (MAX(OCORR_ENDERECO)
							,0)
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.WHOST_COD_CLIENTE}'";

            return query;
        }
        public string WHOST_OCORR_ENDERECO { get; set; }
        public string WHOST_COD_CLIENTE { get; set; }

        public static R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 Execute(R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 r4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = r4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}