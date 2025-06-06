using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0229B
{
    public class R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ENDERECO
            INTO :ENDERECO-COD-ENDERECO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :APOLICES-COD-CLIENTE
            AND OCORR_ENDERECO = :ENDOSSOS-OCORR-ENDERECO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ENDERECO
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.APOLICES_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.ENDOSSOS_OCORR_ENDERECO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }

        public static R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 Execute(R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 r0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}