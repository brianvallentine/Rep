using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1 : QueryBasis<R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO),0) + 1
            INTO :ENDERECO-OCORR-ENDERECO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							,0) + 1
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.ENDERECO_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_COD_CLIENTE { get; set; }

        public static R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1 Execute(R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1 r8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1)
        {
            var ths = r8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}