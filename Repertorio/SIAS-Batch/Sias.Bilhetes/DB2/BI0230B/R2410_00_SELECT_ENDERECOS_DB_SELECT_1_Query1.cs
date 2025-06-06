using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0230B
{
    public class R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ENDERECO
            ,SIGLA_UF
            INTO :ENDERECO-COD-ENDERECO
            ,:ENDERECO-SIGLA-UF
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE
            AND COD_ENDERECO = :ENDERECO-COD-ENDERECO
            AND OCORR_ENDERECO = :ENDERECO-OCORR-ENDERECO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ENDERECO
											,SIGLA_UF
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.ENDERECO_COD_CLIENTE}'
											AND COD_ENDERECO = '{this.ENDERECO_COD_ENDERECO}'
											AND OCORR_ENDERECO = '{this.ENDERECO_OCORR_ENDERECO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_COD_CLIENTE { get; set; }

        public static R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 Execute(R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 r2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = r2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}